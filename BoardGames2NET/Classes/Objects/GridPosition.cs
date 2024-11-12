using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames2NET.Classes.Objects
{
    /// <summary>
    /// This class represents a position on the grid.
    /// </summary>
    public class GridPosition : ICloneable
    {

        #region ===== FIELDS =====
        /// <summary>
        /// Private member that rapresents the row position.
        /// </summary>
        private int _Row = 0;

        /// <summary>
        /// Private member that rapresents the column position.
        /// </summary>
        private int _Column = 0;
        #endregion

        #region ===== PROPERTIES =====
        /// <summary>
        /// Row position on the grid.
        /// </summary>
        public int Row
        {
            get
            {
                return _Row;
            }
            set
            {
                if (value != _Row)
                {
                    _Row = value;
                    RowChangedEvent?.Invoke(this, value);
                    PositionChangedEvent?.Invoke(this, this);
                }
            }
        }

        /// <summary>
        /// Column position on the grid.
        /// </summary>
        public int Column
        {
            get
            {
                return _Column;
            }
            set
            {
                if (value != _Column)
                {
                    _Column = value;
                    ColumnChangedEvent?.Invoke(this, value);
                    PositionChangedEvent?.Invoke(this, this);
                }    
            }
        }
        #endregion

        #region ===== EVENT HANDLERS =====
        /// <summary>
        /// This event is invoked when the row value is changed.
        /// </summary>
        public event EventHandler<int>? RowChangedEvent;

        /// <summary>
        /// This method is invoked when the column value is changed.
        /// </summary>
        public event EventHandler<int>? ColumnChangedEvent;

        /// <summary>
        /// This method is invoked when the row value or column value are changed.
        /// </summary>
        public event EventHandler<GridPosition>? PositionChangedEvent;
        #endregion

        #region ===== CONSTRUCTORS =====
        /// <summary>
        /// Initialize a new istance that rapresents the grid position.
        /// </summary>
        /// <param name="row">Row position on the grid.</param>
        /// <param name="column">Column position on the grid.</param>
        public GridPosition(int row, int column)
        {
            Initialize(row, column);
        }

        /// <summary>
        /// Initialize a new istance that rapresents the grid position.
        /// </summary>
        /// <param name="position">A <see cref="GridPosition"/> copy where get row and column position.</param>
        public GridPosition(GridPosition position)
        {
            Initialize(position.Row, position.Column);
        }
        #endregion

        #region ===== METHODS =====
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not GridPosition)
            {
                return false;
            }
            else
            {
                GridPosition? gridObj = obj as GridPosition;

                if (gridObj == null)
                {
                    return false;
                }
                else
                {
                    return
                        gridObj.Row.Equals(Row) &&
                        gridObj.Column.Equals(Column);
                }
            }
        }

        public override int GetHashCode()
        {
            return
                Row.GetHashCode() ^
                Column.GetHashCode();
        }

        public object Clone()
        {
            return new GridPosition(Row, Column);
        }

        public override string ToString()
        {
            return string.Format("〈 Row = {0} ; Column = {1} 〉", Row, Column);
        }

        /// <summary>
        /// Set a new position of the grid.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void Set(int row, int column)
        {
            if (SetRow(row, false) || SetColumn(column, false))
            {
                PositionChangedEvent?.Invoke(this, new GridPosition(row, column));
            }
        }

        /// <summary>
        /// Set the row value.<br/>
        /// </summary>
        /// <param name="row">Row value to set.</param>
        /// <param name="invokePositionChanged">Set this value to <see langword="true"/> if you want to invoke the event <see cref="PositionChangedEvent"/> if row is changed.</param>
        /// <returns><see langword="true"/> if row value is changed, otherwise <see langword="false"/>.</returns>
        private bool SetRow(int row, bool invokePositionChanged = true)
        {
            bool change = _Row != row;

            if (change)
            {
                _Row = row;
                RowChangedEvent?.Invoke(this, row);

                if (invokePositionChanged)
                {
                    PositionChangedEvent?.Invoke(this, new GridPosition(this));
                }
            }

            return change;
        }

        /// <summary>
        /// Set the row value.<br/>
        /// </summary>
        /// <param name="row">Row value to set.</param>
        /// <param name="invokePositionChanged">Set this value to <see langword="true"/> if you want to invoke the event <see cref="PositionChangedEvent"/> if row is changed.</param>
        /// <returns><see langword="true"/> if row value is changed, otherwise <see langword="false"/>.</returns>
        private bool SetColumn(int column, bool invokePositionChanged)
        {
            bool change = _Column != column;

            if (change)
            {
                _Column = column;
                RowChangedEvent?.Invoke(this, column);

                if (invokePositionChanged)
                {
                    PositionChangedEvent?.Invoke(this, new GridPosition(this));
                }
            }

            return change;
        }

        /// <summary>
        /// Initialize a new instance of this class.
        /// </summary>
        /// <param name="row">Row value on grid position.</param>
        /// <param name="column">Column value on grid position.</param>
        private void Initialize(int row, int column)
        {
            _Row = row;
            _Column = column;
        }
        #endregion
    }
}
