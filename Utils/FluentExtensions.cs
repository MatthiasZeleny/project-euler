namespace Utils;

public static class FluentExtensions
{
    public static TOutput Then<TInput, TOutput>(this TInput input, Func<TInput, TOutput> mapping) => mapping(input);
}