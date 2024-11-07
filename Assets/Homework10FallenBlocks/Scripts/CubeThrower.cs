using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework10FallenBlocks
{
    [RequireComponent(typeof(BoxCollider))]
    public class CubeThrower : MonoBehaviour
    {
        [SerializeField] private Cube _cubesPrefab;
        [SerializeField] private int _cubesAmount;
        [SerializeField] private List<Cube> _cubes;
        [SerializeField] private float _delay;

        private Collider _spawnArea;
        private float _xMinPosition;
        private float _xMaxPosition;
        private float _zMinPosition;
        private float _zMaxPosition;
        
        private void Awake()
        {
            _spawnArea = GetComponent<Collider>();
            
            _xMinPosition = _spawnArea.bounds.min.x;
            _xMaxPosition = _spawnArea.bounds.max.x;
            _zMinPosition = _spawnArea.bounds.min.z;
            _zMaxPosition = _spawnArea.bounds.max.z;

            Fill();
            
            StartCoroutine(Initialize());
        }

        private IEnumerator Initialize()
        {
            WaitForSeconds wait = new WaitForSeconds(_delay);
            
            while (true)
            {
                Cube cube = GetFreeCube();

                if (cube != null)
                    cube.Refresh(GetRandomPosition());
                
                yield return wait;
            }
        }

        private Cube GetFreeCube()
        {
            foreach (var cube in _cubes)
            {
                if (cube.isActiveAndEnabled == false)
                {
                    return cube;
                }
            }

            return null;
        }

        private void RespawnCube(Cube cube)
        {
            cube.Refresh(GetRandomPosition());
        }

        private Vector3 GetRandomPosition()
        {
            float xPosition = Random.Range(_xMinPosition, _xMaxPosition);
            float yPosition = transform.position.y - 1;
            float zPosition = Random.Range(_zMinPosition, _zMaxPosition);

            return new Vector3(xPosition, yPosition, zPosition);
        }

        private void Fill()
        {
            for (int i = 0; i < _cubesAmount; i++)
            {
                Cube cube = Instantiate(_cubesPrefab);
                _cubes.Add(cube);
                cube.gameObject.SetActive(false);
            }
        }
    }
}