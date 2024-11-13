using BoardGames2NET.Classes.Objects;

namespace BoardGames2NET.Interfaces
{
    /// <summary>
    /// Add the property <see cref="Position"/> as <see cref="GridPosition"/>.
    /// </summary>
    public interface IGridPosition
    {
        /// <summary>
        /// Position of the element.
        /// </summary>
        GridPosition? Position { get; }
    }
}