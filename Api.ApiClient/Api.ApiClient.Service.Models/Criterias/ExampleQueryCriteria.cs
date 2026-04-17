using System.Collections.Generic;
using System.Linq;
using DynamicExpression;
using Nano.App.Api.Controllers.Criteria;

namespace Api.ApiClient.Service.Models.Criterias;

/// <inheritdoc />
public class ExampleQueryCriteria : BaseQueryCriteria
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string? Name { get; set; }

    /// <inheritdoc />
    public override IList<CriteriaExpression> GetExpressions()
    {
        var expressions = base.GetExpressions();

        var expression = expressions.FirstOrDefault() ?? new CriteriaExpression();

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