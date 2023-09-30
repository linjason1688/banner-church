#region

using System;
using Newtonsoft.Json.Serialization;

#endregion

namespace App.Utility.Json
{
    /// <summary>
    /// ref: https://stackoverflow.com/questions/24143149/keep-casing-when-serializing-dictionaries
    /// </summary>
    public class MyCamelCaseResolver : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// keep the case sensitive for dictionary
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var contract = base.CreateDictionaryContract(objectType);

            contract.DictionaryKeyResolver = propertyName => propertyName;

            return contract;
        }
    }
}
