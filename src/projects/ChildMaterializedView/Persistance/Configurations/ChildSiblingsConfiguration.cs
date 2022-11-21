using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class ChildSiblingsConfiguration : IEntityTypeConfiguration<ChildSiblings>
    {
        public void Configure(EntityTypeBuilder<ChildSiblings> builder)
        {
            builder.ToTable("ChildSiblings").HasKey(p => p.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedNever();
            builder.Property(x => x.ChildId).HasColumnName("ChildId");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.Age).HasColumnName("Age");
            builder.Property(x => x.EducationStatusId).HasColumnName("EducationStatusId");
            builder.Property(x => x.Job).HasColumnName("Job");
            builder.HasOne(x => x.Child);
        }
    }
}
