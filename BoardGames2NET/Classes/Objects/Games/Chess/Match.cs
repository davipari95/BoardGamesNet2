using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.Games.Chess
{
    /// <summary>
    /// Class that represents a chess match.
    /// </summary>
    public class Match
    {
        #region ===== FIELDS =====
        /// <summary>
        /// Name of the whites player.
        /// </summary>
        private string _WhitesPlayerName = "";

        /// <summary>
        /// Name of the blacks player.
        /// </summary>
        private string _BlacksPlayerName = "";
        #endregion

        #region ===== PROPERTIES =====
        /// <summary>
        /// Name of the whites player.
        /// </summary>
        public string WhitesPlayerName
        {
            get
            {
                return _WhitesPlayerName;
            }
            private set
            {
                if (value != _WhitesPlayerName)
                {
                    _WhitesPlayerName = value;
                }
            }
        }

        /// <summary>
        /// Name of the blacks player.
        /// </summary>
        public string BlacksPlayerName
        {
            get
            {
                return _BlacksPlayerName;
            }
            private set
            {
                if (value != _BlacksPlayerName)
                {
                    _BlacksPlayerName = value;
                }
            }
        }
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new class <see cref="Match"/>.
        /// </summary>
        /// <param name="whitesPlayerName">Name of the whites player.</param>
        /// <param name="blacksPlayerName">Name of the blacks player.</param>
        public Match(string whitesPlayerName, string blacksPlayerName)
        {
            WhitesPlayerName = whitesPlayerName;
            BlacksPlayerName = blacksPlayerName;
        } 
        #endregion

    }
}
