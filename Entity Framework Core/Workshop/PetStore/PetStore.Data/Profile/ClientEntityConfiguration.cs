using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Common;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Data.Profile
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .Property(c => c.Username)
                .HasMaxLength(GlobalConstants.ClientUsernameMaxLength)
                .IsUnicode(true);

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(GlobalConstants.ClientFirstNameMaxLength)
                .IsUnicode(true);

            builder
                .Property(c => c.SecondName)
                .HasMaxLength(GlobalConstants.ClientSecondNameMaxLength)
                .IsUnicode(true);
        }
    }
}
