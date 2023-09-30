#pragma warning disable CS1591

using App.Application.Common.Dtos;
using App.Domain.Entities;

namespace App.Application.Common.Constants
{
    /// <summary>
    /// </summary>
    public static class CommonSortProperty
    {
        public static SortProperty CreatedAtAscending => new SortProperty
        {
            PropertyName = nameof(EntityBase.DateCreate),
            SortOrder = SortOrder.Asc
        };

        public static SortProperty CreatedAtDescending => new SortProperty
        {
            PropertyName = nameof(EntityBase.DateCreate),
            SortOrder = SortOrder.Desc
        };

        public static SortProperty ModifiedAtAscending => new SortProperty
        {
            PropertyName = nameof(EntityBase.DateUpdate),
            SortOrder = SortOrder.Asc
        };

        public static SortProperty ModifiedAtDescending => new SortProperty
        {
            PropertyName = nameof(EntityBase.DateUpdate),
            SortOrder = SortOrder.Desc
        };
    }
}
