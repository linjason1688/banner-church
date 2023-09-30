using System;

namespace App.Application.Common.Attributes.Support
{
    /// <summary>
    /// </summary>
    public abstract class ApiPropertyDecorationAttribute : Attribute
    {
        public virtual string Hint { get; }
    }
}
