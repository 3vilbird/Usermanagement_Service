namespace OrderSeervice.Configuration
{
    public class PostgresClientOptions
    {
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public string DatabaseName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}