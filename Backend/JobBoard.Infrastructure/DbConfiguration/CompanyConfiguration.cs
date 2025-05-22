using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoard.Infrastructure.DbConfiguration
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasOne(c => c.Account)
                .WithOne(acc => acc.Company)
                .HasForeignKey<Company>(a => a.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
