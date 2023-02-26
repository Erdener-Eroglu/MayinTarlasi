public class Mayin
{
    private Point _loc;
    private bool _doluMu;
    private bool _bakildiMi;
    public Mayin(Point loca)
    {
        _doluMu = false;
        _loc = loca;
    }
    public Point KonumAl
    {
        get => _loc;
    }
    public bool MayinVarMi
    {
        get => _doluMu;
        
        set
        {
            _doluMu = value;
        }
    }
    public bool BakildiMi
    {
        get => _bakildiMi;
        set
        {
            _bakildiMi = value;
        }
    }
}