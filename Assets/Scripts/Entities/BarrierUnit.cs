using UnityEngine;
using UnavinarTestTask.Assets.Scripts.Game;

namespace UnavinarTestTask.Assets.Scripts.Entities
{
    public class BarrierUnit : MonoBehaviour
    {
        private Rigidbody _rootRigidbody;
        private int _hitsCount = 0;
        private int _maxHitsCount;        

        private void Start()
        {
            _maxHitsCount = Level.Instance.GameSettings.MaxHitsCount;
            _rootRigidbody = GetComponentInParent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 6)
            {
                _hitsCount++;
                if (_hitsCount >= _maxHitsCount)
                {
                    _rootRigidbody.isKinematic = false;
                    _rootRigidbody.useGravity = true;
                    _rootRigidbody.AddForce(-new Vector3(0, 0, 50), ForceMode.Impulse);
                }
            }

            if (other.gameObject.layer == 10)
            {
                Destroy(gameObject);
            }
        }
    }
}
