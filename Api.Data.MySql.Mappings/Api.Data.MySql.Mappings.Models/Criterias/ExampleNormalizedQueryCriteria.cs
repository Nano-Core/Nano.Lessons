using System.Collections.Generic;
using System.Linq;
using DynamicExpression;
using Nano.App.Api.Controllers.Criteria;

namespace Api.Data.MySql.Mappings.Models.Criterias;

/// <inheritdoc />
public class ExampleNormalizedQueryCriteria : BaseQueryCriteria
{
    /// <summary>
    /// Full Name.
    /// </summary>
    public virtual string? FullName { get; set; }

    /// <inheritdoc />
    public override IList<CriteriaExpression> GetExpressions()
    {
        var expressions = base.GetExpressions();

        var expression = expressions.FirstOrDefault() ?? new CriteriaExpression();

        if (!string.IsNullOrEmpty(this.FullName))
        {
            expression
                .StartsWith(nameof(ExampleNormalized.FullNameNormalized), this.FullName.ToUpper());
        }

        expressions
            .Add(expression);

        return expressions;
    }
}