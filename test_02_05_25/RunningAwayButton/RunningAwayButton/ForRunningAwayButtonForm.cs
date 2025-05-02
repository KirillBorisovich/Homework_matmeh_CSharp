// <copyright file="ForRunningAwayButtonFormm1.cs" company="BengyaKirill">
// Copyright (c) BengyaKirillMITLicense. All rights reserved.
// </copyright>

namespace RunningAwayButton
{
    /// <summary>
    /// Project form.
    /// </summary>
    public partial class ForRunningAwayButtonForm : Form
    {
        private Random rand = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ForRunningAwayButtonForm"/> class.
        /// </summary>
        public ForRunningAwayButtonForm()
        {
            this.InitializeComponent();
        }

        private void ChangeLocationButton()
        {
            const int sizeMargin = 20;
            Point mousePosition = this.PointToClient(Cursor.Position);
            var x = 0;
            var y = 0;

            do
            {
                x = this.rand.Next(this.ClientSize.Width - this.button1.Width - sizeMargin);
                y = this.rand.Next(this.ClientSize.Height - this.button1.Height - sizeMargin);
            }
            while ((Math.Abs(mousePosition.X - x) < (this.button1.Width + sizeMargin)) &&
                (Math.Abs(mousePosition.Y - y) < (this.button1.Width + sizeMargin)));

            this.button1.Location = new Point(x, y);
        }

        private void ForRunningAwayButtonForm_ResizeEnd(object sender, EventArgs e)
        {
            this.ChangeLocationButton();
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            this.ChangeLocationButton();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
