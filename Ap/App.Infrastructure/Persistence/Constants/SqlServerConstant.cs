namespace App.Infrastructure.Persistence.Constants
{
    /// <summary>
    /// </summary>
    public class SqlServerConstant : SqlConstant
    {
        public override string DefaultGuid => "NEWID()";

        public override string DefaultDate => "GETDATE()";
    }
}
