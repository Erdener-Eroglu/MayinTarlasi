namespace MayinTarlasi;

internal class Mayin
{
    private Point _loc;
    private bool _doluMu;
    private bool _bakildiMi;
    public Mayin(Point loc)
    {
        _doluMu = false;
        _loc = loc;
    }
    public Point Konum
    { 
        get => _loc;
    }
    public bool MayinVarMi
    {
        get => _doluMu;
        set => _doluMu = value;
    }
    public bool BakildiMi
    {
        get => _bakildiMi;
        set => _bakildiMi = value;
    }
}
