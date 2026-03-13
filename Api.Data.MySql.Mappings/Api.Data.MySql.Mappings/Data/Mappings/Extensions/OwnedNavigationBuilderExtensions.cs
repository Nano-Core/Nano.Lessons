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
    /// <summary>
    /// Maps <see cref="ProfilePicture"/> for the <typeparamref name="TRelatedEntity"/> owned by <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TRelatedEntity">The related entity type.</typeparam>
    /// <param name="builder">The <see cref="OwnedNavigationBuilder{TEntity,TRelatedEntity}"/>.</param>
    /// <param name="expression">The <see cref="Expression"/>.</param>
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

    /// <summary>
    /// Maps <see cref="ProfileSettings"/> for the <typeparamref name="TRelatedEntity"/> owned by <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TRelatedEntity">The related entity type.</typeparam>
    /// <param name="builder">The <see cref="OwnedNavigationBuilder{TEntity,TRelatedEntity}"/>.</param>
    /// <param name="expression">The <see cref="Expression"/>.</param>
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