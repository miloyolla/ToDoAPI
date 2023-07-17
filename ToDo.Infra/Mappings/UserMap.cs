using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDo.Infra.Mappings
{

    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.HasKey("Id");

            builder.Property(u => u.Username)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(u => u.PasswordSalt)
            .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.HasMany(u => u.Tarefas)
                   .WithOne(t => t.User);
        }
    }
}
