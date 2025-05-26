using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoard.Infrastructure.DbConfiguration;

internal class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasOne(ja => ja.JobVacancy)
            .WithMany(jv => jv.JobApplications)
            .OnDelete(DeleteBehavior.Restrict);
    }
}