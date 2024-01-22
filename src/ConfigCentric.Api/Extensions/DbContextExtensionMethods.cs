using ConfigCentric.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfigCentric.Api.Extensions;

public static class DbContextExtensionMethods
{
    public async static Task<TResult> FindModelAsync<TResult>(this IQueryable<TResult> queryable, Guid id)
        where TResult : Entity
    {
        var result = await queryable.FirstOrDefaultAsync(x => x.Id == id) ??
             throw new Exception($"{typeof(TResult).Name} with id: {id} not found.");
        return result;
    }
    
}
