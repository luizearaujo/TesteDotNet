using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDotNet.Core2_0.Domains;
using TesteDotNet.Core2_0.Repositories.Base;

namespace TesteDotNet.Core2_0.Repositories
{
    public class CategoriaRepository : Repository, IRepository<Categoria>
    {
        public CategoriaRepository(IConfiguration conf) : base(conf)
        {
        }

        public Task AddAsync(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetAll(string busca)
        {
            string query = @"SELECT Id
                                  , Nome
                               FROM Categorias
                              WHERE DataExclusao IS NULL
                           ORDER BY Nome;";

            return Db.Query<Categoria>(query);
        }

        public Categoria Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id, string nome)
        {
            throw new NotImplementedException();
        }
    }
}