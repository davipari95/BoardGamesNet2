using BoardGames2NET.Classes.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Interfaces
{
    /// <summary>
    /// Interface that adds the property for the movement of an element.
    /// </summary>
    public interface IPositionable : IGridPosition, IMoveable { }
}
