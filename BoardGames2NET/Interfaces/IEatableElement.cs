namespace BoardGames2NET.Interfaces
{
    /// <summary>
    /// Add the property <see cref="EatableElement"/> of type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">Class or interface that is eatable.</typeparam>
    public interface IEatableElement<T>
    {
        T EatableElement { get; }
    }
}