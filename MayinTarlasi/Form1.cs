namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MayinArazisi mayinTarlasi;
        Image mayinResmi = Image.FromFile(@"mayin.png");
        List<Mayin> mayinlar;
        int bulunanTemizAlan;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 800);
            YeniOyunBaslat();
            MayinlariGoster();

        }

        private void YeniOyunBaslat()
        {
            lblDurum.Text = "";
            mayinTarlasi = new MayinArazisi(new Size(400, 400), 60);
            panel1.Size = mayinTarlasi.Buyukluk;
            bulunanTemizAlan = 0;
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
            btn.Name = loc.X + "" + loc.Y;
            btn.Size = new Size(20, 20);
            btn.Location = loc;
            btn.Click += new EventHandler(btnClick);
            btn.MouseUp += new MouseEventHandler(btnMouseUp);
            panel1.Controls.Add(btn);
        }

        private void btnMouseUp(object? sender, MouseEventArgs e)
        {
            Button btn = (sender as Button);
            if (e.Button == MouseButtons.Right)
            {
                btn.Text = "!";
            }
        }

        private void btnClick(object? sender, EventArgs e)
        {
            Button btn = (sender as Button);
            Mayin myn = mayinTarlasi.MayinAlKonum(btn.Location);
            mayinlar = new List<Mayin>();
            if (myn.MayinVarMi)
            {
                MessageBox.Show("Kaybettin :(");
                MayinlariGoster();
            }
            else
            {
                int sayi = EtraftaKacMayinVar(myn);
                if (sayi == 0)
                {
                    mayinlar.Add(myn);
                    for (int i = 0; i < mayinlar.Count; i++)
                    {
                        Mayin item = mayinlar[i];
                        if (item != null)
                        {
                            if (item.BakildiMi == false && item.MayinVarMi == false)
                            {
                                Button btnx = (Button)panel1.Controls.Find(item.KonumAl.X + "" + item.KonumAl.Y, false)[0];
                                if (EtraftaKacMayinVar(mayinlar[i]) == 0)
                                {
                                    btnx.Enabled = false;
                                    CevresindekileriEkle(item);
                                }
                                else
                                {
                                    btn.Text = EtraftaKacMayinVar(item).ToString();
                                }
                                bulunanTemizAlan++;
                                item.BakildiMi = true;
                            }
                        }

                    }
                }
                else
                {
                    btn.Text = sayi.ToString();
                    bulunanTemizAlan++;
                }
            }
            if (bulunanTemizAlan >= mayinTarlasi.ToplamAlan - mayinTarlasi.ToplamMayinSayisi)
            {
                lblDurum.Text = "Kazandýnýz";
            }

        }
        public void CevresindekileriEkle(Mayin m)
        {
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            if (m.KonumAl.X > 0)
            {
                mayinlar.Add(mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X - 20, m.KonumAl.Y)));
                b1 = true;
            }
            if (m.KonumAl.Y > 0)
            {
                mayinlar.Add(mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X, m.KonumAl.Y - 20)));
                b2 = true;
            }
            if (m.KonumAl.X < panel1.Width)
            {
                mayinlar.Add(mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X + 20, m.KonumAl.Y)));
                b3 = true;
            }
            if (m.KonumAl.Y < panel1.Height)
            {
                mayinlar.Add(mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X, m.KonumAl.Y + 20)));
                b4 = true;
            }
            if (b1 && b2)
            {
                mayinlar.Add(mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X - 20, m.KonumAl.Y - 20)));
            }
            if (b1 && b4)
            {
                mayinlar.Add(mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X - 20, m.KonumAl.Y + 20)));
            }
            if (b2 && b3)
            {
                mayinlar.Add(mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X + 20, m.KonumAl.Y - 20)));
            }
            if (b2 && b4)
            {
                mayinlar.Add(mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X + 20, m.KonumAl.Y + 20)));
            }
        }
        public int EtraftaKacMayinVar(Mayin m)
        {
            int sayi = 0;
            if (m.KonumAl.X > 0)
            {
                if (mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X - 20, m.KonumAl.Y)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.Y < panel1.Height - 20 && m.KonumAl.X < panel1.Width - 20)
            {
                if (mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X + 20, m.KonumAl.Y + 20)).MayinVarMi)
                {
                    sayi++;

                }
            }
            if (m.KonumAl.X < panel1.Width - 20)
            {
                if (mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X + 20, m.KonumAl.Y)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X > 0 && m.KonumAl.Y > 0)
            {
                if (mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X - 20, m.KonumAl.Y - 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.Y > 0)
            {
                if (mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X, m.KonumAl.Y - 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X > 0 && m.KonumAl.Y < panel1.Height - 20)
            {
                if (mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X - 20, m.KonumAl.Y + 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.Y < panel1.Height - 20)
            {
                if (mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X, m.KonumAl.Y + 20)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X > panel1.Width - 20 && m.KonumAl.Y > 0)
            {
                if (mayinTarlasi.MayinAlKonum(new Point(m.KonumAl.X + 20, m.KonumAl.Y - 20)).MayinVarMi)
                {
                    sayi++;
                }
            }

            return sayi;
        }
        public void MayinlariGoster()
        {
            foreach (Mayin myn in mayinTarlasi.GetAllMayin)
            {
                if (myn.MayinVarMi)
                {
                    Button btn = (Button)panel1.Controls.Find(myn.KonumAl.X + "" + myn.KonumAl.Y, false)[0];
                    btn.BackgroundImage = mayinResmi;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            YeniOyunBaslat();
        }
    }
}