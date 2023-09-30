#region

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Infrastructure.Persistence;
using App.Infrastructure.Supports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.DevSupports.Sql
{
    [TransientService(typeof(IDevSupport))]
    public class SqlScriptSupport : DevSupportBase, IDevSupport
    {
        private readonly AppDbContext appDbContext;
        private readonly ILogger logger;

        public SqlScriptSupport(
            AppDbContext appDbContext,
            ILogger<SqlScriptSupport> logger
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }


        /// <inheritdoc />
        public async Task Process(Dictionary<string, object> options, CancellationToken cancellationToken = default)
        {
            if (this.appDbContext.Database.IsInMemory())
            {
                return;
            }

            var databaseSql = this.appDbContext.Database.GenerateCreateScript();

            var appliedMigrations = await this.appDbContext.Database.GetAppliedMigrationsAsync(cancellationToken);
            var pendingMigrations =
                (await this.appDbContext.Database.GetPendingMigrationsAsync(cancellationToken)).ToList();

            this.logger.LogInformation(
                "Last applied migration: {@AppliedMigration}",
                appliedMigrations.LastOrDefault()
            );

            if (pendingMigrations.Any())
            {
                this.logger.LogError("Pending migration: {@PendingMigrations}", string.Join(", ", pendingMigrations));
            }

            var devSrcFolder = Directory.GetCurrentDirectory();
            var filename = Path.Combine(devSrcFolder, "Resources", "database.sql");

            await File.WriteAllTextAsync(filename, databaseSql, cancellationToken);

            this.logger.LogInformation("Create database scripts path: {@Filename}", filename);
        }
    }
}
