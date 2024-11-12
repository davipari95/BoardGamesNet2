using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Enums.Games.Chess
{
    /// <summary>
    /// Enumerator that contains all special movement of chess game.
    /// </summary>
    public enum SpecialMovementEnum
    {
        /// <summary>
        /// No special movement.
        /// </summary>
        None,

        /// <summary>
        /// Castling of the king with rook.
        /// </summary>
        Castling,

        /// <summary>
        /// Pawn en-passant.
        /// </summary>
        EnPassant,

        /// <summary>
        /// Pawn promotion.
        /// </summary>
        PawnPromotion,
    }
}
