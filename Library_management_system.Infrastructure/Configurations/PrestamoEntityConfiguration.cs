using Library_management_system.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Infrastructure.Configurations
{
    internal class PrestamoEntityConfiguration:IEntityTypeConfiguration<PrestamoEntity>
    {
        public void Configure(EntityTypeBuilder<PrestamoEntity> builder)
        {
            builder.ToTable("Prestamo");
            builder.HasKey(e => e.IdPrestamo);
            //builder.HasOne(e => e.IdPrestamo)
            //   .WithOne(u => u.IdPrestamo)
            //   .HasForeignKey<PrestamoEntity>(e => e.IdPrestamo);
            //builder.Property(e => e.Usuario).IsRequired().HasMaxLength(20);
            // Otras configuraciones de la entidad.
        }
    }

}
