using BoardGames2NET.Enums;

namespace BoardGames2NET.Classes.Objects.Games.Chess.ChessPieces
{
    public class Knight : ChessPiece
    {
        /// <summary>
        /// Initialize the class <see cref="Knight"/> given color, starting row position and starting column position.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this knight.</param>
        /// <param name="color">Color of the knight.</param>
        /// <param name="rowPosition">Starting row position of the knight.</param>
        /// <param name="colPosition">Starting column position of the knight.</param>
        public Knight(ChessBoard parent, BWColorEnum color, int rowPosition, int colPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Knight, rowPosition, colPosition) { }

        /// <summary>
        /// Initialize the class <see cref="Knight"/> given color and starting position given as <see cref="GridPosition"/>.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this knight.</param>
        /// <param name="color">Color of the knight.</param>
        /// <param name="gridPosition">Starting position.</param>
        public Knight(ChessBoard parent, BWColorEnum color, GridPosition gridPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Knight, gridPosition) { }

        public override void Move(int row, int column)
        {
            //TODO;
        }
    }
}
