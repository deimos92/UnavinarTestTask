using UnavinarTestTask.Assets.Scripts;
using UnityEngine;

namespace UnavinarTestTask
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _direction;

        [SerializeField]
        private float _acceleration;

        [SerializeField]
        private Rigidbody _rigidBody;

        private bool isHit = false;


        private void Awake()
        {
            SetupThis();
        }        

        private void Start()
        {
            SetupOther();            
        }

        private void SetupThis()
        {

        }

        private void SetupOther()
        {
            PlayerUnit.OnHit += _playerUnit_OnHit;
        }

        private void _playerUnit_OnHit()
        {
            isHit = true;
            ShortStopAndRebound();
        }

        private void FixedUpdate()
        {
            Accelerating();
            if (isHit)
            {
                _playerUnit_OnHit();
            }
        }

        private void Accelerating()
        {
            if (_rigidBody.velocity.z < Game.instance.GameSettings.PlayerMaxSpeed)
            {
                _rigidBody.AddForce(_direction.normalized * _acceleration, ForceMode.VelocityChange);
            }            
        }

        private void ShortStopAndRebound()
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.AddForce(new Vector3(0, 0, -20), ForceMode.VelocityChange);
            isHit = false;
        }        
    }
}
