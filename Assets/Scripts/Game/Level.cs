using System.Collections.Generic;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Game
{    
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;
        public GameSettings GameSettings => _gameSettings;

        private int[,,] _playerFigureArray;
        public int[,,] PlayerFigureArray => _playerFigureArray;

        private List<int[,]> _barriersArrays;
        public List<int[,]> BarriersArrays => _barriersArrays;

        private int[,] _gateArray;
        public int[,] GateArray => _gateArray;

        private static Level _instance;
        public static Level Instance => _instance;

        private Level() { }

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.Log("More than one Game in scene!");
                return;
            }
            _instance = this;            
        }

        private void Start()
        {
            _playerFigureArray = FigureGenerator.GeneratePlayerFigureArray(_gameSettings.GateWidth - 2, _gameSettings.PlayerHeight, _gameSettings.GateWidth - 2, _gameSettings.BranchesCount);
            _barriersArrays = FigureGenerator.MakeBarriersArrays(_playerFigureArray);
            _gateArray = FigureGenerator.MakeGateArray(_gameSettings.GateWidth, _gameSettings.PlayerHeight + 1);

            LevelUI.Instance.Gameplay.Open();
            LevelUI.Instance.Gameplay.ShowLevel(14);
            LevelUI.Instance.FlyingPoints.Open();
        }
    }
}