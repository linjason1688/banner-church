using CommandLine;

namespace Tool.CodeGenerator.Data.Dtos
{
    /// <summary>
    /// </summary>
    public class ArgOptions
    {
        [Option('t', "template", Required = true, HelpText = "specify the template name in the resources")]
        public string Template { get; set; }


        [Option('e', "feature", Required = true, HelpText = "specify the feature name")]
        public string FeatureName { get; set; }

        [Option('n', "name", Required = true, HelpText = "specify the class name")]
        public string TargetName { get; set; }

        [Option('o', "output", Required = true, HelpText = "specify the output folder path")]
        public string OutputFolder { get; set; }

        [Option('y', "yes", Required = false, HelpText = "always answer yes", Default = false)]
        public bool AlwaysYes { get; set; }
    }
}
