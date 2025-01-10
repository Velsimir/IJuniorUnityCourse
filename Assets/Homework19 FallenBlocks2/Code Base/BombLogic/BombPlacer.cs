using UnityEngine;

namespace Homework19.BombLogic
{
    public class BombPlacer
    {
        private ObjectSpawner<Bomb> _spawner;
        private ObjectPool<Bomb> _pool;
        private CubeThrower _cubeThrower;
        private Bomb _bomb;

        public BombPlacer(ObjectSpawner<Bomb> objectSpawner, ObjectPool<Bomb> pool, CubeThrower cubeThrower)
        {
            _spawner = objectSpawner;
            _pool = pool;
            _cubeThrower = cubeThrower;
            _cubeThrower.OnCubeSpawned += AcceptParentCube;
        }

        private void Spawn(Cube cube)
        {
            Bomb bomb;

            if (_pool.HasFreeObject)
            {
                bomb = _pool.GetFreeObject();
                SetPlace(bomb, cube.transform.position, cube.transform.rotation);
                bomb.StartWork();
            }
            else
            {
                bomb = _spawner.Spawn();
                SetPlace(bomb, cube.transform.position, cube.transform.rotation);
                bomb.StartWork();
                _pool.TrackNewObject(bomb);
            }
            
            cube.Disappeared -= Spawn;
        }

        private void AcceptParentCube(Cube cube)
        {
            cube.Disappeared += Spawn;
        }

        private Bomb SetPlace(Bomb bomb, Vector3 position, Quaternion rotation)
        {
            bomb.transform.position = position;
            bomb.transform.rotation = rotation;

            return bomb;
        }
    }
}