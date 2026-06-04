using System;
using Api.Data.Audit.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.Audit.Data.Mappings;

/// <summary>
/// Example  Mapping.
/// </summary>
public class ExampleNoAuditMapping : BaseEntityMapping<ExampleNoAudit>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleNoAudit> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name);
    }
}