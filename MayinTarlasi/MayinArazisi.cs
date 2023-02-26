namespace MayinTarlasi;

internal class MayinArazisi
{
    private Size _buyukluk;
    private List<Mayin> _mayinlar;
    private int _doluMayinSayisi;
    private Random _rnd = new();
    public MayinArazisi(Size buyukluk, int mayinSayisi)
    {
        _mayinlar = new List<Mayin>();
        _doluMayinSayisi = mayinSayisi;
        _buyukluk = buyukluk;
        for (int x = 0; x < buyukluk.Width; x = x + 20)
        {
            for (int y = 0; y < buyukluk.Height; y = y + 20)
            {
                Mayin myn = new(new Point(x, y));
                MayinEkle(myn);
            }
        }
        MayinlariDoldur();
    }

    public void MayinlariDoldur()
    {
        int sayi = 0;
        while (sayi < _doluMayinSayisi)
        {
            int i = _rnd.Next(0, _mayinlar.Count);
            Mayin myn = _mayinlar[i];
            if(!myn.MayinVarMi)
            {
                myn.MayinVarMi = true;
                sayi++;
            }
        }
    }

    public void MayinEkle(Mayin myn)
    {
        _mayinlar.Add(myn);
    }

    public Size Buyukluk
    {
        get => _buyukluk;
    }

    public Mayin? MayinAlKonum(Point loc)
    {
        foreach (Mayin item in _mayinlar)
        {
            if (item.KonumAl == loc)
            {
                return item;
            }
        }
        return null;
    }
    public List<Mayin> GetAllMayin
    {
        get => _mayinlar;
    }

    public int ToplamMayinSayisi
    {
        get => _doluMayinSayisi;
    }

    public int ToplamAlan
    {
        get
        {
            return (_buyukluk.Width * _buyukluk.Height) / 400;
        }
    }
}
