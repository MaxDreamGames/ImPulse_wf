using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace I_mPulse
{
    public partial class RoundPanel : UserControl
    {
        public RoundPanel()
        {
            InitializeComponent();
        }
        public int CornerRadius { get; set; } = 30; // Радиус углов

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Создаем закругленный прямоугольник
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(this.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(this.Width - CornerRadius, this.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(0, this.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseFigure();

            // Устанавливаем регион
            this.Region = new Region(path);

            // Заливка фона
            using (Brush brush = new SolidBrush(this.BackColor))
            {
                graphics.FillPath(brush, path);
            }
        }
    }
}
