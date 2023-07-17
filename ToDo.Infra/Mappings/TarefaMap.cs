using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Infra.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.HasKey("Id");

            builder.Property(t => t.Nome)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(t => t.StatusId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne<User>(t => t.User)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(t => t.UserId);
        }
    }
}
