using System;

namespace App.Application.Common.Attributes.Support
{
    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SymbolizedLikeQuerySupportAttribute : ApiPropertyDecorationAttribute
    {
        public override string Hint => "Support like query: \\*tex\\*t\\*";
    }
}
