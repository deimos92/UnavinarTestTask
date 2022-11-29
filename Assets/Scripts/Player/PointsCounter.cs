using UnavinarTestTask.Assets.Scripts.Entities;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Player
{
    public class PointsCounter : MonoBehaviour
    {
        private int _hitsCounter = 0;
        private float _totalPoints;
        private int _currentMultiplier = 1;




        private void Start()
        {
            PlayerUnit.OnHit += PlayerUnit_OnHit;            
        }

        public void CrossingGate()
        {
            if (_hitsCounter == 0)
            {
                _currentMultiplier += 1;
            }

            _hitsCounter = 0;
        }

        private void PlayerUnit_OnHit()
        {
            _hitsCounter += 1;
            _currentMultiplier = 1;
        }

        private void Update()
        {
            _totalPoints += PlayerMover.CurrentVelocity * _currentMultiplier * 100 * Time.deltaTime;
           Debug.Log($"_totalPoints {_totalPoints}, _hitsCounter {_hitsCounter}, _currentMultiplier {_currentMultiplier}");
        }
    }
}
