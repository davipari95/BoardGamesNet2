using BoardGames2NET.Enums.Games.Chess;
using BoardGames2NET.Interfaces;
using BoardGames2NET.Interfaces.Games.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects.Games.Chess
{
    /// <summary>
    /// Structure class that contains all informations about the available movement.
    /// </summary>
    public class AvailableMove : IGridPosition, ISpecialMovement, IEatableElement<IChessPiece?>
    {
        #region ===== PROPERTIES =====
        /// <summary>
        /// Position of the available movement.
        /// </summary>
        public GridPosition Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Here check if the movement is caused by a special movement.
        /// </summary>
        public SpecialMovementEnum SpecialMovement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// If this property is not <see langword="null"/>, it means that the movement eat a piece contained here.
        /// </summary>
        public IChessPiece? EatableElement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion
    }
}
