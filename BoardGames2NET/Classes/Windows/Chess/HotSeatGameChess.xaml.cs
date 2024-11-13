using BoardGames2NET.Classes.CustomComponents;
using System.Windows;

namespace BoardGames2NET.Classes.Windows.Chess
{
    /// <summary>
    /// Logica di interazione per HotSeatGameChess.xaml
    /// </summary>
    public partial class HotSeatGameChess : Window
    {
        private CanvasGrid[,] Board { get; set; }

        public HotSeatGameChess(string whitesPlayerName, string blacksPlayerName)
        {
            InitializeComponent();

            InitializeBoardGrid();
        }

        private void InitializeBoardGrid()
        {
            Board = new CanvasGrid[8, 8];
            int squareSize = Settings.Games.Chess.Graphics.Default.SquareSize - (2 * Settings.Games.Chess.Graphics.Default.SquareMargin);
            int margin = Settings.Games.Chess.Graphics.Default.SquareMargin;

            int actSquareSize = squareSize - (2 * margin);

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Board[r, c] = new CanvasGrid()
                    {
                        Position = new Objects.GridPosition(r, c),
                        Width = actSquareSize,
                        Height = actSquareSize,
                    };

                    CanvasGrid.SetTop(Board[r, c], (r * squareSize) + margin);
                    CanvasGrid.SetLeft(Board[r, c], (c * squareSize) + margin);

                    ChessBoardCanvas.Children.Add(Board[r, c]);

                    Board[r, c].MouseLeftButtonUp += HotSeatGameChess_MouseLeftButtonUp;
                }
            }
        }

        private void HotSeatGameChess_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}