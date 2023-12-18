namespace sznikakszardosszemagad
{
    public partial class ReactionTime : Form
    {
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        private DateTime start_time, stop_time;
        private int time_to_spawn { get; set; }
        public ReactionTime()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            time_to_spawn = new Random().Next(15);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_to_spawn--;
            if (time_to_spawn <= 0)
            {
                start_time = DateTime.Now;
                this.Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (time_to_spawn <= 0)
            {
                timer1.Enabled = false;
                stop_time = DateTime.Now;
                this.Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (time_to_spawn <= 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(20, 20, 50, 50));
            }
            if (!timer1.Enabled)
            {
                string text = (stop_time - start_time).TotalMilliseconds.ToString() + " ms";
                e.Graphics.DrawString(
                    text,
                    new Font("Torus", 10, FontStyle.Bold),
                    new SolidBrush(Color.Black),
                    new RectangleF(100, 100, 100, 16)
                    );
            }
        }
    }
}
