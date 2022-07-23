using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity.ModelConfiguration;
using Vidly.Core.Domain;

namespace Vidly.EntityTypeConfigurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.ReleaseDate)
                .HasColumnType("date");

            Property(m => m.DateAdded)
                .HasColumnType("Date");


            //Property(m => m.NumberInStock)
            //    .IsRequired();

        }
    }
}