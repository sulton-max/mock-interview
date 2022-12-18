namespace MockInterview.Core.Extensions;

/// <summary>
/// Provides extensions for enum type
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Converts a string value to enum value
    /// </summary>
    /// <param name="value">Value being converted</param>
    /// <typeparam name="TEnum">Type of the enum to convert to</typeparam>
    /// <returns>Enum value</returns>
    /// <exception cref="ArgumentException">Throws if given value doesn't exist in enum</exception>
    public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct, Enum
    {
        return !string.IsNullOrWhiteSpace(value)
            ? Enum.IsDefined(Enum.Parse<TEnum>(value))
                ? Enum.Parse<TEnum>(value)
                : throw new ArgumentException($"Value is beyond enum values of type {typeof(TEnum)}")
            : throw new ArgumentException(nameof(value));
    }

    /// <summary>
    /// Converts a list of string to enum values
    /// </summary>
    /// <param name="values">Values being converted</param>
    /// <typeparam name="TEnum">Type of the enum to convert to</typeparam>
    /// <returns>Enum value</returns>
    /// <exception cref="ArgumentException">Throws if given value doesn't exist in enum</exception>
    public static IEnumerable<TEnum> ToEnum<TEnum>(this IEnumerable<string> values) where TEnum : struct, Enum
    {
        return values.Select(x => x.ToEnum<TEnum>());
    }
}