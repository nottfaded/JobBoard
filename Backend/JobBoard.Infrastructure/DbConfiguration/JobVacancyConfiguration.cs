using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoard.Infrastructure.DbConfiguration;

internal class JobVacancyConfiguration : IEntityTypeConfiguration<JobVacancy>
{
    public void Configure(EntityTypeBuilder<JobVacancy> builder)
    {
        builder.Property(j => j.SalaryType)
            .HasConversion<string>();

        builder.HasOne(jv => jv.Company)
            .WithMany(c => c.JobVacancies)
            .OnDelete(DeleteBehavior.Restrict);
    }
}