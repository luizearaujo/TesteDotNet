using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDotNet.Core2_0.Repositories.Base
{
    public interface IRepository<T>
    {
        T Get(int id);

        IEnumerable<T> GetAll(string busca);

        Task AddAsync(T entidade);

        Task UpdateAsync(T entidade);

        Task DeleteAsync(int id);

        bool Exists(int id, string nome);
    }
}
