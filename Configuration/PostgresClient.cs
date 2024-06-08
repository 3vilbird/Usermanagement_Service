using Microsoft.Extensions.Options;
using Npgsql;

namespace UsermanagementService.Configuration
{
    public class PostgresClient : IPostgresClient
    {
        readonly object Lock = new();
        NpgsqlDataSource DataSource { get; set; }

        public PostgresClient(IOptions<PostgresClientOptions> configurationOptions)
        {
            DataSource = NpgsqlDataSource.Create(new NpgsqlConnectionStringBuilder
            {

                Host = configurationOptions.Value.Host,
                //Port = configurationOptions.Value.Port,                
                Username = configurationOptions.Value.Username,
                Password = configurationOptions.Value.Password,
                Database = configurationOptions.Value.DatabaseName
            });

        }

        public async Task ReadData(string query, Action<NpgsqlDataReader> callBack)
        {
            //add the exception handling

            await using (var cmd = DataSource.CreateCommand(query))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {

                    callBack(reader);
                }
            }
        }

    }
}