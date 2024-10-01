using Library_management_system.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Infrastructure.Configurations
{
    internal class LibroEntityConfiguration:IEntityTypeConfiguration<LibroEntity>
    {
        public void Configure(EntityTypeBuilder<LibroEntity> builder)
        {
            builder.ToTable("Libro");
            builder.HasKey(e => e.IdLibro);
        }
    }
}
