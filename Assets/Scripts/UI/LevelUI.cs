using UnavinarTestTask.Assets.Scripts.UI;
using UnityEngine;

namespace UnavinarTestTask
{
    public class LevelUI : MonoBehaviour
    {        
        public static LevelUI Instance { get; private set; }        
        
        public GameplayLayer Gameplay;
        public ResultLayer Result;
        public FlyingPointsUI FlyingPoints;

        private void Awake()
        {
            Instance = this;           
        }

        private void Start()
        {
            foreach (var window in GetComponentsInChildren<UILayer>())
            {
                window.Close();
            }
        }

    }
}
