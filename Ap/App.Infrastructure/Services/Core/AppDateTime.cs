using System;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces.Services.Core;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Core
{
    /// <summary>
    /// </summary>
    [SingletonService(typeof(IDateTime))]
    public class AppDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime TheEndOfTheWorld => EntityExtension.TheEndOfTheWorld;
    }
}
