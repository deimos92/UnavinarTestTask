using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnavinarTestTask
{
    public class ResultLayer : UILayer
    {
        [SerializeField]
        private TextMeshProUGUI _score;

        public void ShowScore(int score)
        {
            _score.text = score.ToString();
        }

        public void OnPressedContinue()
        {
            SceneManager.LoadScene("TestScene");
        }
    }
}
