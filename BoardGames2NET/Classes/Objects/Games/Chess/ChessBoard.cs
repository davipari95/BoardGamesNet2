using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BoardGames2NET.Classes.Objects.Games.Chess
{
    /// <summary>
    /// Class that represents a chess board.
    /// </summary>
    public class ChessBoard
    {

        #region ===== FIELDS =====
        /// <summary>
        /// Match parent.
        /// </summary>
        private Match? _ParentMatch = null;
        #endregion

        #region ===== PROPERTIES =====
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
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new class <see cref="ChessBoard"/>.
        /// </summary>
        /// <param name="parentMatch">Match where this class is initialized.</param>
        public ChessBoard(Match parentMatch)
        {
            ParentMatch = parentMatch;
        } 
        #endregion

    }
}
