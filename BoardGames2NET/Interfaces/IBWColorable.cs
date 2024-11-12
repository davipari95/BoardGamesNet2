using BoardGames2NET.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Interfaces
{
    /// <summary>
    /// Interface that assign the propery "Color" settable black or white.
    /// </summary>
    public interface IBWColorable
    {
        /// <summary>
        /// Color of the element
        /// </summary>
        BWColorEnum Color { get; set; }
    }
}
