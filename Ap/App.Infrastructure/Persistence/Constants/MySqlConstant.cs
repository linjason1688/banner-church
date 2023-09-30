namespace App.Infrastructure.Persistence.Constants
{
    /// <summary>
    /// </summary>
    public class MySqlConstant : SqlConstant
    {
        public override string DefaultGuid => "UUID()";

        public override string DefaultDate => "NOW()";
    }
}
