//=================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//=================================

using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker:EFxceptionsContext,IStorageBroker
    {
        public readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
        public override void Dispose()
        {}
    }
}
