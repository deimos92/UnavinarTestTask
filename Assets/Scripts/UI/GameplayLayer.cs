using TMPro;
using UnavinarTestTask.Assets.Scripts.UI;
using UnityEngine;

namespace UnavinarTestTask
{
    public class GameplayLayer : UILayer
    {
        [SerializeField]
        private TextMeshProUGUI _levelLabel;

        [SerializeField]
        private TextMeshProUGUI _currentPoints;

        [SerializeField]
        private MultiplierUI _currentMultiplier;

        public void ShowLevel(int level)
        {
            _levelLabel.text = $"Level {level}";
        }

        public void ShowPoints(int currentPoints)
        {
            _currentPoints.text = currentPoints.ToString();
        }

        public void ShowMultiplier(int multiplier)
        {
            _currentMultiplier.ShowMultiplier(multiplier);
        }

        
    }
}
