#region

using NUnit.Framework;

#endregion

namespace App.Application.Test.Core.Categories
{
    /// <summary>
    /// 
    /// </summary>
    public class TestDbContext : CategoryAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public TestDbContext() : base(nameof(TestDbContext))
        {
        }
    }
}
