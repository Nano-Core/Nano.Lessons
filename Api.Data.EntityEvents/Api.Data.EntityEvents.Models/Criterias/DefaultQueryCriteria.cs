using System.Collections.Generic;
using DynamicExpression;
using Nano.App.Api.Controllers.Criteria;

namespace Api.Data.EntityEvents.Models.Criterias;

/// <inheritdoc />
public class DefaultQueryCriteria : BaseQueryCriteria
{
    /// <inheritdoc />
    public override IList<CriteriaExpression> GetExpressions()
    {
        var expressions = base.GetExpressions();

        return expressions;
    }
}