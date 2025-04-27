namespace Calculator
{
    partial class CalculatorUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Main = new TableLayoutPanel();
            ControlButtons = new TableLayoutPanel();
            Equality = new Button();
            Negative = new Button();
            Clear = new Button();
            Division = new Button();
            Number3 = new Button();
            Number2 = new Button();
            Number1 = new Button();
            Multiplication = new Button();
            Number6 = new Button();
            Number5 = new Button();
            Number4 = new Button();
            Difference = new Button();
            Number9 = new Button();
            Number8 = new Button();
            Number7 = new Button();
            Addition = new Button();
            Number0 = new Button();
            Output = new TextBox();
            Main.SuspendLayout();
            ControlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // Main
            // 
            Main.ColumnCount = 1;
            Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Main.Controls.Add(ControlButtons, 0, 1);
            Main.Controls.Add(Output, 0, 0);
            Main.Dock = DockStyle.Fill;
            Main.Location = new Point(0, 0);
            Main.Name = "Main";
            Main.RowCount = 2;
            Main.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            Main.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            Main.Size = new Size(284, 361);
            Main.TabIndex = 0;
            // 
            // ControlButtons
            // 
            ControlButtons.ColumnCount = 4;
            ControlButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ControlButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ControlButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ControlButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ControlButtons.Controls.Add(Equality, 3, 0);
            ControlButtons.Controls.Add(Negative, 1, 0);
            ControlButtons.Controls.Add(Clear, 0, 0);
            ControlButtons.Controls.Add(Division, 3, 1);
            ControlButtons.Controls.Add(Number3, 2, 1);
            ControlButtons.Controls.Add(Number2, 1, 1);
            ControlButtons.Controls.Add(Number1, 0, 1);
            ControlButtons.Controls.Add(Multiplication, 3, 2);
            ControlButtons.Controls.Add(Number6, 2, 2);
            ControlButtons.Controls.Add(Number5, 1, 2);
            ControlButtons.Controls.Add(Number4, 0, 2);
            ControlButtons.Controls.Add(Difference, 3, 3);
            ControlButtons.Controls.Add(Number9, 2, 3);
            ControlButtons.Controls.Add(Number8, 1, 3);
            ControlButtons.Controls.Add(Number7, 0, 3);
            ControlButtons.Controls.Add(Addition, 3, 4);
            ControlButtons.Controls.Add(Number0, 1, 4);
            ControlButtons.Dock = DockStyle.Fill;
            ControlButtons.Location = new Point(3, 111);
            ControlButtons.Name = "ControlButtons";
            ControlButtons.RowCount = 5;
            ControlButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            ControlButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            ControlButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            ControlButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            ControlButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            ControlButtons.Size = new Size(278, 247);
            ControlButtons.TabIndex = 2;
            // 
            // Equality
            // 
            Equality.Dock = DockStyle.Fill;
            Equality.Font = new Font("Segoe UI", 14F);
            Equality.Location = new Point(210, 3);
            Equality.Name = "Equality";
            Equality.Size = new Size(65, 43);
            Equality.TabIndex = 52;
            Equality.Text = "=";
            Equality.UseVisualStyleBackColor = true;
            // 
            // Negative
            // 
            Negative.Dock = DockStyle.Fill;
            Negative.Font = new Font("Segoe UI", 14F);
            Negative.Location = new Point(72, 3);
            Negative.Name = "Negative";
            Negative.Size = new Size(63, 43);
            Negative.TabIndex = 50;
            Negative.Text = "+/-";
            Negative.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            Clear.Dock = DockStyle.Fill;
            Clear.Font = new Font("Segoe UI", 14F);
            Clear.Location = new Point(3, 3);
            Clear.Name = "Clear";
            Clear.Size = new Size(63, 43);
            Clear.TabIndex = 49;
            Clear.Text = "C";
            Clear.UseVisualStyleBackColor = true;
            // 
            // Division
            // 
            Division.Dock = DockStyle.Fill;
            Division.Font = new Font("Segoe UI", 14F);
            Division.Location = new Point(210, 52);
            Division.Name = "Division";
            Division.Size = new Size(65, 43);
            Division.TabIndex = 46;
            Division.Text = "/";
            Division.UseVisualStyleBackColor = true;
            // 
            // Number3
            // 
            Number3.Dock = DockStyle.Fill;
            Number3.Font = new Font("Segoe UI", 14F);
            Number3.Location = new Point(141, 52);
            Number3.Name = "Number3";
            Number3.Size = new Size(63, 43);
            Number3.TabIndex = 44;
            Number3.Text = "3";
            Number3.UseVisualStyleBackColor = true;
            // 
            // Number2
            // 
            Number2.Dock = DockStyle.Fill;
            Number2.Font = new Font("Segoe UI", 14F);
            Number2.Location = new Point(72, 52);
            Number2.Name = "Number2";
            Number2.Size = new Size(63, 43);
            Number2.TabIndex = 43;
            Number2.Text = "2";
            Number2.UseVisualStyleBackColor = true;
            // 
            // Number1
            // 
            Number1.Dock = DockStyle.Fill;
            Number1.Font = new Font("Segoe UI", 14F);
            Number1.Location = new Point(3, 52);
            Number1.Name = "Number1";
            Number1.Size = new Size(63, 43);
            Number1.TabIndex = 41;
            Number1.Text = "1";
            Number1.UseVisualStyleBackColor = true;
            // 
            // Multiplication
            // 
            Multiplication.Dock = DockStyle.Fill;
            Multiplication.Font = new Font("Segoe UI", 14F);
            Multiplication.Location = new Point(210, 101);
            Multiplication.Name = "Multiplication";
            Multiplication.Size = new Size(65, 43);
            Multiplication.TabIndex = 40;
            Multiplication.Text = "*";
            Multiplication.UseVisualStyleBackColor = true;
            // 
            // Number6
            // 
            Number6.Dock = DockStyle.Fill;
            Number6.Font = new Font("Segoe UI", 14F);
            Number6.Location = new Point(141, 101);
            Number6.Name = "Number6";
            Number6.Size = new Size(63, 43);
            Number6.TabIndex = 38;
            Number6.Text = "6";
            Number6.UseVisualStyleBackColor = true;
            // 
            // Number5
            // 
            Number5.Dock = DockStyle.Fill;
            Number5.Font = new Font("Segoe UI", 14F);
            Number5.Location = new Point(72, 101);
            Number5.Name = "Number5";
            Number5.Size = new Size(63, 43);
            Number5.TabIndex = 37;
            Number5.Text = "5";
            Number5.UseVisualStyleBackColor = true;
            // 
            // Number4
            // 
            Number4.Dock = DockStyle.Fill;
            Number4.Font = new Font("Segoe UI", 14F);
            Number4.Location = new Point(3, 101);
            Number4.Name = "Number4";
            Number4.Size = new Size(63, 43);
            Number4.TabIndex = 36;
            Number4.Text = "4";
            Number4.UseVisualStyleBackColor = true;
            // 
            // Difference
            // 
            Difference.Dock = DockStyle.Fill;
            Difference.Font = new Font("Segoe UI", 14F);
            Difference.Location = new Point(210, 150);
            Difference.Name = "Difference";
            Difference.Size = new Size(65, 43);
            Difference.TabIndex = 35;
            Difference.Text = "-";
            Difference.UseVisualStyleBackColor = true;
            // 
            // Number9
            // 
            Number9.Dock = DockStyle.Fill;
            Number9.Font = new Font("Segoe UI", 14F);
            Number9.Location = new Point(141, 150);
            Number9.Name = "Number9";
            Number9.Size = new Size(63, 43);
            Number9.TabIndex = 34;
            Number9.Text = "9";
            Number9.UseVisualStyleBackColor = true;
            // 
            // Number8
            // 
            Number8.Dock = DockStyle.Fill;
            Number8.Font = new Font("Segoe UI", 14F);
            Number8.Location = new Point(72, 150);
            Number8.Name = "Number8";
            Number8.Size = new Size(63, 43);
            Number8.TabIndex = 33;
            Number8.Text = "8";
            Number8.UseVisualStyleBackColor = true;
            // 
            // Number7
            // 
            Number7.Dock = DockStyle.Fill;
            Number7.Font = new Font("Segoe UI", 14F);
            Number7.Location = new Point(3, 150);
            Number7.Name = "Number7";
            Number7.Size = new Size(63, 43);
            Number7.TabIndex = 32;
            Number7.Text = "7";
            Number7.UseVisualStyleBackColor = true;
            // 
            // Addition
            // 
            Addition.Dock = DockStyle.Fill;
            Addition.Font = new Font("Segoe UI", 14F);
            Addition.Location = new Point(210, 199);
            Addition.Name = "Addition";
            Addition.Size = new Size(65, 45);
            Addition.TabIndex = 30;
            Addition.Text = "+";
            Addition.UseVisualStyleBackColor = true;
            // 
            // Number0
            // 
            Number0.Dock = DockStyle.Fill;
            Number0.Font = new Font("Segoe UI", 14F);
            Number0.Location = new Point(72, 199);
            Number0.Name = "Number0";
            Number0.Size = new Size(63, 45);
            Number0.TabIndex = 19;
            Number0.Text = "0";
            Number0.UseVisualStyleBackColor = true;
            // 
            // Output
            // 
            Output.Dock = DockStyle.Fill;
            Output.Font = new Font("Segoe UI", 20F);
            Output.Location = new Point(3, 3);
            Output.Multiline = true;
            Output.Name = "Output";
            Output.Size = new Size(278, 102);
            Output.TabIndex = 3;
            Output.Text = "0";
            Output.TextAlign = HorizontalAlignment.Right;
            // 
            // CalculatorUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 361);
            Controls.Add(Main);
            MinimumSize = new Size(300, 400);
            Name = "CalculatorUI";
            Text = "CalculatorUI";
            Main.ResumeLayout(false);
            Main.PerformLayout();
            ControlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel Main;
        private TableLayoutPanel ControlButtons;
        private TextBox Output;
        private Button Number0;
        private Button Equality;
        private Button Negative;
        private Button Clear;
        private Button Division;
        private Button Number3;
        private Button Number2;
        private Button Number1;
        private Button Multiplication;
        private Button Number6;
        private Button Number5;
        private Button Number4;
        private Button Difference;
        private Button Number9;
        private Button Number8;
        private Button Number7;
        private Button Addition;
    }
}
