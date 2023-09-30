using System.Collections;
using System.Collections.Generic;

namespace App.Application.Common.Dtos
{
    /// <summary>
    /// </summary>
    public interface IDynamicSortable
    {
        public List<SortProperty> SortProperties { get; set; }
    }

    public enum SortOrder
    {
        None,
        Asc,
        Desc
    }

    public class SortProperty : IEqualityComparer
    {
        public string PropertyName { get; set; }

        public SortOrder SortOrder { get; set; }

        new public bool Equals(object x, object y)
        {
            return ((SortProperty) x).PropertyName == ((SortProperty) y).PropertyName;
        }

        public int GetHashCode(object obj)
        {
            return base.GetHashCode();
        }
    }
}
