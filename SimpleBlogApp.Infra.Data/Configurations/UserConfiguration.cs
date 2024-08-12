using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlogApp.Domain.Entities;

namespace SimpleBlogApp.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.SecondName).HasMaxLength(150).IsRequired();


            builder.HasMany(x => x.Posts)
                .WithOne(b => b.User)
                .HasForeignKey(e => e.UserId)
                .HasPrincipalKey(e => e.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
