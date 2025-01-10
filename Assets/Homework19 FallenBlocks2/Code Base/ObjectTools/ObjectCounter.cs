using System;
using Homework19;

public class ObjectCounter
{
    private int _countOfAllObjects;
    public int CountOfAllObjects { get; private set; }
    public int CountOfAllObjectsOnScene { get; private set; }
    public int CountOfActiveObjects { get; private set; }
    
    private ICounter _counter;
    
    public ObjectCounter(ICounter counter)
    {
        _counter = counter;
        _counter.NewObjectAdded += UpdateAmountAllObjectsOnScene;
        _counter.ObjectSent += UpdateAllObjectsAmount;
    }

    ~ObjectCounter()
    {
        _counter.NewObjectAdded -= UpdateAmountAllObjectsOnScene;
        _counter.ObjectSent -= UpdateAllObjectsAmount;
    }

    public event Action CounterUpdated;

    private void UpdateAmountAllObjectsOnScene()
    {
        CountOfAllObjectsOnScene++;
        CountOfAllObjects++;
        CountOfActiveObjects = CountOfAllObjectsOnScene - _counter.Count;
        
        CounterUpdated?.Invoke();
    }

    private void UpdateAllObjectsAmount()
    {
        CountOfAllObjects++;
        
        CountOfActiveObjects = CountOfAllObjectsOnScene - _counter.Count;
        
        CounterUpdated?.Invoke();
    }
}
