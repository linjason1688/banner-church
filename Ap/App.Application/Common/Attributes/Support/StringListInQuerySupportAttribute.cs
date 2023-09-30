using System;

namespace App.Application.Common.Attributes.Support
{
    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StringListInQuerySupportAttribute : ApiPropertyDecorationAttribute
    {
        public override string Hint => "Support string list query: \"a,b,c\"";
    }
}
