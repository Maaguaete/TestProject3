using Microsoft.Data.SqlClient;

namespace WebAPI.Data
{
    public class Connection
    {
        private readonly SqlConnection connection;
        private readonly string connectionString;
        private static Connection? _connection;
        private Connection()
        {
            connectionString = new ConfigurationBuilder()
                                .AddJsonFile(Path
                                    .Combine(Directory
                                    .GetCurrentDirectory()
                                    , "appsettings.json"))
                                .Build().GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
        }
        public static Connection Instance
        {
            get { return _connection ??= new Connection(); }
        }
        public SqlConnection Get()
        {
            return connection;
        }
    }
}
