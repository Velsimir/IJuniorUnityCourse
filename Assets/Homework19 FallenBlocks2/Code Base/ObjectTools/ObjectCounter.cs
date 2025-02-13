using System;
using Homework19;

public class ObjectCounter : IDisposable
{
    private int _countOfAllObjects;
    private ICounter _countableObject;
    
    private bool _isDisposed;
    
    public ObjectCounter(ICounter countableObject)
    {
        _countableObject = countableObject;
        _countableObject.NewObjectAdded += UpdateAmountAllObjectsOnScene;
        _countableObject.ObjectSent += UpdateAllObjectsAmount;
        _isDisposed = false;
    }

    public void Dispose()
    {
        if (_isDisposed)
            return;
        
        _countableObject.NewObjectAdded -= UpdateAmountAllObjectsOnScene;
        _countableObject.ObjectSent -= UpdateAllObjectsAmount;
        _isDisposed = true;
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
