using BoardGames2NET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.Games.Chess.ChessPieces
{
    public class Bishop : ChessPiece
    {
        /// <summary>
        /// Initialize the class <see cref="Bishop"/> given color, starting row position and starting column position.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this bishop.</param>
        /// <param name="color">Color of the bishop.</param>
        /// <param name="rowPosition">Starting row position of the bishop.</param>
        /// <param name="colPosition">Starting column position of the bishop.</param>
        public Bishop(ChessBoard parent, BWColorEnum color, int rowPosition, int colPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Bishop, rowPosition, colPosition) { }

        /// <summary>
        /// Initialize the class <see cref="Bishop"/> given color and starting position given as <see cref="GridPosition"/>.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this bishop.</param>
        /// <param name="color">Color of the bishop.</param>
        /// <param name="gridPosition">Starting position.</param>
        public Bishop(ChessBoard parent, BWColorEnum color, GridPosition gridPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Bishop, gridPosition) { }

        public override void Move(int row, int column)
        {
            //TODO;
        }
    }
}
