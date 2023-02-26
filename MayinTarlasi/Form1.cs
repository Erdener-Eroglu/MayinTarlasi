namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MayinTarlasi mayinTarlasi;
        private void Form1_Load(object sender, EventArgs e)
        {
            mayinTarlasi = new(new Size(400, 400), 20);
            panel1.Size = mayinTarlasi.Buyukluk;
            MayinEkle();
        }
        public void MayinEkle()
        {
            for (int x = 0; x < panel1.Width; x = x + 20)
            {
                for (int y = 0; y < panel1.Height; y = y + 20)
                {
                    ButonEkle(new Point(x, y));
                }
            }
        }

        public void ButonEkle(Point loc)
        {
            Button btn = new Button();
            btn.Name = "mayin" + ";" + loc.X + ";" + loc.Y;
            btn.Size = new Size(20, 20);
            btn.Location = loc;
            btn.Click += new EventHandler(btnClick);
            panel1.Controls.Add(btn);
        }

        private void btnClick(object? sender, EventArgs e)
        {
            
        }
    }
}