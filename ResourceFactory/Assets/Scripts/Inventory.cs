
public class Inventory
{
    private int _maxCapacity;
    private int _currentCapacity;

    public int MaxCapacity => _maxCapacity;
    public int CurrentCapacity => _currentCapacity;

    public Inventory(int maxCapacity)
    {
        _maxCapacity = maxCapacity;
    }

    public void LoadItem()
    {
        if (_currentCapacity < _maxCapacity)
        {
            _currentCapacity++;
        }
        else
        {
            throw new System.AggregateException("Inventory over load");
        }
    }

    public void UploadItem()
    {
        if (_currentCapacity > 0)
        {
            _currentCapacity--;
        }
        else
        {
            throw new System.AggregateException("Inventory empty");
        }
        
    }

 
}
