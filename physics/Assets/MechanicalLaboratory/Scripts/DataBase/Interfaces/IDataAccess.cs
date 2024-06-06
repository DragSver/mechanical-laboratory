using System.Threading.Tasks;
using Mono.Data.Sqlite;

namespace MechanicalLaboratory.Scripts.DataBase.Interfaces
{
    public interface IDataAccess
    {
        public Task<SqliteCommand> CreateCommand(string sqlCommand);
    }
}