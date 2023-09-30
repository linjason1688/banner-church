#region

using NUnit.Framework;

#endregion

namespace App.Application.Test.Core.Categories
{
    public class TestBusinessLogicCategory : CategoryAttribute
    {
        public TestBusinessLogicCategory() : base(nameof(TestBusinessLogicCategory))
        {
        }
    }
}
