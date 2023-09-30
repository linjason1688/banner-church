using System;

namespace App.Utility.Attributes
{
    /// <summary>
    /// </summary>
    public class HashProperty : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 當值為 null 時之 替換值
        /// </summary>
        public object NullAlternateValue { get; set; }

        public HashProperty(string name, object nullAlternateValue = null)
        {
            this.Name = name;
            this.NullAlternateValue = nullAlternateValue;
        }
    }
}
