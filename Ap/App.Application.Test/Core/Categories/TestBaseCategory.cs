#region

using NUnit.Framework;

#endregion

namespace App.Application.Test.Core.Categories
{
    public class TestBaseCategory : CategoryAttribute
    {
        public TestBaseCategory() : base(nameof(TestBaseCategory))
        {
        }
    }
}
