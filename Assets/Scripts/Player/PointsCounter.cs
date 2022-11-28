using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Player
{
    public class PointsCounter : MonoBehaviour
    {

        private Vector3 _startPoint;
        private Vector3 _currentPoint;

        private int _hitsCounter = 0;

        private float _totalPoints;
        private int _currentMultiplier = 1;        
        

        private void Update()
        {
            _totalPoints += PlayerMover.CurrentVelocity * 100 * Time.deltaTime;
            Debug.Log(_totalPoints);
        }
    }
}
