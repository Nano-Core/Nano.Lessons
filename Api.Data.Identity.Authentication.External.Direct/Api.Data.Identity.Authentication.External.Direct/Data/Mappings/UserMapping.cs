using System;
using Api.Data.Identity.Authentication.External.Direct.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings.Identity;

namespace Api.Data.Identity.Authentication.External.Direct.Data.Mappings;

/// <inheritdoc />
public class UserMapping : BaseEntityUserMapping<User>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        base.Configure(builder);

        builder
            .Property(x => x.Name)
            .HasMaxLength(128)
            .IsRequired();
    }
}