namespace MyCoolCarSystem.Data.Queries
{
    using Microsoft.EntityFrameworkCore;
    using MyCoolCarSystem.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarQueries
    {
        public static Func<CarDbContext, int, IEnumerable<ResultModel>> ToResult
            = EF.CompileQuery<CarDbContext, int, IEnumerable<ResultModel>>(
                (db, price) => db
            .Cars
            .Where(x => x.Price > price)
                .Where(x => x.Owners.Any(x => x.Customer.LastName == null))
                .Select(x => new ResultModel
                {
                    Count = x.Owners.Count(x => x.Customer.Purchases.Count > 1)
                }));
    }
}
