using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoard.Infrastructure.DbConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.Account)
                .WithOne(acc => acc.User)
                .HasForeignKey<User>(a => a.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
