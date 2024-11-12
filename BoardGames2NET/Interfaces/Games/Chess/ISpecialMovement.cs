using BoardGames2NET.Enums.Games.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Interfaces.Games.Chess
{
    /// <summary>
    /// Interface that add the property <see cref="SpecialMovement"/> as <see cref="SpecialMovementEnum"/>.
    /// </summary>
    public interface ISpecialMovement
    {
        /// <summary>
        /// Special movement of the chess piece.
        /// </summary>
        SpecialMovementEnum SpecialMovement { get; set; }
    }
}
