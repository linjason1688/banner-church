using System.Linq;
using App.Domain.Entities.Queries;

namespace App.Application.Common.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IAppDbContext
    {
        #region Query

        IQueryable<DummyQuery> DummyQuery { get; }

        #endregion
    }
}
