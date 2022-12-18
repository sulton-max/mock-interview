using System.Linq.Expressions;
using System.Reflection;
using MockInterview.DAL.Models.Query;

namespace MockInterview.DAL.Extensions;

/// <summary>
/// Provides extensions for type information
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Checks if type is simple
    /// </summary>
    /// <param name="type">Type to check</param>
    /// <returns>True if type is simple, otherwise false</returns>
    public static bool IsSimpleType(this Type type) => type.IsPrimitive || type.Equals(typeof(string)) || type.Equals(typeof(DateTime));
    
    /// <summary>
    /// Gets appropriate comparing method for a type
    /// </summary>
    /// <param name="type">Type in request</param>
    /// <returns>Method info of the compare method</returns>
    /// <exception cref="ArgumentException">If type is not primitive</exception>
    /// <exception cref="ArgumentNullException">If type is null</exception>
    /// <exception cref="InvalidOperationException">If not method found</exception>
    public static MethodInfo GetCompareMethod(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if(!type.IsSimpleType())
            throw new ArgumentException("Not a primitive type");

        var methodName = type == typeof(string) ? "Contains" : "Equals";
        return type.GetMethod(methodName, new[] { type }) ?? throw new InvalidOperationException("Method not found");
    }

    /// <summary>
    /// Gets value in appropriate type in boxed format
    /// </summary>
    /// <param name="filter">Filter value</param>
    /// <param name="type">Type in request</param>
    /// <returns>Boxed filter value in its type</returns>
    /// <exception cref="ArgumentException">If type is not primitive</exception>
    /// <exception cref="ArgumentNullException">If filter or type is null</exception>
    /// <exception cref="InvalidOperationException">if no parse method found</exception>
    public static object GetValue(this QueryFilter filter, Type type)
    {
        ArgumentNullException.ThrowIfNull(filter);
        ArgumentNullException.ThrowIfNull(type);

        if(!type.IsSimpleType())
            throw new ArgumentException("Not a primitive type");

        // Return string or parsed value
        if (type.Equals(typeof(string)))
            return filter.Value;
        else
        {
            // Create specific expression based on type
            var parameter = Expression.Parameter(typeof(string));
            var parseMethod = type.GetMethod("Parse", new[] { typeof(string) }) ?? throw new InvalidOperationException("Method not found");
            var argument = Expression.Constant(filter.Value);
            var methodCaller = Expression.Call(parseMethod, argument);
            var returnConverter = Expression.Convert(methodCaller, typeof(object));
            var function = Expression.Lambda<Func<string, object>>(returnConverter, parameter).Compile();

            return function.Invoke(filter.Value);
        }
    }
}