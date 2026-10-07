using System;
using System.Linq.Expressions;
using Api.Data.MySql.Mappings.Models.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.MySql.Mappings.Data.Mappings.Extensions;

/// <summary>
/// Owned Navigation Builder Extensions.
/// </summary>
public static class OwnedNavigationBuilderExtensions
{
    internal static void MapType<TEntity, TRelatedEntity>(this OwnedNavigationBuilder<TEntity, TRelatedEntity> builder, Expression<Func<TRelatedEntity, ProfilePicture?>> expression)
        where TEntity : class
        where TRelatedEntity : class
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        if (expression == null)
            throw new ArgumentNullException(nameof(expression));

        builder
            .OwnsOne(expression)
            .Property(x => x.Id)
            .IsRequired();

        builder
            .OwnsOne(expression)
            .Property(x => x.Path);
    }

    internal static void MapType<TEntity, TRelatedEntity>(this OwnedNavigationBuilder<TEntity, TRelatedEntity> builder, Expression<Func<TRelatedEntity, ProfileSettings?>> expression)
        where TEntity : class
        where TRelatedEntity : class
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        if (expression == null)
            throw new ArgumentNullException(nameof(expression));

        builder
            .OwnsOne(expression)
            .Property(x => x.UseDarkMode)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .OwnsOne(expression)
            .Property(x => x.HideProfileName)
            .HasDefaultValue(false)
            .IsRequired();
    }
}