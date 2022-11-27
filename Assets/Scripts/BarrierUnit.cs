using System;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class BarrierUnit : MonoBehaviour
    {
        private Rigidbody _rootRigidbody;
        private int _hitsCount;
        private int _maxHitsCount;

        

        private void Awake()
        {
            _maxHitsCount = Game.instance.GameSettings.MaxHitsCount;
            _rootRigidbody = GetComponentInParent<Rigidbody>();
            _hitsCount = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            _hitsCount++;
            if (_hitsCount >= _maxHitsCount)
            {
                _rootRigidbody.isKinematic = false;
                _rootRigidbody.useGravity = true;
                _rootRigidbody.AddForce(-new Vector3(0, 0, 50), ForceMode.Impulse);                
            }

            if (other.gameObject.layer == 8)
            {
                Destroy(gameObject);
            }
        }
    }
}
