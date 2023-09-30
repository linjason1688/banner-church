using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tool.CodeGenerator.Data.Dtos;
using Yozian.Extension;

namespace Tool.CodeGenerator.Services.Impl
{
    /// <summary>
    /// </summary>
    public class CqrsProcessor : IProcessor
    {
        public Task Execute(ArgOptions option)
        {
            // create tmp folder
            var root = AppDomain.CurrentDomain.BaseDirectory;
            var tmp = Path.Join(root, ".temp-code-gen");

            var resourceFolder = Path.Join(root, "Resources");

            var templateFolder = Path.Join(resourceFolder, "cqrs");

            var target = "Target";
            var feature = "Feature";

            var destinationRoot = Path.Join(tmp, $"cqrs-{option.FeatureName}");

            //
            var layers = option.OutputFolder
               .Replace("App.Application", string.Empty)
               .Replace("\\", "/")
               .Split("/", StringSplitOptions.RemoveEmptyEntries)
               .Where(x => x != option.FeatureName)
               .FlattenToString(".");

            if (!string.IsNullOrEmpty(layers))
            {
                layers += ".";
            }

            Directory.GetDirectories(templateFolder, "*", SearchOption.AllDirectories)
               .ForEach(
                    directory =>
                    {
                        var di = new DirectoryInfo(directory);

                        var destinationFolder = Path.Join(
                            destinationRoot,
                            directory
                               .Replace(templateFolder, "")
                               .Replace(feature, option.FeatureName)
                               .Replace(target, option.TargetName)
                        );

                        var workDirectory = Directory.CreateDirectory(destinationFolder);

                        Directory.GetFiles(di.FullName, "*.cs")
                           .ForEach(
                                f =>
                                {
                                    var fi = new FileInfo(f);

                                    var content = File.ReadAllText(fi.FullName);

                                    content = content
                                       .Replace($"${target}$", option.TargetName)
                                       .Replace($"${feature}$", option.FeatureName)
                                       .Replace("$BaseNamespace$", layers);

                                    File.WriteAllText(
                                        Path.Join(
                                            workDirectory.FullName,
                                            fi.Name.Replace(target, option.TargetName)
                                        ),
                                        content
                                    );
                                }
                            );
                    }
                );

            // 將產出檔 copy 

            var finalDestination = Path.Join(Directory.GetCurrentDirectory(), option.OutputFolder);

            Directory.Move(Path.Join(destinationRoot, option.FeatureName), finalDestination);

            return Task.CompletedTask;
        }
    }
}
