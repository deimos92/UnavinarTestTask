using UnavinarTestTask.Assets.Scripts.Game;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _direction;

        [SerializeField]
        private float _acceleration = 0.01f;
                
        private static float _currentVelocity;
        public static float CurrentVelocity => _currentVelocity;

        private bool isHit = false;
        private bool isFinished = false;


        private void Start()
        {
            SetupOther();
        }

        private void SetupOther()
        {
            PlayerUnit.OnHit += PlayerUnit_OnHit;
            PlayerFigure.OnFinish += PlayerFigure_OnFinish;            
        }

        private void PlayerFigure_OnFinish()
        {
            isFinished = true;
            StopAndRotate();
        }        

        private void PlayerUnit_OnHit()
        {
            isHit = true;
            ShortStopAndRebound();
        }

        private void FixedUpdate()
        {
            if (!isFinished)
            {
                Accelerating();
                if (isHit)
                {
                    PlayerUnit_OnHit();
                }
            }
            else
            {
                PlayerFigure_OnFinish();
            }            
        }

        private void Accelerating()
        {
            if (PointsCounter.CurrentMultiplier > 1)
            {
                if (_currentVelocity < (Level.Instance.GameSettings.PlayerMaxSpeed * PointsCounter.CurrentMultiplier)/2)
                {
                    _currentVelocity += (_acceleration * Time.fixedDeltaTime) / 2;
                }
            }
            else
            {
                if (_currentVelocity < Level.Instance.GameSettings.PlayerMaxSpeed)
                {
                    _currentVelocity += (_acceleration * Time.fixedDeltaTime) / 2;
                }
            }                        

            transform.position += Vector3.forward * _currentVelocity;
        }

        private void ShortStopAndRebound()
        {
            _currentVelocity = -0.3f;
            isHit = false;
        }

        private void StopAndRotate()
        {
            _currentVelocity = 0;
            transform.Rotate(Vector3.up, 50f * Time.deltaTime);
        }
    }
}
