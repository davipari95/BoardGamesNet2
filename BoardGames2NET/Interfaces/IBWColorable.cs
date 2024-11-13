using BoardGames2NET.Enums;

namespace BoardGames2NET.Interfaces
{
    /// <summary>
    /// Interface that assign the propery "Color" settable black or white.
    /// </summary>
    public interface IBWColorable
    {
        /// <summary>
        /// Color of the element
        /// </summary>
        BWColorEnum Color { get; }
    }
}