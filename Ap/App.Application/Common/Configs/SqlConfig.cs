namespace App.Application.Common.Configs
{
    public enum AppSqlProvider
    {
        InMemory,
        MSSQL,
        MYSQL,
        MariaDB
    }

    public class SqlConfig
    {
        public AppSqlProvider Provider { get; set; }

        public string Connection { get; set; }
    }
}
