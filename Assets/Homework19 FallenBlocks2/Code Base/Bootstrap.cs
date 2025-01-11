using Homework19.BombLogic;
using UnityEngine;

namespace Homework19
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private Bomb _bombPrefab;
        [SerializeField] private CubeThrower _cubeThrower;
        [SerializeField] private CounterView _counterCubesView;
        [SerializeField] private CounterView _counterBombsView;
        
        private ObjectSpawner<Cube> _cubeSpawner;
        private ObjectSpawner<Bomb> _bombSpawner;
        
        private BombPlacer _bombPlacer;
        
        private void Awake()
        {
            _cubeSpawner = new ObjectSpawner<Cube>(_cubePrefab);
            _bombSpawner = new ObjectSpawner<Bomb>(_bombPrefab);
            
            _cubeThrower.Initialize(_cubeSpawner);

            _cubeThrower.StartWork();
            
            _bombPlacer = new BombPlacer(_bombSpawner, _cubeThrower);

            _counterCubesView.Initialize(new ObjectCounter(_cubeSpawner.Pool));
            _counterBombsView.Initialize(new ObjectCounter(_bombSpawner.Pool));
        }
    }
}