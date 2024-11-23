using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    public class CoinPool : MonoBehaviour
    {
        [SerializeField] private List<Coin> _freeCoins;

        public bool HasFreeCoins { get { return _freeCoins.Count > 0; } }

        private void Awake()
        {
            _freeCoins = new List<Coin>();
        }

        public Coin GetFree()
        {
            Coin coin = _freeCoins[0];
            _freeCoins.Remove(coin);
            
            return coin;
        }

        public void AddCoin(Coin coin)
        {
            _freeCoins.Add(coin);
        }
    }
}