using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace DashboardAbast.Server.Extensions.NoLockExtension
{
    #pragma warning disable EF1001 // Internal EF Core API usage.
    /// <summary>
    /// A factory for the <see cref="WithNolockQuerySqlGenerator"/> class.
    /// </summary>
    public class WithNolockQuerySqlGeneratorFactory : SqlServerQuerySqlGeneratorFactory
    #pragma warning restore EF1001 // Internal EF Core API usage.
    {
		private readonly QuerySqlGeneratorDependencies dependencies;

		/// <summary>
		/// Initializes a new instance of the <see cref="WithNolockQuerySqlGeneratorFactory"/> class.
		/// </summary>
		/// <param name="dependencies">The dependencies for this <see cref="WithNolockQuerySqlGeneratorFactory"/>.</param>
		public WithNolockQuerySqlGeneratorFactory(QuerySqlGeneratorDependencies dependencies)
			: base(dependencies)
		{
			this.dependencies = dependencies;
		}

		/// <summary>
		/// Creates a default <see cref="WithNolockQuerySqlGenerator"/>.
		/// </summary>
		/// <returns>The created <see cref="WithNolockQuerySqlGenerator"/>.</returns>
		public override QuerySqlGenerator Create()
		{
			return new WithNolockQuerySqlGenerator(this.dependencies);
		}
	}
}
