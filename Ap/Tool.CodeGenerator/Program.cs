using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using CommandLine;
using Tool.CodeGenerator.Data.Dtos;
using Tool.CodeGenerator.Services;

namespace Tool.CodeGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ArgOptions>(args)
               .WithParsed(
                    o =>
                    {
                        var processorType = Assembly
                           .GetExecutingAssembly()
                           .GetExportedTypes()
                           .Where(e => typeof(IProcessor).IsAssignableFrom(e))
                           .First(t => t.Name.ToLower().StartsWith(o.Template));

                        if (!o.AlwaysYes)
                        {
                            Console.WriteLine($"Do you really want to run the processor :{processorType.Name}? Y/N");

                            var agree = (Console.ReadLine() ?? string.Empty).Equals(
                                "y",
                                StringComparison.InvariantCultureIgnoreCase
                            );

                            if (!agree)
                            {
                                Console.WriteLine("Nothing to do... bye");

                                return;
                            }
                        }

                        var watcher = new Stopwatch();

                        watcher.Start();

                        var processor = (IProcessor) Activator.CreateInstance(processorType);

                        if (null == processor)
                        {
                            throw new Exception("Active processor failed!");
                        }

                        processor.Execute(o);

                        watcher.Stop();

                        Console.WriteLine($"completed! TimeElapsed : {watcher.Elapsed.TotalMilliseconds:F3}(ms)");
                    }
                );
        }
    }
}
