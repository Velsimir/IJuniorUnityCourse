using System;
using Homework19;

public class ObjectCounter
{
    private int _countOfAllObjects;
    private ICounter _countableObject;
    
    public ObjectCounter(ICounter countableObject)
    {
        _countableObject = countableObject;
        _countableObject.NewObjectAdded += UpdateAmountAllObjectsOnScene;
        _countableObject.ObjectSent += UpdateAllObjectsAmount;
    }

    ~ObjectCounter()
    {
        _countableObject.NewObjectAdded -= UpdateAmountAllObjectsOnScene;
        _countableObject.ObjectSent -= UpdateAllObjectsAmount;
    }

    public int CountOfAllObjects { get; private set; }
    public int CountOfAllObjectsOnScene { get; private set; }
    public int CountOfActiveObjects { get; private set; }
    
    public event Action CounterUpdated;

    private void UpdateAmountAllObjectsOnScene()
    {
        CountOfAllObjectsOnScene++;
        CountOfAllObjects++;
        CountOfActiveObjects = CountOfAllObjectsOnScene - _countableObject.Count;
        
        CounterUpdated?.Invoke();
    }

    private void UpdateAllObjectsAmount()
    {
        CountOfAllObjects++;
        
        CountOfActiveObjects = CountOfAllObjectsOnScene - _countableObject.Count;
        
        CounterUpdated?.Invoke();
    }
}
