using BoardGames2NET.Enums;

namespace BoardGames2NET.Classes.Objects.Games.Chess.ChessPieces
{
    /// <summary>
    /// Class that represents the pawn chess piece.
    /// </summary>
    public class Pawn : ChessPiece
    {
        /// <summary>
        /// Initialize the class <see cref="Pawn"/> given color, starting row position and starting column position.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this pawn.</param>
        /// <param name="color">Color of the pawn.</param>
        /// <param name="rowPosition">Starting row position of the pawn.</param>
        /// <param name="colPosition">Starting column position of the pawn.</param>
        public Pawn(ChessBoard parent, BWColorEnum color, int rowPosition, int colPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Pawn, rowPosition, colPosition) { }

        /// <summary>
        /// Initialize the class <see cref="Pawn"/> given color and starting position given as <see cref="GridPosition"/>.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this pawn.</param>
        /// <param name="color">Color of the pawn.</param>
        /// <param name="gridPosition">Starting position.</param>
        public Pawn(ChessBoard parent, BWColorEnum color, GridPosition gridPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Pawn, gridPosition) { }

        public override void Move(int row, int column)
        {
            //TODO;
        }
    }
}