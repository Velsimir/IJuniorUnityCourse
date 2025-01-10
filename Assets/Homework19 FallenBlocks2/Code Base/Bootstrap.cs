using Homework19.BombLogic;
using UnityEngine;

namespace Homework19
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private Bomb _bombPrefab;
        [SerializeField] private CubeThrower _cubeThrower;
        
        private ObjectSpawner<Cube> _cubeSpawner;
        private ObjectPool<Cube> _cubesPool;
        
        private ObjectSpawner<Bomb> _bombSpawner;
        private ObjectPool<Bomb> _bombPool;
        
        private BombPlacer _bombPlacer;
        
        private void Awake()
        {
            _cubeSpawner = new ObjectSpawner<Cube>();
            _cubesPool = new ObjectPool<Cube>();
            _bombSpawner = new ObjectSpawner<Bomb>();
            _bombPool = new ObjectPool<Bomb>();
            
            _cubeSpawner.Initialize(_cubePrefab);
            _cubesPool.Initialize();
            
            _bombSpawner.Initialize(_bombPrefab);
            _bombPool.Initialize();
            
            _cubeThrower.Initialize(_cubeSpawner, _cubesPool);
            _bombPlacer = new BombPlacer(_bombSpawner, _bombPool, _cubeThrower);
            
            _cubeThrower.StartWork();
        }
    }
}