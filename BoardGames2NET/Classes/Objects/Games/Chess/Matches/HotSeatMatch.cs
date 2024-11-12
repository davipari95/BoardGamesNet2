using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.Games.Chess.Matches
{
    /// <summary>
    /// Class that represents a chess match in hot-seat mode.
    /// </summary>
    public class HotSeatMatch : Match
    {

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new class <see cref="HotSeatMatch"/>.
        /// </summary>
        /// <param name="whitesPlayerName">Name of the whites player.</param>
        /// <param name="blacksPlayerName">Name of the blacks player.</param>
        public HotSeatMatch(string whitesPlayerName, string blacksPlayerName) : base(whitesPlayerName, blacksPlayerName)
        {
        } 
        #endregion
    }
}
