using BoardGames2NET.Classes.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Interfaces
{
    /// <summary>
    /// Add the method <see cref="Move(GridPosition)"/> and <see cref="Move(int, int)"/>.
    /// </summary>
    public interface IMoveable
    {
        #region ===== METHODS =====
        /// <summary>
        /// Move the element into position given in <paramref name="row"/> and <paramref name="column"/>.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        void Move(int row, int column);

        /// <summary>
        /// Move the element into position given in <paramref name="position"/>.
        /// </summary>
        /// <param name="position">New position of the chess piece.</param>
        void Move(GridPosition position)
        {
            Move(position.Row, position.Column);
        }
        #endregion
    }
}
