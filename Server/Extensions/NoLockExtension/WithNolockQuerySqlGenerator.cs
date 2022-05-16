using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Linq.Expressions;

namespace DashboardAbast.Server.Extensions.NoLockExtension
{
    #pragma warning disable EF1001 // Internal EF Core API usage.
    public class WithNolockQuerySqlGenerator : SqlServerQuerySqlGenerator
    #pragma warning restore EF1001 // Internal EF Core API usage.
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WithNolockQuerySqlGenerator"/> class.
        /// </summary>
        /// <param name="dependencies">The dependencies for this <see cref="WithNolockQuerySqlGenerator"/>.</param>
        public WithNolockQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies)
        : base(dependencies)
        {
        }

        protected override Expression VisitTable(TableExpression tableExpression)
        {
            var expression = base.VisitTable(tableExpression);

            this.Sql.Append(@" WITH(NOLOCK)");

            return expression;
        }
    }
}
