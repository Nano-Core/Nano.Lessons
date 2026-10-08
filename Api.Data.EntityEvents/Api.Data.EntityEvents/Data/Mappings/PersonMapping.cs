using System;
using Api.Data.EntityEvents.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Data.Mappings;

/// <inheritdoc />
public class PersonMapping : BaseEntityMapping<Person>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<Person> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.Identitifer)
            .IsRequired()
            .IsRequired();
    }
}