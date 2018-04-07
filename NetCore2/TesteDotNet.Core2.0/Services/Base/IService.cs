using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDotNet.Core2_0.Services.Base
{
    public interface IService<T>
    {
        Task Save(T entidade);

        T Get(int? id);

        IEnumerable<T> Find(string busca);

        Task Delete(int id);

        bool Duplicate(int id, string nome);

    }
}
