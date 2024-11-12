using BoardGames2NET.Classes.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Interfaces
{
    /// <summary>
    /// Add the property <see cref="Position"/> as <see cref="GridPosition"/>.
    /// </summary>
    public interface IGridPosition
    {
        /// <summary>
        /// Position of the element.
        /// </summary>
        GridPosition Position { get; set; }
    }
}
