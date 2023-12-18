namespace bluesqr
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        Color color = Color.FromArgb(255, 0, 255, 0);
        int G = 255, B = 0;
        public Form1()
        {
            InitializeComponent();
            this.KeyPress += key_press_event;
            this.Paint += paint_event;
            timer1.Interval = 100;
            timer1.Tick += timer1_tick_event;
        }

        private void paint_event(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(new SolidBrush(color), new Rectangle(30, 50, 50, 50));
        }

        private void key_press_event(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's') timer1.Start();
        }

        private void timer1_tick_event(object sender, EventArgs e)
        {
            this.Invalidate();
            G -= 15;
            B += 15;
            color = Color.FromArgb(255, 0, G, B);
        }
    }
}
