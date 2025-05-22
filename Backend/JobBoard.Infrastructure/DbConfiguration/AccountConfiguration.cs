using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoard.Infrastructure.DbConfiguration;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account")
            .HasDiscriminator<string>("AccountType")
            .HasValue<User>("User")
            .HasValue<Company>("Company")
            .HasValue<Admin>("Admin");
    }
}