using System.Collections;
using UnityEngine;
using UnavinarTestTask.Assets.Scripts.Game;
using UnavinarTestTask.Assets.Scripts.Player.Input;

namespace UnavinarTestTask.Assets.Scripts.Player
{
    public class Rotator : MonoBehaviour
    {
        private Transform _objectToRotate;
        private float _rotationSpeed;

        private void Awake()
        {
            _objectToRotate = transform;
            _rotationSpeed = Level.Instance.GameSettings.RotationSpeed;

            SwipeDetection.OnSwipeLeft += SwipeDetection_OnSwipeLeft;
            SwipeDetection.OnSwipeRight += SwipeDetection_OnSwipeRight;
        }

        private void SwipeDetection_OnSwipeRight()
        {
            StartCoroutine(TurnRight());
        }

        private void SwipeDetection_OnSwipeLeft()
        {
            StartCoroutine(TurnLeft());
        }

        public IEnumerator TurnRight()
        {
            float currentAngle = 0f;
            float targetAngle = 90f;

            while (true)
            {
                float step = _rotationSpeed * Time.deltaTime;
                if (currentAngle + step > targetAngle)
                {
                    step = targetAngle - currentAngle;
                    _objectToRotate.Rotate(Vector3.up, step);
                    break;
                }
                currentAngle += step;
                _objectToRotate.Rotate(Vector3.up, step);
                yield return null;
            }
        }

        public IEnumerator TurnLeft()
        {
            float currentAngle = 0f;
            float targetAngle = -90f;

            while (true)
            {
                float step = -_rotationSpeed * Time.deltaTime;
                if (currentAngle + step < targetAngle)
                {
                    step = targetAngle - currentAngle;
                    _objectToRotate.Rotate(Vector3.up, step);
                    break;
                }
                currentAngle += step;
                _objectToRotate.Rotate(Vector3.up, step);
                yield return null;
            }
        }
    }
}
