using System;
using UnityEngine;
using UnavinarTestTask.Assets.Scripts.Game;

namespace UnavinarTestTask.Assets.Scripts.Player
{
    public class PlayerUnit : MonoBehaviour
    {
        private int _hitsCount;
        private int _maxHitsCount;

        public static event Action OnHit;
        

        private void Awake()
        {
            _maxHitsCount = Level.Instance.GameSettings.MaxHitsCount;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 8)
            {
                if (_hitsCount <= _maxHitsCount)
                {
                    OnHit?.Invoke();
                }
            }            
        }
    }
}
