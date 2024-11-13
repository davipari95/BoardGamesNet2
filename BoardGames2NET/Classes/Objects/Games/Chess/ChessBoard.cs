using BoardGames2NET.Classes.Objects.Games.Chess.ChessPieces;
using BoardGames2NET.Interfaces.Games.Chess;

namespace BoardGames2NET.Classes.Objects.Games.Chess
{
    /// <summary>
    /// Class that represents a chess board.
    /// </summary>
    public class ChessBoard
    {
        /// <summary>
        /// Match parent.
        /// </summary>
        private Match? _ParentMatch = null;

        /// <summary>
        /// Chess pieces on chessboard.
        /// </summary>
        private List<IChessPiece>? _ChessPieces = null;

        /// <summary>
        /// Match parent.
        /// </summary>
        public Match? ParentMatch
        {
            get
            {
                return _ParentMatch;
            }
            private set
            {
                if (value != null)
                {
                    if (value != _ParentMatch)
                    {
                        _ParentMatch = value;
                    }
                }
                else
                {
                    throw new NullReferenceException("Match cannot be a null value");
                }
            }
        }

        /// <summary>
        /// Chess pieces contained in this chessboard.
        /// </summary>
        public List<IChessPiece>? ChessPieces
        {
            get
            {
                return _ChessPieces;
            }
            private set
            {
                if (value != null)
                {
                    if (!value.Equals(_ChessPieces))
                    {
                        _ChessPieces = value;
                    }
                }
                else
                {
                    if (_ChessPieces != null)
                    {
                        _ChessPieces = null;
                    }
                }
            }
        }

        /// <summary>
        /// Initialize a new class <see cref="ChessBoard"/>.
        /// </summary>
        /// <param name="parentMatch">Match where this class is initialized.</param>
        public ChessBoard(Match parentMatch)
        {
            ParentMatch = parentMatch;

            InitPieces();
        }

        /// <summary>
        /// Initialize the pieces on the chessboard.
        /// </summary>
        private void InitPieces()
        {
            ChessPieces = new List<IChessPiece>()
            {
                new Rook(this, Enums.BWColorEnum.Black, 0, 0),
                new Knight(this, Enums.BWColorEnum.Black, 0, 1),
                new Bishop(this, Enums.BWColorEnum.Black, 0, 2),
                new Queen(this, Enums.BWColorEnum.Black, 0, 3),
                new King(this, Enums.BWColorEnum.Black, 0, 4),
                new Bishop(this, Enums.BWColorEnum.Black, 0, 5),
                new Knight(this, Enums.BWColorEnum.Black, 0, 6),
                new Rook(this, Enums.BWColorEnum.Black, 0, 7),

                new Pawn(this, Enums.BWColorEnum.Black, 1, 0),
                new Pawn(this, Enums.BWColorEnum.Black, 1, 1),
                new Pawn(this, Enums.BWColorEnum.Black, 1, 2),
                new Pawn(this, Enums.BWColorEnum.Black, 1, 3),
                new Pawn(this, Enums.BWColorEnum.Black, 1, 4),
                new Pawn(this, Enums.BWColorEnum.Black, 1, 5),
                new Pawn(this, Enums.BWColorEnum.Black, 1, 6),
                new Pawn(this, Enums.BWColorEnum.Black, 1, 7),

                new Pawn(this, Enums.BWColorEnum.White, 6, 0),
                new Pawn(this, Enums.BWColorEnum.White, 6, 1),
                new Pawn(this, Enums.BWColorEnum.White, 6, 2),
                new Pawn(this, Enums.BWColorEnum.White, 6, 3),
                new Pawn(this, Enums.BWColorEnum.White, 6, 4),
                new Pawn(this, Enums.BWColorEnum.White, 6, 5),
                new Pawn(this, Enums.BWColorEnum.White, 6, 6),
                new Pawn(this, Enums.BWColorEnum.White, 6, 7),

                new Rook(this, Enums.BWColorEnum.White, 7, 0),
                new Knight(this, Enums.BWColorEnum.White, 7, 1),
                new Bishop(this, Enums.BWColorEnum.White, 7, 2),
                new Queen(this, Enums.BWColorEnum.White, 7, 3),
                new King(this, Enums.BWColorEnum.White, 7, 4),
                new Bishop(this, Enums.BWColorEnum.White, 7, 5),
                new Knight(this, Enums.BWColorEnum.White, 7, 6),
                new Rook(this, Enums.BWColorEnum.White, 7, 7),
            };
        }
    }
}