using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoard.Infrastructure.DbConfiguration
{
    internal class JobVacancyConfiguration : IEntityTypeConfiguration<JobVacancy>
    {
        public void Configure(EntityTypeBuilder<JobVacancy> builder)
        {
            builder.HasOne(jv => jv.Company)
                .WithMany(c => c.JobVacancies)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(jv => jv.SalaryType)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
