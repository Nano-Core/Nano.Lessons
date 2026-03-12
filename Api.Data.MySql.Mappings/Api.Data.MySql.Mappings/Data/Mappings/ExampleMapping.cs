using Api.Data.MySql.Mappings.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Abstractions.Models.Abstractions;
using Nano.Data.Mappings;
using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Api.Data.MySql.Mappings.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class ExampleMapping : BaseEntityMapping<Example>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Example> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.NameNormalized)
            .IsUnique();


        // Map the Data property as JSON
        builder
            .Property(e => e.Data)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),   // Object → JSON string
                v => JsonConvert.DeserializeObject<MyComplexType>(v) ?? new MyComplexType() // JSON string → Object
            )
            .HasColumnType("json") // or "text" for MySQL
            .IsRequired();

    }
}

/// <summary>
/// Entity Type Builder Extensions.
/// </summary>
public static class EntityTypeBuilderExtensions
{
    /// <summary>
    /// Maps <see cref="Range"/> as owned by the entity.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="builder">The <see cref="EntityTypeBuilder{TEntity}"/>.</param>
    /// <param name="expression">The property expression.</param>
    public static void MapType<TEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, Range>> expression)
        where TEntity : class, IEntity
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        if (expression == null)
            throw new ArgumentNullException(nameof(expression));

        builder
            .OwnsOne(expression)
            .Property(x => x.Min)
            .HasDefaultValue(0)
            .IsRequired();

        builder
            .OwnsOne(expression)
            .Property(x => x.Max)
            .HasDefaultValue(0)
            .IsRequired();

        builder
            .OwnsOne(expression)
            .HasIndex(x => new
            {
                x.Min,
                x.Max
            });
    }
}


/// <summary>
/// Owned Navigation Builder Extensions.
/// </summary>
public static class OwnedNavigationBuilderExtensions
{
    /// <summary>
    /// Maps <see cref="Recurrence"/> for the <typeparamref name="TRelatedEntity"/> owned by <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TRelatedEntity">The related entity type.</typeparam>
    /// <param name="builder">The <see cref="OwnedNavigationBuilder{TEntity,TRelatedEntity}"/>.</param>
    /// <param name="expression">The <see cref="Expression"/>.</param>
    public static void MapType<TEntity, TRelatedEntity>(this OwnedNavigationBuilder<TEntity, TRelatedEntity> builder, Expression<Func<TRelatedEntity, Recurrence>> expression)
        where TEntity : class
        where TRelatedEntity : class
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        if (expression == null)
            throw new ArgumentNullException(nameof(expression));

        builder
            .OwnsOne(expression)
            .Property(x => x.Frequency)
            .HasDefaultValue(RecurrenceFrequency.None)
            .IsRequired();

        builder
            .OwnsOne(expression)
            .Property(x => x.Interval)
            .HasDefaultValue(1)
            .IsRequired();

        builder
            .OwnsOne(expression)
            .Property(x => x.DayOfWeek);
    }
}