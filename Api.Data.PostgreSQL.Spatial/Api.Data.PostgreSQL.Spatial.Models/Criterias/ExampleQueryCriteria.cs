using System.Collections.Generic;
using System.Linq;
using DynamicExpression;
using Nano.App.Api.Controllers.Criteria;
using NetTopologySuite.Geometries;

namespace Api.Data.PostgreSQL.Spatial.Models.Criterias;

/// <inheritdoc />
public class ExampleQueryCriteria : BaseQueryCriteria
{
    /// <summary>
    /// Point.
    /// </summary>
    public virtual Point? Point { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    public virtual string? Name { get; set; }

    /// <inheritdoc />
    public override IList<CriteriaExpression> GetExpressions()
    {
        var expressions = base.GetExpressions();

        var expression = expressions.FirstOrDefault() ?? new CriteriaExpression();

        if (this.Point != null)
        {
            expression
                .IsWithinDistance(nameof(Example.Point), this.Point, 10000);
        }

        if (!string.IsNullOrEmpty(this.Name))
        {
            expression
                .StartsWith(nameof(Example.Name), this.Name);
        }

        expressions
            .Add(expression);

        return expressions;
    }
}