using UnityEngine;

namespace Homework19.BombLogic
{
    public class BombPlacer
    {
        private ObjectSpawner<Bomb> _spawner;
        private CubeThrower _cubeThrower;
        private Bomb _bomb;

        public BombPlacer(ObjectSpawner<Bomb> objectSpawner, CubeThrower cubeThrower)
        {
            _spawner = objectSpawner;
            _cubeThrower = cubeThrower;
            _cubeThrower.OnCubeSpawned += AcceptParentCube;
        }

        private void Spawn(Cube cube)
        {
            Bomb bomb;

            bomb = _spawner.Spawn();

            SetPlace(bomb, cube.transform.position, cube.transform.rotation);
            bomb.StartWork();
            
            cube.Disappeared -= Spawn;
        }

        private void AcceptParentCube(Cube cube)
        {
            cube.Disappeared += Spawn;
        }

        private void SetPlace(Bomb bomb, Vector3 position, Quaternion rotation)
        {
            bomb.transform.position = position;
            bomb.transform.rotation = rotation;
        }
    }
}