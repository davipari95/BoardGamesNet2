using BoardGames2NET.Enums.Games.Chess;

namespace BoardGames2NET.Interfaces.Games.Chess
{
    /// <summary>
    /// Interface that adds the property <see cref="Kind"/> to the chess piece with the enumerator <see cref="PieceKindEnum"/>.
    /// </summary>
    public interface IChessPieceKind
    {
        /// <summary>
        /// Kind of the chess piece.
        /// </summary>
        PieceKindEnum Kind { get; }
    }
}