using BoardGames2NET.Classes.Objects;
using BoardGames2NET.Enums;
using BoardGames2NET.Enums.Games.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Interfaces.Games.Chess
{
    /// <summary>
    /// Interface that represents a chess piece.
    /// </summary>
    public interface IChessPiece : IBWColorable, IChessPieceKind, IPositionable { }
}
