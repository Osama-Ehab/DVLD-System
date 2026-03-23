using System;

/// <summary>
/// A generic attribute to specify a valid range for a value.
/// </summary>
/// <typeparam name="T">The type of the value, which must be comparable (e.g., int, double, DateTime).</typeparam>
public class RangeAttribute<T> : Attribute where T : IComparable<T>
{
    /// <summary>
    /// The minimum allowed value (inclusive).
    /// </summary>
    public readonly T Min;

    /// <summary>
    /// The maximum allowed value (inclusive).
    /// </summary>
    public readonly T Max;

    /// <summary>
    /// An optional error message to display if validation fails.
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Creates a new instance of the RangeAttribute.
    /// </summary>
    /// <param name="min">The minimum allowed value.</param>
    /// <param name="max">The maximum allowed value.</param>
    public RangeAttribute(T min, T max)
    {
        // Ensure Min is always less than or equal to Max
        if (min.CompareTo(max) > 0)
        {
            // If min is greater than max, swap them
            Min = max;
            Max = min;
        }
        else
        {
            Min = min;
            Max = max;
        }
    }

    /// <summary>
    /// Checks if the given value is within the specified range.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns>True if the value is within the range, false otherwise.</returns>
    public bool IsValid(T value)
    {
        // Check if value >= Min and value <= Max
        return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
    }

    // --- Example Usage ---
    //
    // public class Product
    // {
    //     [Range<int>(0, 100)]
    //     public int StockLevel { get; set; }
    //
    //     [Range<double>(0.01, 9999.99)]
    //     public double Price { get; set; }
    //
    //     [Range<DateTime>("2024-01-01", "2024-12-31")]
    //     public DateTime SaleDate { get; set; }
    // }
    //
    // Note: Using a DateTime string in an attribute requires C# 11 or
    // custom parsing. For simplicity, you might pass ticks or use a
    // non-generic validation attribute for complex types.
}
