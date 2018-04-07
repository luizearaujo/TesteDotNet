using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace TesteDotNet.Core2_0.Repositories.Base
{
    public class Repository
    {
        private string _connectionString;
        public IDbConnection Db {
            get {

                if (_connectionString.Contains("%CONTENTROOTPATH%"))
                {
                    _connectionString = _connectionString.Replace("%CONTENTROOTPATH%", Directory.GetCurrentDirectory());
                }

                return new SqlConnection(_connectionString);
            }
        }

        public Repository(IConfiguration conf)
        {
            _connectionString = conf.GetConnectionString("DefaultConnection");
        }

    }
}
