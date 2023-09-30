using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace App.Api.AppScope.Swaggers
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerDefinitionConvention : IControllerModelConvention
    {
        public static readonly string FeatureName = "feature";
        public static readonly string ManagementName = "management";


        /// <inheritdoc />
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller?.ControllerType?.Namespace;

            if (controllerNamespace == null)
            {
                return;
            }

            // we could add version attribute later... and so on,
            // or by attr first the fallback to default groups
            controller.ApiExplorer.GroupName = controllerNamespace.Contains(".Management")
                ? ManagementName
                : FeatureName;
        }
    }
}
