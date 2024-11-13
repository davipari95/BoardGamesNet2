using BoardGames2NET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.Games.Chess.ChessPieces
{
    public class Rook : ChessPiece
    {

        /// <summary>
        /// Initialize the class <see cref="Rook"/> given color, starting row position and starting column position.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this rook.</param>
        /// <param name="color">Color of the rook.</param>
        /// <param name="rowPosition">Starting row position of the rook.</param>
        /// <param name="colPosition">Starting column position of the rook.</param>
        public Rook(ChessBoard parent, BWColorEnum color, int rowPosition, int colPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Rook, rowPosition, colPosition) { }

        /// <summary>
        /// Initialize the class <see cref="Rook"/> given color and starting position given as <see cref="GridPosition"/>.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this rook.</param>
        /// <param name="color">Color of the rook.</param>
        /// <param name="gridPosition">Starting position.</param>
        public Rook(ChessBoard parent, BWColorEnum color, GridPosition gridPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Rook, gridPosition) { }

        public override void Move(int row, int column)
        {
            //TODO;
        }

    }
}
