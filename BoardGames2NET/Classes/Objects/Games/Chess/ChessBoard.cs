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
        /// Match parent.
        /// </summary>
        public Match? ParentMatch
        {
            get
            {
                return _ParentMatch;
            }
            set
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
        /// Initialize a new class <see cref="ChessBoard"/>.
        /// </summary>
        /// <param name="parentMatch">Match where this class is initialized.</param>
        public ChessBoard(Match parentMatch)
        {
            ParentMatch = parentMatch;
        }
    }
}