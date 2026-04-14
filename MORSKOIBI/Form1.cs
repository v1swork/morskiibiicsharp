using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MORSKOIBI
{
    public partial class Form1 : Form
    {
        private Button[,] playerButtons = new Button[10, 10];
        private Button[,] enemyButtons = new Button[10, 10];

        private int[,] playerBoard = new int[10, 10];
        private int[,] enemyBoard = new int[10, 10];
        // 0 — пусто
        // 1 - корабль
        // 2 - попадание
        // 3 - мимо
         
        public Form1()
        {
            InitializeComponent();
            CreateBoards();
            PlaceShip();
            DrawPlayerShips();
        }

        private void CreateBoards()
        {
            int cellSize = 29;
            int leftMargin = 23;
            int topMargin = 23;

            string[] letters = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К" };

            for (int i = 0; i < 10; i++)
            {
                Label playerLetter = new Label();
                playerLetter.Text = letters[i];
                playerLetter.AutoSize = false;
                playerLetter.Size = new Size(cellSize, topMargin);
                playerLetter.TextAlign = ContentAlignment.MiddleCenter;
                playerLetter.Location = new Point(leftMargin + i * cellSize,0);
                PanelPlayer.Controls.Add(playerLetter);

                Label enemyLetter = new Label();
                enemyLetter.Text = letters[i];
                enemyLetter.AutoSize = false;
                enemyLetter.Size = new Size(cellSize, topMargin);
                enemyLetter.TextAlign = ContentAlignment.MiddleCenter;
                enemyLetter.Location = new Point(leftMargin + i * cellSize, 0);
                PanelEnemy.Controls.Add(enemyLetter);

                Label playerCiferki = new Label();
                playerCiferki.Text = (i + 1).ToString();
                playerCiferki.AutoSize = false;
                playerCiferki.Size = new Size(leftMargin,cellSize);
                playerCiferki.TextAlign = ContentAlignment.MiddleCenter;
                playerCiferki.Location = new Point(0,topMargin + i * cellSize);
                PanelPlayer.Controls.Add(playerCiferki);

                Label enemyCiferki = new Label();
                enemyCiferki.Text = (i + 1).ToString();
                enemyCiferki.AutoSize = false;
                enemyCiferki.Size = new Size(leftMargin, cellSize);
                enemyCiferki.TextAlign = ContentAlignment.MiddleCenter;
                enemyCiferki.Location = new Point(0, topMargin + i * cellSize);
                PanelEnemy  .Controls.Add(enemyCiferki);



            }
            for (int row = 0; row <10;row++)
            {
                for(int col =0; col < 10;col++)
                {
                    Button playerButton = new Button();
                    playerButton.Size = new Size(cellSize, cellSize);
                    playerButton.Location = new Point(leftMargin + col * cellSize, topMargin + row * cellSize);
                    playerButton.Enabled = false;

                    PanelPlayer.Controls.Add(playerButton);
                    playerButtons[row, col] = playerButton;

                    Button enemyButton = new Button();
                    enemyButton.Size = new Size(cellSize, cellSize);
                    enemyButton.Location = new Point(leftMargin + col * cellSize, topMargin + row * cellSize);
                    enemyButton.Enabled = true;

                    enemyButton.Tag = new Point(row, col);
                    enemyButton.Click += enemyButton_Click;

                    PanelEnemy.Controls.Add(enemyButton);
                    enemyButtons[row, col] = enemyButton;

                } 
            }
        }

        private void PlaceShip()
        {
            //Random random = new Random();
            //int shipToPlace = 10;
            //int placed = 0;

            //while (placed < shipToPlace)
            //{
            //    int row = random.Next(0, 10);
            //    int col = random.Next(0, 10);

            //    if (enemyBoard[row, col] == 0)
            //    {
            //        enemyBoard[row, col] = 1;
            //        placed++;
            //    }
            //}
            //placed = 0;
            //while (placed < shipToPlace)
            //{
            //    int row = random.Next(0, 10);
            //    int col = random.Next(0, 10);
            //    if (playerBoard[row, col] == 0)
            //    {
            //        playerBoard[row, col] = 1;
            //        placed++;
            //    }

            //}
            PlaceShipForBoard(enemyBoard);
            PlaceShipForBoard(playerBoard);
        }
        private void PlaceShipForBoard(int[,] board)
        {
            Random random = new Random();
            int[] ships = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            foreach (int shipSize in ships)
            { 
                bool placed = false;
                int row = random.Next(0, 10);
                int col = random.Next(0, 10);
                while (!placed)
                { 
                    

                    bool horizontal = random.Next(2) == 0;
                    //проверка
                    if (CanPlaceShip(board, row, col, shipSize, horizontal))
                    {
                        for (int i = 0; i < shipSize; i++)
                        {
                            if (horizontal)
                                board[row, col + i] = 1;
                            else
                                board[row + i, col] = 1;
                        }
                        placed = true;
                        
                    }
                }
            }
        }

        private bool CanPlaceShip(int[,] board, int row, int col, int size, bool horizontal)
        {
            if (horizontal)
            {
                if (col + size > 10)
                    return false;

                for (int i = 0; i < size; i++)
                {
                    if (board[row, col + i] != 0)
                        return false;
                }
            }
            else 
            {
                if (row + size > 10)
                    return false;

                for (int i = 0; i < size; i++) 
                {
                    if (board[row + i, col] != 0)
                        return false;
                }
            }
            return true;
        }

        

        // 1 - 4
        // 2 - 3
        // 3 - 2
        // 4 - 1

        private void DrawPlayerShips()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (playerBoard[row, col] == 1)
                    {
                        playerButtons[row, col].BackColor = Color.Gray;
                    }
                }
            }
        }

        private void enemyButton_Click(object sender, EventArgs e)
        { 
            Button clickedButton = (Button)sender;
            Point point = (Point)clickedButton.Tag;

            int row = point.X; 
            int col = point.Y;

            if (enemyBoard[row, col] == 2 || enemyBoard[row, col] == 3)
                return;

            if (enemyBoard[row, col] == 1)
            {
                enemyBoard[row, col] = 2;
                clickedButton.BackColor = Color.Red;
                clickedButton.Text = "X";
                labelstatus.Text = "Попадание!!!";

                if (CheckWin(enemyBoard))
                {
                    labelstatus.Text = "Вы победили!";
                    MessageBox.Show("Ты победил");
                }
            }
            else 
            { 
                playerBoard [row, col] = 3;
                clickedButton.BackColor = Color.White;
                clickedButton.Text = "*";
                labelstatus.Text = "Промах!!!";
            }
            if (!CheckWin(enemyBoard))
            {
                EnemyTurn();
            }
            
        }

        private bool CheckWin(int[,] board)
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (board[row, col] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void EnemyTurn()
        { 
            Random random = new Random();

            int row, col;

            while (true)
            {
                row = random.Next(0, 10);
                col = random.Next(0, 10);

                if (playerBoard[row, col] == 2 || 
                    playerBoard[row, col] == 3)
                    continue;

                break;
            }

            if (playerBoard[row, col] == 1)
            {
                playerBoard[row, col] = 2;
                playerButtons[row, col].BackColor = Color.Red;
                playerButtons[row, col].Text = "X";
                labelstatus.Text = "Бот попал!";

                if (CheckWin(playerBoard))
                {
                    labelstatus.Text = "Вы проирали!";
                    MessageBox.Show("Ты проиграл");
                }
            }
            else
            {
                playerBoard[row, col] = 3;
                playerButtons[row, col].BackColor = Color.White;
                playerButtons[row, col].Text = "*";
                labelstatus.Text = "Бот промазал";
            }
        }
    }
}
