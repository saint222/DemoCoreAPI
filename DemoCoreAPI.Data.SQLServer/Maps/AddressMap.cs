using DemoCoreAPI.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.Data.SQLServer.Maps
{
    internal class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(t => t.District)
                   .IsRequired()
                   .HasMaxLength(400); // from practical perspective use 400, to avoid issues
            builder.Property(t => t.Locality)
                   .IsRequired()
                   .HasMaxLength(400);
            builder.Property(t => t.Street)
                   .IsRequired()
                   .HasMaxLength(400);
            builder.Property(t => t.HouseNumber)
                   .IsRequired()
                   .HasMaxLength(400);
        }
    }
}
