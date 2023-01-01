using System.Data;
using Dapper;

namespace AviaSales.Application.Common.Extensions;

internal static class DbConnectionExtensions
{
    internal static async Task<bool> IsEntityExistsAsync<TKey>(this IDbConnection dbConnection, string tableName, TKey primaryKey)
        where TKey : IEquatable<TKey>
    {
        var query = $"SELECT * from {tableName} " +
                          $"WHERE {tableName}.id = @id " +
                           "LIMIT 1";

        var entity = await dbConnection.QueryFirstOrDefaultAsync<object>(query, new { id = primaryKey });

        return entity is not null;
    }
}