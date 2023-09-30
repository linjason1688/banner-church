using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.HouseKeepers
{
    [ScopedService]
    public class LogFileHousekeeper
    {
        private readonly Regex apLogFilenamePattern = new Regex(@"App.{1,}\d{10}.log");
        private readonly IHostEnvironment env;
        private readonly ILogger logger;
        private readonly Regex sqlLogFilenamePattern = new Regex(@"Executed-Cmd-\d{10}.log");

        public LogFileHousekeeper(
            ILogger<LogFileHousekeeper> logger,
            IHostEnvironment env
        )
        {
            this.env = env;
            this.logger = logger;
        }

        /// <summary>
        /// 清理 log 檔案
        /// </summary>
        /// <param name="date">該日期前之 log 檔案都會被清掉</param>
        /// <returns>總刪除筆數</returns>
        public Task<int> CleanupAsync(DateTime date)
        {
            // 路徑是固定的(無特別設定)
            var logFolder = Path.Combine(this.env.ContentRootPath, "Logs");

            // list all matched files
            var di = new DirectoryInfo(logFolder);

            var files = di.GetFiles("*.log", SearchOption.AllDirectories)
               .Where(x => x.LastWriteTime < date)

                // 確認 pattern 以免誤刪
               .Where(f => this.apLogFilenamePattern.IsMatch(f.Name) || this.sqlLogFilenamePattern.IsMatch(f.Name))
               .ToList();

            files.ForEach(
                fi =>
                {
                    this.logger.LogInformation(
                        "Remove for logfile: [{@Name}](LastWriteTime at {@LastWriteTime}) \nat ({@FullName})",
                        fi.Name,
                        fi.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"),
                        fi.FullName
                    );

                    fi.Delete();
                }
            );

            return Task.FromResult(files.Count);
        }
    }
}
