using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using socialNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.TypeConfigurations
{
    public class EmoticonEntityTypeConfiguration : IEntityTypeConfiguration<Emoticon>
    {
        public void Configure(EntityTypeBuilder<Emoticon> builder)
        {

        }
    }
}
