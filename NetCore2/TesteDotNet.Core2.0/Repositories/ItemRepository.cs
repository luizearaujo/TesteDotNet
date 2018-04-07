using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDotNet.Core2_0.Domains;
using TesteDotNet.Core2_0.Repositories.Base;

namespace TesteDotNet.Core2_0.Repositories
{
    public class ItemRepository : Repository, IRepository<Item>
    {

        public ItemRepository(IConfiguration conf) : base(conf)
        {
        }

        public async Task AddAsync(Item item)
        {
            string query = @"INSERT INTO Itens ( Nome
                                               , Descricao 
                                               , Categoria_Id
                                     ) VALUES ( @Nome
                                              , @Descricao
                                              , @CategoriaId
                                     )";

            await Db.ExecuteAsync(query, item);

        }

        public async Task UpdateAsync(Item item)
        {
            string query = @"UPDATE Itens
                                SET Nome = @Nome
                                  , Descricao = @Descricao
                                  , Categoria_Id = @CategoriaId
                                  , DataAlteracao = getdate()
                              WHERE Id = @Id";

            await Db.ExecuteAsync(query, item);
        }

        public IEnumerable<Item> GetAll(string busca)
        {
            var termo = (busca ?? "").Trim().ToLower();

            string query = @"SELECT I.Id
                                  , I.Nome
                                  , I.Categoria_Id                                      As CategoriaId
                                  , C.Nome                                              As CategoriaNome
                                  , I.Descricao
                                  , FORMAT(I.DataCriacao, 'dd/MM/yyyy hh:mm:ss')        AS DataCriacao
                              FROM Itens      I 
                              JOIN Categorias C ON C.Id = I.Categoria_Id 
                             WHERE I.DataExclusao IS NULL
                               AND C.DataExclusao IS NULL
                               AND (@Termo = '' 
                                    OR CONVERT(VARCHAR, I.Id) = @Termo
                                    OR LOWER(I.Nome) Like CONCAT('%', @Termo ,'%')
                                    OR LOWER(C.Nome) Like CONCAT('%', @Termo ,'%')
                                    OR FORMAT(I.DataCriacao, 'dd/MM/yyyy hh:mm:ss') Like CONCAT('%', @Termo ,'%')
                               )
                          ORDER BY Id DESC";

            return Db.Query<Item>(query, new { @Termo = termo });
        }

        public Item Get(int id)
        {
            string query = @"SELECT I.Id
                                  , I.Nome
                                  , I.Categoria_Id      As CategoriaId
                                  , C.Nome              As CategoriaNome
                                  , I.Descricao
                                  , I.DataCriacao
                              FROM Itens      I 
                              JOIN Categorias C ON C.Id = I.Categoria_Id 
                             WHERE I.Id = @Id
                               AND I.DataExclusao IS NULL
                               AND C.DataExclusao IS NULL";

            return Db.QueryFirstOrDefault<Item>(query, new { @Id = id });
        }

        public async Task DeleteAsync(int id)
        {
            string query = @"UPDATE Itens
                                SET DataAlteracao = getdate()
                                  , DataExclusao = getdate()
                              WHERE Id = @Id";

            await Db.ExecuteAsync(query, new { @Id = id });
        }

        public bool Exists(int id, string nome)
        {
            string query = @"SELECT count(0)
                              FROM Itens
                             WHERE Id != @Id
                               AND LOWER(RTRIM(LTRIM(Nome))) = LOWER(RTRIM(LTRIM(@Nome)))
                               AND DataExclusao IS NULL";

            return Db.ExecuteScalar<bool>(query, new { @Id = id, @Nome = nome });
        }
    }
}
