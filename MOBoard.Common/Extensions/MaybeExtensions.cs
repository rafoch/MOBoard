using CSharpFunctionalExtensions;

namespace MOBoard.Common.Extensions
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T obj)
        {
            return (object) obj != null ? Maybe<T>.From(obj) : Maybe<T>.None;
        }
    }
}