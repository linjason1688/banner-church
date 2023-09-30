namespace App.Infrastructure.Persistence.Constants
{
    public abstract class SqlConstant
    {
        public abstract string DefaultGuid { get; }

        public abstract string DefaultDate { get; }

        public static SqlConstant GetActiveSqlConstant()
        {
            // return new MySqlConstant();
            return new SqlServerConstant();
        }
    }
}
