using UnityEngine;

namespace UnavinarTestTask
{
    public class PointsCounter : MonoBehaviour
    {

        private Vector3 _startPoint;
        private Vector3 _currentPoint;        

        private float _totalPoints;
        private int _currentMultiplier = 1;

        
        private void Awake()
        {
            
        }

        private void Update()
        {
            var route = Vector3.Distance(_startPoint, _currentPoint);
        }
    }
}
