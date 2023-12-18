namespace Square
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        private int DIM { get; set; } = 60;
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.paint_event);
            this.KeyPress += new KeyPressEventHandler(this.key_event);
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(this.timer_tick_event);
            timer1.Start();
        }

        private void timer_tick_event(Object sender, EventArgs e)
        {
            this.Invalidate();
            DIM -= 5;
        }

        private void paint_event(Object sender, PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(20, 20, DIM, DIM);
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), rectangle);
        }

        private void key_event(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'x')
            {
                timer1.Enabled = false;
            }
        }
    }
}
