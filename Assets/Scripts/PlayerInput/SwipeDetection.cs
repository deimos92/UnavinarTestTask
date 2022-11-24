using System;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.PlayerInput
{
    public class SwipeDetection : MonoBehaviour
    {
        [SerializeField]
        private InputHandler _inputHandler;

        [SerializeField]
        private float _minimumDistance = .2f;

        [SerializeField]
        private float _maximumTime = 1f;

        [SerializeField, Range(0f, 1f)]
        private float _directionThreshold = .9f;

        private Vector2 _startPosition;
        private float _startTime;

        private Vector2 _endPosition;
        private float _endTime;

        private void Awake()
        {

        }

        private void OnEnable()
        {
            _inputHandler.OnStartTouch += SwipeStart;
            _inputHandler.OnEndTouch += SwipeEnd;
        }

        private void OnDisable()
        {
            _inputHandler.OnStartTouch -= SwipeStart;
            _inputHandler.OnEndTouch -= SwipeEnd;
        }

        private void SwipeStart(Vector2 position, float time)
        {
            _startPosition = position;
            _startTime = time;
        }

        private void SwipeEnd(Vector2 position, float time)
        {
            _endPosition = position;
            _endTime = time;
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            if (Vector3.Distance(_startPosition, _endPosition) >= _minimumDistance && (_endTime - _startTime) <= _maximumTime)
            {
                Debug.DrawLine(_startPosition, _endPosition, Color.red, 5f);
                Vector3 direction = _endPosition - _startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(direction2D);
            }
        }

        private void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.up, direction) > _directionThreshold)
            {
                Debug.Log("Swipe UP");
            }
            else if (Vector2.Dot(Vector2.down, direction) > _directionThreshold)
            {
                Debug.Log("Swipe DOWN");
            }
            else if (Vector2.Dot(Vector2.left, direction) > _directionThreshold)
            {
                Debug.Log("Swipe LEFT");
            }
            else if (Vector2.Dot(Vector2.right, direction) > _directionThreshold)
            {
                Debug.Log("Swipe RIGHT");
            }
        }
    }
}
