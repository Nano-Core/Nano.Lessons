using DynamicExpression;
using Nano.App.Api.Controllers.Criteria;
using System.Collections.Generic;
using System.Linq;

namespace Api.Data.Identity.Models.Criterias;

/// <inheritdoc />
public class UserQueryCriteria : BaseQueryCriteria
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
                .StartsWith(nameof(User.Name), this.Name);
        }

        expressions
            .Add(expression);

        return expressions;
    }
}