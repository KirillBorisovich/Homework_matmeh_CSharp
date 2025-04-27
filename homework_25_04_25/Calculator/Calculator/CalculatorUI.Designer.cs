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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            Addition = new Button();
            Number0 = new Button();
            Clear = new Button();
            Difference = new Button();
            Number9 = new Button();
            Number8 = new Button();
            Number7 = new Button();
            Multiplication = new Button();
            Number6 = new Button();
            Number5 = new Button();
            Number4 = new Button();
            Division = new Button();
            Number3 = new Button();
            Number2 = new Button();
            Number1 = new Button();
            Output = new TextBox();
            Equality = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(Output, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(284, 361);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(Equality, 2, 3);
            tableLayoutPanel2.Controls.Add(Addition, 3, 3);
            tableLayoutPanel2.Controls.Add(Number0, 1, 3);
            tableLayoutPanel2.Controls.Add(Clear, 0, 3);
            tableLayoutPanel2.Controls.Add(Difference, 3, 2);
            tableLayoutPanel2.Controls.Add(Number9, 2, 2);
            tableLayoutPanel2.Controls.Add(Number8, 1, 2);
            tableLayoutPanel2.Controls.Add(Number7, 0, 2);
            tableLayoutPanel2.Controls.Add(Multiplication, 3, 1);
            tableLayoutPanel2.Controls.Add(Number6, 2, 1);
            tableLayoutPanel2.Controls.Add(Number5, 1, 1);
            tableLayoutPanel2.Controls.Add(Number4, 0, 1);
            tableLayoutPanel2.Controls.Add(Division, 3, 0);
            tableLayoutPanel2.Controls.Add(Number3, 2, 0);
            tableLayoutPanel2.Controls.Add(Number2, 1, 0);
            tableLayoutPanel2.Controls.Add(Number1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 111);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(278, 247);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // Addition
            // 
            Addition.Dock = DockStyle.Fill;
            Addition.Font = new Font("Segoe UI", 14F);
            Addition.Location = new Point(210, 186);
            Addition.Name = "Addition";
            Addition.Size = new Size(65, 58);
            Addition.TabIndex = 15;
            Addition.Text = "+";
            Addition.UseVisualStyleBackColor = true;
            // 
            // Number0
            // 
            Number0.Dock = DockStyle.Fill;
            Number0.Font = new Font("Segoe UI", 14F);
            Number0.Location = new Point(72, 186);
            Number0.Name = "Number0";
            Number0.Size = new Size(63, 58);
            Number0.TabIndex = 13;
            Number0.Text = "0";
            Number0.UseVisualStyleBackColor = true;
            Number0.Click += button2_Click_1;
            // 
            // Clear
            // 
            Clear.Dock = DockStyle.Fill;
            Clear.Font = new Font("Segoe UI", 14F);
            Clear.Location = new Point(3, 186);
            Clear.Name = "Clear";
            Clear.Size = new Size(63, 58);
            Clear.TabIndex = 12;
            Clear.Text = "C";
            Clear.UseVisualStyleBackColor = true;
            // 
            // Difference
            // 
            Difference.Dock = DockStyle.Fill;
            Difference.Font = new Font("Segoe UI", 14F);
            Difference.Location = new Point(210, 125);
            Difference.Name = "Difference";
            Difference.Size = new Size(65, 55);
            Difference.TabIndex = 11;
            Difference.Text = "-";
            Difference.UseVisualStyleBackColor = true;
            // 
            // Number9
            // 
            Number9.Dock = DockStyle.Fill;
            Number9.Font = new Font("Segoe UI", 14F);
            Number9.Location = new Point(141, 125);
            Number9.Name = "Number9";
            Number9.Size = new Size(63, 55);
            Number9.TabIndex = 10;
            Number9.Text = "9";
            Number9.UseVisualStyleBackColor = true;
            // 
            // Number8
            // 
            Number8.Dock = DockStyle.Fill;
            Number8.Font = new Font("Segoe UI", 14F);
            Number8.Location = new Point(72, 125);
            Number8.Name = "Number8";
            Number8.Size = new Size(63, 55);
            Number8.TabIndex = 9;
            Number8.Text = "8";
            Number8.UseVisualStyleBackColor = true;
            // 
            // Number7
            // 
            Number7.Dock = DockStyle.Fill;
            Number7.Font = new Font("Segoe UI", 14F);
            Number7.Location = new Point(3, 125);
            Number7.Name = "Number7";
            Number7.Size = new Size(63, 55);
            Number7.TabIndex = 8;
            Number7.Text = "7";
            Number7.UseVisualStyleBackColor = true;
            // 
            // Multiplication
            // 
            Multiplication.Dock = DockStyle.Fill;
            Multiplication.Font = new Font("Segoe UI", 14F);
            Multiplication.Location = new Point(210, 64);
            Multiplication.Name = "Multiplication";
            Multiplication.Size = new Size(65, 55);
            Multiplication.TabIndex = 7;
            Multiplication.Text = "*";
            Multiplication.UseVisualStyleBackColor = true;
            // 
            // Number6
            // 
            Number6.Dock = DockStyle.Fill;
            Number6.Font = new Font("Segoe UI", 14F);
            Number6.Location = new Point(141, 64);
            Number6.Name = "Number6";
            Number6.Size = new Size(63, 55);
            Number6.TabIndex = 6;
            Number6.Text = "6";
            Number6.UseVisualStyleBackColor = true;
            // 
            // Number5
            // 
            Number5.Dock = DockStyle.Fill;
            Number5.Font = new Font("Segoe UI", 14F);
            Number5.Location = new Point(72, 64);
            Number5.Name = "Number5";
            Number5.Size = new Size(63, 55);
            Number5.TabIndex = 5;
            Number5.Text = "5";
            Number5.UseVisualStyleBackColor = true;
            // 
            // Number4
            // 
            Number4.Dock = DockStyle.Fill;
            Number4.Font = new Font("Segoe UI", 14F);
            Number4.Location = new Point(3, 64);
            Number4.Name = "Number4";
            Number4.Size = new Size(63, 55);
            Number4.TabIndex = 4;
            Number4.Text = "4";
            Number4.UseVisualStyleBackColor = true;
            // 
            // Division
            // 
            Division.Dock = DockStyle.Fill;
            Division.Font = new Font("Segoe UI", 14F);
            Division.Location = new Point(210, 3);
            Division.Name = "Division";
            Division.Size = new Size(65, 55);
            Division.TabIndex = 3;
            Division.Text = "\\";
            Division.UseVisualStyleBackColor = true;
            // 
            // Number3
            // 
            Number3.Dock = DockStyle.Fill;
            Number3.Font = new Font("Segoe UI", 14F);
            Number3.Location = new Point(141, 3);
            Number3.Name = "Number3";
            Number3.Size = new Size(63, 55);
            Number3.TabIndex = 2;
            Number3.Text = "3";
            Number3.UseVisualStyleBackColor = true;
            // 
            // Number2
            // 
            Number2.Dock = DockStyle.Fill;
            Number2.Font = new Font("Segoe UI", 14F);
            Number2.Location = new Point(72, 3);
            Number2.Name = "Number2";
            Number2.Size = new Size(63, 55);
            Number2.TabIndex = 1;
            Number2.Text = "2";
            Number2.UseVisualStyleBackColor = true;
            // 
            // Number1
            // 
            Number1.Dock = DockStyle.Fill;
            Number1.Font = new Font("Segoe UI", 14F);
            Number1.Location = new Point(3, 3);
            Number1.Name = "Number1";
            Number1.Size = new Size(63, 55);
            Number1.TabIndex = 0;
            Number1.Text = "1";
            Number1.UseVisualStyleBackColor = true;
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
            // Equality
            // 
            Equality.Dock = DockStyle.Fill;
            Equality.Font = new Font("Segoe UI", 14F);
            Equality.Location = new Point(141, 186);
            Equality.Name = "Equality";
            Equality.Size = new Size(63, 58);
            Equality.TabIndex = 16;
            Equality.Text = "=";
            Equality.UseVisualStyleBackColor = true;
            // 
            // CalculatorUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 361);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(300, 400);
            Name = "CalculatorUI";
            Text = "CalculatorUI";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button Addition;
        private Button Number0;
        private Button Clear;
        private Button Difference;
        private Button Number9;
        private Button Number8;
        private Button Number7;
        private Button Multiplication;
        private Button Number6;
        private Button Number5;
        private Button Number4;
        private Button Division;
        private Button Number3;
        private Button Number2;
        private Button Number1;
        private TextBox Output;
        private Button Equality;
    }
}
