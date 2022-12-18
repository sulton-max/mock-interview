using System.Reflection;
using MockInterview.Core.Extensions;
using MockInterview.Core.Models.Attributes;
using MockInterview.Core.Models.Common;

namespace MockInterview.DAL.Extensions;

/// <summary>
/// Provides extensions specifically for entities
/// </summary>
public static class EntityExtensions
{
    /// <summary>
    /// Checks whether given type is entity
    /// </summary>
    /// <param name="type">Type to check</param>
    /// <returns>True if given type is entity, otherwise false</returns>
    public static bool IsEntity(this Type type) => type.InheritsOrImplements(typeof(IEntity));

    /// <summary>
    /// Gets direct child entities from a type
    /// </summary>
    /// <param name="type">Type to get direct child entities</param>
    /// <returns>Set of direct child entities</returns>
    /// <exception cref="ArgumentException">If type is null</exception>
    public static IEnumerable<Type> GetDirectChildEntities(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (!type.IsEntity())
            throw new ArgumentException();

        // Get children
        var result = type.GetProperties().Where(x => x.PropertyType.IsClass && x.PropertyType.IsEntity()).Select(x => x.PropertyType).ToList();

        return result.Distinct();
    }

    public static IEnumerable<PropertyInfo> GetSearchableProperties(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return type.GetProperties().Where(x => x.PropertyType.IsSimpleType() && Attribute.IsDefined(x, typeof(SearchablePropertyAttribute)));
    }
}