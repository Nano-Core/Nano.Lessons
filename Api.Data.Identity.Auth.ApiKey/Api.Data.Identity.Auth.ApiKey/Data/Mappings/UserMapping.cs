using System;
using Api.Data.Identity.Auth.ApiKey.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings.Identity;

namespace Api.Data.Identity.Auth.ApiKey.Data.Mappings;

/// <inheritdoc />
public class UserMapping : BaseEntityUserMapping<User>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        builder
            .Property(x => x.Name)
            .HasMaxLength(128)
            .IsRequired();
    }
}