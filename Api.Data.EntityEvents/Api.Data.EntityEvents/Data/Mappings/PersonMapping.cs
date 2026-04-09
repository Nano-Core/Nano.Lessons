using System;
using Api.Data.EntityEvents.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Data.Mappings;

/// <inheritdoc />
public class PersonMapping : BaseEntityMapping<Person>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Identitifer)
            .IsRequired()
            .IsRequired();
    }
}