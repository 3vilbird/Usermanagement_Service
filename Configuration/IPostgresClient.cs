using Npgsql;

namespace OrderSeervice.Configuration
{
    public interface IPostgresClient
    {
        public void ReadData(string query, Action<NpgsqlDataReader> callBack);
    }
}