using System.Linq.Expressions;
namespace Assignment9_API_2.Common;

public static class LinqExtensions
{
    public static Func<T, bool> Not<T>(this Func<T, bool> predicate)
    {
        return a => !predicate(a);
    }
    public static Func<T, bool> And<T>(this Func<T, bool> left, Func<T, bool> right)
    {
        return a => left(a) && right(a);
    }
    public static Func<T, bool> Or<T>(this Func<T, bool> left, Func<T, bool> right)
    {
        return a => left(a) || right(a);
    }
}