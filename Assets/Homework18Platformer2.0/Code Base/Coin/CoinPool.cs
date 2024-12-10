using System.Collections.Generic;
using UnityEngine;

namespace Homework18
{
    public class CoinPool : MonoBehaviour
    {
        [SerializeField] private List<Coin> _freeCoins;

        private void Awake()
        {
            _freeCoins = new List<Coin>();
        }

        public Coin GetFree()
        {
            Coin coin;
            
            if (_freeCoins.Count > 0)
            {
                coin = _freeCoins[0];
                _freeCoins.Remove(coin);
            }
            else
            {
                coin = null;
            }
            
            return coin;
        }

        public void AddCoin(Coin coin)
        {
            _freeCoins.Add(coin);
        }
    }
}