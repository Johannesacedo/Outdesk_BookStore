using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Specifications.Interface
{
    public interface ISpecification<T>
    {
        //Generic Methods
        Expression<Func<T, bool>> Criteria { get; }   
        List<Expression<Func<T, object>>> Includes { get; }

        //Sorting
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        //pagination
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
