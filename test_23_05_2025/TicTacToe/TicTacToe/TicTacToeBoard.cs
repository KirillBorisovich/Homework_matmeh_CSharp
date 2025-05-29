// <copyright file="Program.cs" company="BengyaKirill">
// Copyright (c) BengyaKirill under MIT license. All rights reserved.
// </copyright>

namespace TicTacToe;

/// <summary>
/// Form for Tic Tac Toe.
/// </summary>
public partial class TicTacToeBoard : Form
{
    private bool xPressed = false;
    private Button[,] buttons = new Button[3, 3];

    public TicTacToeBoard()
    {
        this.InitializeComponent();
        this.CreateGameField();
    }

    private void ButtonClick(object? sender, EventArgs args)
    {
        if (sender == null)
        {
            return;
        }

        Button buton = (Button)sender;

        if (buton.Text != string.Empty)
        {
            return;
        }

        buton.Text = !this.xPressed ? "X" : "O";

        this.xPressed = !this.xPressed;

        this.CheckForWinner();
    }

    private void CreateGameField()
    {
        this.Text = "TicTacToeBoard";
        this.MinimumSize = new Size(300, 300);
        this.Size = new Size(500, 500);

        TableLayoutPanel tableLayout = new TableLayoutPanel();
        tableLayout.Dock = DockStyle.Fill;
        tableLayout.ColumnCount = 3;
        tableLayout.RowCount = 3;

        for (int i = 0; i < 3; i++)
        {
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
        }

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                this.buttons[row, col] = new Button();
                this.buttons[row, col].Dock = DockStyle.Fill;
                this.buttons[row, col].Font = new Font("Arial", 40);
                this.buttons[row, col].Click += this.ButtonClick;
                this.buttons[row, col].Margin = new Padding(5);

                tableLayout.Controls.Add(this.buttons[row, col], col, row);
            }
        }

        this.Controls.Add(tableLayout);
    }

    private void CheckForWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if (this.buttons[i, 0].Text != string.Empty &&
                this.buttons[i, 0].Text == this.buttons[i, 1].Text &&
                this.buttons[i, 1].Text == this.buttons[i, 2].Text)
            {
                this.ShowWinner(this.buttons[i, 0].Text);
                return;
            }

            if (this.buttons[0, i].Text != string.Empty &&
                this.buttons[0, i].Text == this.buttons[1, i].Text &&
                this.buttons[1, i].Text == this.buttons[2, i].Text)
            {
                this.ShowWinner(this.buttons[0, i].Text);
                return;
            }
        }

        if (this.buttons[0, 0].Text != string.Empty &&
            this.buttons[0, 0].Text == this.buttons[1, 1].Text &&
            this.buttons[1, 1].Text == this.buttons[2, 2].Text)
        {
            this.ShowWinner(this.buttons[0, 0].Text);
            return;
        }

        if (this.buttons[0, 2].Text != string.Empty &&
            this.buttons[0, 2].Text == this.buttons[1, 1].Text &&
            this.buttons[1, 1].Text == this.buttons[2, 0].Text)
        {
            this.ShowWinner(this.buttons[0, 2].Text);
            return;
        }

        bool isDraw = true;
        foreach (var button in this.buttons)
        {
            if (button.Text == string.Empty)
            {
                isDraw = false;
                break;
            }
        }

        if (isDraw)
        {
            MessageBox.Show("Ничья!", "Игра окончена");
            this.ResetGame();
        }
    }

    private void ShowWinner(string winner)
    {
        MessageBox.Show($"Победил {winner}!", "Игра окончена");
        this.ResetGame();
    }

    private void ResetGame()
    {
        foreach (var button in this.buttons)
        {
            button.Text = string.Empty;
        }

        this.xPressed = true;
    }
}
