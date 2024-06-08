using Npgsql;

namespace UsermanagementService.Configuration
{
    public interface IPostgresClient
    {
        public Task ReadData(string query, Action<NpgsqlDataReader> callBack);
    }
}