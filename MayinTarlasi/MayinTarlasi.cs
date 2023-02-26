namespace MayinTarlasi;

internal class MayinTarlasi
{
    private Size _buyukluk;
    private List<Mayin> _mayinlar;
    private int _doluMayinSayisi;
    private Random _rnd = new();
    public MayinTarlasi(Size buyukluk, int doluMayinSayisi)
    {
        _mayinlar = new List<Mayin>();
        _doluMayinSayisi = doluMayinSayisi;
        _buyukluk = buyukluk;
        for (int x = 0; x < buyukluk.Width; x = x + 20)
        {
            for (int y = 0; y < buyukluk.Height; y = y + 20)
            {
                Mayin maiyn = new(new Point(x, y));
                ListeyeMayinEkle(maiyn);
            }
        }

    }
    public Size Buyukluk
    {
        get => _buyukluk;
    }
    public List<Mayin> ButunMayinlariAl
    {
        get => _mayinlar;
    }

    public void ListeyeMayinEkle(Mayin mayin)
    {
        _mayinlar.Add(mayin);
    }
    public Mayin? MayinAl(Point location)
    {
        foreach (Mayin mayin in _mayinlar)
        {
            if (mayin.Konum == location)
                return mayin;
        }
        return null;
    }

    private void MayinlariDoldur()
    {
        int sayac = 0;
        while (sayac < _doluMayinSayisi)
        {
            int i = _rnd.Next(0, _mayinlar.Count);
            Mayin mayin = _mayinlar[i];
            if (!mayin.MayinVarMi)
            {
                mayin.MayinVarMi = true;
                sayac++;
            }
        }
    }
}
