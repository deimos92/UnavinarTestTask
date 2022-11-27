using System;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class PlayerUnit : MonoBehaviour
    {
        private int _hitsCount;
        private int _maxHitsCount;

        public static event Action OnHit;

        private void Awake()
        {
            _maxHitsCount = Game.instance.GameSettings.MaxHitsCount;             
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_hitsCount <= _maxHitsCount)
            {
                OnHit?.Invoke();
            }
        }
    }
}
