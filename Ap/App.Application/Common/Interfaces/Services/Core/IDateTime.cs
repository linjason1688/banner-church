using System;

namespace App.Application.Common.Interfaces.Services.Core
{
    /// <summary>
    /// </summary>
    public interface IDateTime
    {
        DateTime Now { get; }

        DateTime TheEndOfTheWorld { get; }
    }
}
