using System.Linq;
using App.Domain.Entities.Queries;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence
{
    /// <summary>
    /// </summary>
    public partial class AppDbContext
    {
        private void ConfigQueries(ModelBuilder modelBuilder)
        {
        }
#pragma warning disable 414
        private static string defaultSequenceSchema = "shared";

        public IQueryable<DummyQuery> DummyQuery { get; }
#pragma warning restore 414
    }
}
