using TMPro;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.UI
{
    public class MultiplierUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _currentMultiplier;
        [SerializeField]
        private Animator _animator;

        private const string BOOL_KEY = "IsShown";        

        public void ShowMultiplier(int currentMultiplier)
        {
            _currentMultiplier.text = $"X{currentMultiplier}";
            if (currentMultiplier <= 1)
            {
                _animator.SetBool(BOOL_KEY, false);                
            }
            else
            {
                _animator.SetBool(BOOL_KEY, true);
            }            
        }


        


    }
}
