namespace App.Api.AppScope.Swaggers.DescriptionProviders
{
    /// <summary>
    /// </summary>
    public class ExampleKeyProvider : IDescriptionProvider
    {
        public string Description
        {
            get
            {
                // var exampleTypes = new UserIdentity().GetType()
                //    .Assembly
                //    .GetExportedTypes()
                //    .Where(t => typeof(IExampleType).IsAssignableFrom(t))
                //    .Where(t => t.Name != nameof(IExampleType))
                //    .ToList();
                //
                // return string.Join(", ", exampleTypes.Select(t => t.Name));

                return string.Empty;
            }
        }
    }
}
