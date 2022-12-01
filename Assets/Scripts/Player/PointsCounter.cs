using UnavinarTestTask.Assets.Scripts.Game;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Player
{
    public class PointsCounter : MonoBehaviour
    {
        private static Transform _player;
        private static int _hitsCounter = 0;
        private bool IsFinish = false;
        
        public static int CurrentPoints { get; private set; } = 0;        
        public static int CurrentMultiplier { get; private set; } = 1;


        private void Start()
        {
            PlayerUnit.OnHit += PlayerUnit_OnHit;
            PlayerFigure.OnFinish += PlayerFigure_OnFinish;
            _player = PlayerFigure.PlayerTransform;
        }

        private void PlayerFigure_OnFinish()
        {
            IsFinish = true;
        }

        private void Update()
        {
            if (!IsFinish)
            {
                if (PointsCounter.CurrentMultiplier > 1)
                {
                    var addingPoints = (int)(PlayerMover.CurrentVelocity * CurrentMultiplier * 100 * Time.deltaTime);
                    LevelUI.Instance.FlyingPoints.AddText(addingPoints, _player.position + new Vector3((int)addingPoints, Level.Instance.GameSettings.PlayerHeight, 0));
                    LevelUI.Instance.Gameplay.ShowPoints(CurrentPoints += addingPoints);
                }
            }                                 
        }

        public static void CrossingGate()
        {
            if (_hitsCounter == 0)
            {
                CurrentMultiplier += 1;
                LevelUI.Instance.Gameplay.ShowMultiplier(CurrentMultiplier);
            }
            else
            {
                CurrentMultiplier = 1;
                LevelUI.Instance.Gameplay.ShowMultiplier(CurrentMultiplier);
                _hitsCounter = 0;
            }                     
        }

        private void PlayerUnit_OnHit()
        {
            _hitsCounter += 1;
            CurrentMultiplier = 1;
        }

       
            
    }
}
