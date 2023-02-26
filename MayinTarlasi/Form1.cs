namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MayinArazisi mayinTarlamiz;
        Image mayinResmi = Image.FromFile(@"mayin.png");
        List<Mayin> mayinlarimiz;
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
            mayinTarlamiz = new MayinArazisi(new Size(625, 625), 40);
            panel1.Size = mayinTarlamiz.Buyukluk;
            bulunanTemizAlan = 0;
            MayinEkle();
        }

        public void MayinEkle()
        {
            for (int x = 0; x < panel1.Width; x = x + 25)
            {
                for (int y = 0; y < panel1.Height; y = y + 25)
                {
                    ButonEkle(new Point(x, y));
                }
            }
        }

        public void ButonEkle(Point loc)
        {
            Button btn = new Button();
            btn.Name = loc.X + "" + loc.Y;
            btn.Size = new Size(25, 25);
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
            Mayin myn = mayinTarlamiz.MayinAlKonum(btn.Location);
            mayinlarimiz = new List<Mayin>();
            if (myn.MayinVarMi)
            {
                MessageBox.Show("Kaybettin");
                MayinlariGoster();
            }
            else
            {
                int s = EtraftaKacMayinVar(myn);
                if (s == 0)
                {

                    mayinlarimiz.Add(myn);
                    for (int i = 0; i < mayinlarimiz.Count; i++)
                    {
                        Mayin item = mayinlarimiz[i];
                        if (item != null)
                        {
                            if (item.BakildiMi == false && item.MayinVarMi == false)
                            {
                                Button btnx = (Button)panel1.Controls.Find(item.KonumAl.X + "" + item.KonumAl.Y, false)[0];
                                if (EtraftaKacMayinVar(mayinlarimiz[i]) == 0)
                                {

                                    btnx.Enabled = false;

                                    CevresindekileriEkle(item);
                                }
                                else
                                {
                                    btnx.Text = EtraftaKacMayinVar(item).ToString();

                                }
                                bulunanTemizAlan++;
                                item.BakildiMi = true;
                            }
                        }
                    }
                }
                else
                {
                    btn.Text = s.ToString();
                    bulunanTemizAlan++;
                }

            }
            if (bulunanTemizAlan >= mayinTarlamiz.ToplamAlan - mayinTarlamiz.ToplamMayinSayisi)
            {
                lblDurum.Text = "Kazandýnýz";
            }

        }
        public int EtraftaKacMayinVar(Mayin m)
        {
            int sayi = 0;
            if (m.KonumAl.X > 0)
            {
                if (mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X - 25, m.KonumAl.Y)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.Y < panel1.Height - 25 && m.KonumAl.X < panel1.Width - 25)
            {
                if (mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X + 25, m.KonumAl.Y + 25)).MayinVarMi)
                {
                    sayi++;

                }
            }
            if (m.KonumAl.X < panel1.Width - 25)
            {
                if (mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X + 25, m.KonumAl.Y)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X > 0 && m.KonumAl.Y > 0)
            {
                if (mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X - 25, m.KonumAl.Y - 25)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.Y > 0)
            {
                if (mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X, m.KonumAl.Y - 25)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X > 0 && m.KonumAl.Y < panel1.Height - 25)
            {
                if (mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X - 25, m.KonumAl.Y + 25)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.Y < panel1.Height - 25)
            {
                if (mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X, m.KonumAl.Y + 25)).MayinVarMi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X > panel1.Width - 25 && m.KonumAl.Y > 0)
            {
                if (mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X + 25, m.KonumAl.Y - 25)).MayinVarMi)
                {
                    sayi++;
                }
            }

            return sayi;
        }
        public void CevresindekileriEkle(Mayin m)
        {
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            if (m.KonumAl.X > 0)
            {
                mayinlarimiz.Add(mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X - 25, m.KonumAl.Y)));
                b1 = true;
            }
            if (m.KonumAl.Y > 0)
            {
                mayinlarimiz.Add(mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X, m.KonumAl.Y - 25)));
                b2 = true;
            }
            if (m.KonumAl.X < panel1.Width)
            {
                mayinlarimiz.Add(mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X + 25, m.KonumAl.Y)));
                b3 = true;
            }
            if (m.KonumAl.Y < panel1.Height)
            {
                mayinlarimiz.Add(mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X, m.KonumAl.Y + 25)));
                b4 = true;
            }
            if (b1 && b2)
            {
                mayinlarimiz.Add(mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X - 25, m.KonumAl.Y - 25)));
            }
            if (b1 && b4)
            {
                mayinlarimiz.Add(mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X - 25, m.KonumAl.Y + 25)));
            }
            if (b2 && b3)
            {
                mayinlarimiz.Add(mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X + 25, m.KonumAl.Y - 25)));
            }
            if (b2 && b4)
            {
                mayinlarimiz.Add(mayinTarlamiz.MayinAlKonum(new Point(m.KonumAl.X + 25, m.KonumAl.Y + 25)));
            }

        }

        public void MayinlariGoster()
        {
            foreach (Mayin item in mayinTarlamiz.GetAllMayin)
            {
                if (item.MayinVarMi)
                {
                    Button btn = (Button)panel1.Controls.Find(item.KonumAl.X + "" + item.KonumAl.Y, false)[0];
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