using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlogApp.Domain.Entities;

namespace SimpleBlogApp.Infra.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(name: nameof(Post));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(36)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Title).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Date).IsRequired();

        }
    }
}
