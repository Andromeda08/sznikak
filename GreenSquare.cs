namespace greensquare
{
    public partial class GreenSquare : Form
    {
        private const int rect_size = 10;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private Rectangle rectangle  = new Rectangle(100, 100, rect_size, rect_size);
        private Brush green_brush    = new SolidBrush(Color.Green);
        private int pos_changes { get; set; } = 0;
        public GreenSquare()
        {
            InitializeComponent();

            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.timer_tick_event);

            this.Paint += new PaintEventHandler(this.form_paint_event);
            this.KeyPress += new KeyPressEventHandler(this.form_key_press_event);
        }

        private void timer_tick_event(object sender, EventArgs e)
        {
            Point new_location = new Point(new Random().Next(0, this.Width - rect_size), new Random().Next(0, this.Height - rect_size));

            if (new_location != rectangle.Location) pos_changes++;
            rectangle.Location = new_location;
            Invalidate();
        }

        private void form_paint_event(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(
                pos_changes.ToString(),
                new Font("Torus", 12, FontStyle.Bold),
                new SolidBrush(Color.Black),
                new RectangleF(10, 10, 100, 16)
                );

            e.Graphics.FillRectangle(green_brush, rectangle);
        }

        private void form_key_press_event(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's') timer.Start();
        }
    }
}
