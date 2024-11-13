using BoardGames2NET.Enums.Games.Chess;
using BoardGames2NET.Interfaces;
using BoardGames2NET.Interfaces.Games.Chess;

namespace BoardGames2NET.Classes.Objects.Games.Chess
{
    /// <summary>
    /// Structure class that contains all informations about the available movement.
    /// </summary>
    public class AvailableMove : IGridPosition, ISpecialMovement, IEatableElement<IChessPiece?>
    {
        /// <summary>
        /// Position of the available movement.
        /// </summary>
        private GridPosition? _Position = null;

        /// <summary>
        /// Here check if the movement is caused by a special movement.
        /// </summary>
        private SpecialMovementEnum _SpecialMovement = SpecialMovementEnum.None;

        /// <summary>
        /// If this property is not <see langword="null"/>, it means that the movement eat a piece contained here.
        /// </summary>
        private IChessPiece? _EatableElement = null;

        /// <summary>
        /// Position of the available movement.
        /// </summary>
        public GridPosition? Position
        {
            get
            {
                return _Position;
            }
            private set
            {
                if (value != null)
                {
                    if (!value.Equals(_Position))
                    {
                        _Position = value;
                    }
                }
                else
                {
                    if (_Position != null)
                    {
                        _Position = null;
                    }
                }
            }
        }

        /// <summary>
        /// Here check if the movement is caused by a special movement.
        /// </summary>
        public SpecialMovementEnum SpecialMovement
        {
            get
            {
                return _SpecialMovement;
            }
            private set
            {
                if (!value.Equals(_SpecialMovement))
                {
                    _SpecialMovement = value;
                }
            }
        }

        /// <summary>
        /// If this property is not <see langword="null"/>, it means that the movement eat a piece contained here.
        /// </summary>
        public IChessPiece? EatableElement
        {
            get
            {
                return _EatableElement;
            }
            private set
            {
                if (value != null)
                {
                    if (!value.Equals(_EatableElement))
                    {
                        _EatableElement = value;
                    }
                }
                else
                {
                    if (_EatableElement != null)
                    {
                        _EatableElement = null;
                    }
                }
            }
        }

        /// <summary>
        /// Initialize the class <see cref="AvailableMove"/> given the grid position.<br/>
        /// This will set the property <see cref="SpecialMovement"/> to <see cref="SpecialMovementEnum.None"/> and <see cref="EatableElement"/> to <see langword="null"/>.
        /// </summary>
        /// <param name="position">Position of the available movement.</param>
        public AvailableMove(GridPosition? position)
        {
            Initialize(position, SpecialMovementEnum.None, null);
        }

        /// <summary>
        /// Initialize the class <see cref="AvailableMove"/> given the grid position and the eatable piece.<br/>
        /// This will set the property <see cref="SpecialMovement"/> to <see cref="SpecialMovementEnum.None"/>.
        /// </summary>
        /// <param name="position">Position of the available move.</param>
        /// <param name="eatablePiece">Eatable piece.<br/>Set it to <see langword="null"/> if no piece is eatable.</param>
        public AvailableMove(GridPosition? position, IChessPiece? eatablePiece)
        {
            Initialize(position, SpecialMovementEnum.None, eatablePiece);
        }

        /// <summary>
        /// Initialize the class <see cref="AvailableMove"/> given the grid position, the eatable piece and the special movement.<br/>
        /// </summary>
        /// <param name="position">Position of the available move.</param>
        /// <param name="eatablePiece">Eatable piece.<br/>Set it to <see langword="null"/> if no piece is eatable.</param>
        /// <param name="specialMovement">Special movement of this move.</param>
        public AvailableMove(GridPosition? position, IChessPiece? eatablePiece, SpecialMovementEnum specialMovement)
        {
            Initialize(position, specialMovement, eatablePiece);
        }

        /// <summary>
        /// Initialize the properties of this class
        /// </summary>
        /// <param name="gridPosition">Grid position of the available movement.</param>
        /// <param name="specialMovement">Special movement if it is.</param>
        /// <param name="eatablePiece">Eatable piece</param>
        private void Initialize(GridPosition? gridPosition, SpecialMovementEnum specialMovement, IChessPiece? eatablePiece)
        {
            _Position = gridPosition;
            _SpecialMovement = specialMovement;
            _EatableElement = eatablePiece;
        }
    }
}