using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoard.Infrastructure.DbConfiguration
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasOne(a => a.Account)
                .WithOne(acc => acc.Admin)
                .HasForeignKey<Admin>(a => a.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
