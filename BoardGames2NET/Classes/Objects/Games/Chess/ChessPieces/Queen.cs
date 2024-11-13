using BoardGames2NET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.Games.Chess.ChessPieces
{
    public class Queen : ChessPiece
    {
        /// <summary>
        /// Initialize the class <see cref="Queen"/> given color, starting row position and starting column position.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this queen.</param>
        /// <param name="color">Color of the queen.</param>
        /// <param name="rowPosition">Starting row position of the queen.</param>
        /// <param name="colPosition">Starting column position of the queen.</param>
        public Queen(ChessBoard parent, BWColorEnum color, int rowPosition, int colPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Queen, rowPosition, colPosition) { }

        /// <summary>
        /// Initialize the class <see cref="Queen"/> given color and starting position given as <see cref="GridPosition"/>.
        /// </summary>
        /// <param name="parent">Chessboard where initialize this queen.</param>
        /// <param name="color">Color of the queen.</param>
        /// <param name="gridPosition">Starting position.</param>
        public Queen(ChessBoard parent, BWColorEnum color, GridPosition gridPosition) : base(parent, color, Enums.Games.Chess.PieceKindEnum.Queen, gridPosition) { }

        public override void Move(int row, int column)
        {
            //TODO;
        }
    }
}
