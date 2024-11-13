using BoardGames2NET.Enums;
using BoardGames2NET.Enums.Games.Chess;
using BoardGames2NET.Interfaces.Games.Chess;

namespace BoardGames2NET.Classes.Objects.Games.Chess
{
    /// <summary>
    /// Class that represents a chess piece.
    /// </summary>
    public class ChessPiece : IChessPiece, ICloneable
    {
        /// <summary>
        /// Color of the chess piece.
        /// </summary>
        private BWColorEnum _Color = BWColorEnum.Black;

        /// <summary>
        /// Kind of chess piece.
        /// </summary>
        private PieceKindEnum _Kind = PieceKindEnum.Pawn;

        /// <summary>
        /// Position of the piece.
        /// </summary>
        private GridPosition _Position = new GridPosition();

        public BWColorEnum Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (!value.Equals(_Color))
                {
                    _Color = value;
                }
            }
        }

        public PieceKindEnum Kind
        {
            get
            {
                return _Kind;
            }
            set
            {
                if (!value.Equals(_Kind))
                {
                    _Kind = value;
                }
            }
        }

        public GridPosition Position
        {
            get
            {
                return _Position;
            }
            set
            {
                if (!value.Equals(_Position))
                {
                    _Position = value;
                }
            }
        }

        /// <summary>
        /// Chessboard parent where this piece is initialized.
        /// </summary>
        public ChessBoard? ChessBoardParent { get; private set; }

        /// <summary>
        /// Initialize the class <see cref="ChessPiece"/> given color, kind, starting row position and starting column position.
        /// </summary>
        /// <param name="color">Color of the chess piece.</param>
        /// <param name="kind">Kind of the chess piece.</param>
        /// <param name="rowPositon">Starting row position of the chess piece.</param>
        /// <param name="colPosition">Starting column position of the chess piece.</param>
        public ChessPiece(ChessBoard parent, BWColorEnum color, PieceKindEnum kind, int rowPositon, int colPosition)
        {
            Initialize(parent, color, kind, rowPositon, colPosition);
        }

        /// <summary>
        /// Initialize the class <see cref="ChessPiece"/> given color, kind and starting position as <see cref="GridPosition"/>.
        /// </summary>
        /// <param name="parent">Chessboard where this piece is initialized.</param>
        /// <param name="color">Color of the chess piece.</param>
        /// <param name="kind">Kind of the chess piece.</param>
        /// <param name="startingPosition">Starting position.</param>
        public ChessPiece(ChessBoard parent, BWColorEnum color, PieceKindEnum kind, GridPosition startingPosition)
        {
            Initialize(parent, color, kind, startingPosition.Row, startingPosition.Column);
        }

        public virtual void Move(int row, int column)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializer helper for this class.
        /// </summary>
        /// <param name="parent">Chessboard where this piece is intialized.</param>
        /// <param name="color">Color of the chess piece.</param>
        /// <param name="kind">Kind of the chess piece.</param>
        /// <param name="rowPosition">Starting row position of the chess piece.</param>
        /// <param name="colPosition">Starting column position of the chess piece.</param>
        private void Initialize(ChessBoard parent, BWColorEnum color, PieceKindEnum kind, int rowPosition, int colPosition)
        {
            ChessBoardParent = parent;
            _Color = color;
            _Kind = kind;
            _Position = new GridPosition(rowPosition, colPosition);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is IChessPiece)
                {
                    IChessPiece? piece = obj as IChessPiece;

                    if (piece != null)
                    {
                        return
                            piece.Kind.Equals(Kind) &&
                            piece.Color.Equals(Color) &&
                            piece.Position.Equals(Position);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return
                Kind.GetHashCode() ^
                Color.GetHashCode() ^
                Position.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[Kind = {0} ; Color = {1} ; Position = [{2}]]", Kind, Color, Position);
        }

        public object Clone()
        {
            if (ChessBoardParent != null)
            {
                return new ChessPiece(ChessBoardParent, Color, Kind, Position);
            }
            else
            {
                throw new NullReferenceException("Chessboard parent is not initialized.");
            }
        }
    }
}