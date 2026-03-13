using System;
using System.Linq.Expressions;
using Api.Data.MySql.Mappings.Models.Types;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Abstractions.Models.Abstractions;

namespace Api.Data.MySql.Mappings.Data.Mappings.Extensions;

/// <summary>
/// Entity Type Builder Extensions.
/// </summary>
public static class EntityTypeBuilderExtensions
{
    /// <summary>
    /// Maps <see cref="Profile"/> as owned by the entity.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="builder">The <see cref="EntityTypeBuilder{TEntity}"/>.</param>
    /// <param name="expression">The property expression.</param>
    public static void MapType<TEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, Profile?>> expression)
        where TEntity : class, IEntity
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        if (expression == null)
            throw new ArgumentNullException(nameof(expression));

        builder
            .OwnsOne(expression)
            .Property(x => x.Text);

        builder
            .OwnsOne(expression)
            .MapType(x => x.Picture);

        builder
            .OwnsOne(expression)
            .MapType(x => x.Settings);
    }
}