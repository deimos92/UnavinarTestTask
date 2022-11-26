using System.Collections.Generic;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    [DefaultExecutionOrder(-1)]
    public class Game : MonoBehaviour
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


        public static Game instance; 
        private Game() { }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("More than one Game in scene!");
                return;
            }
            instance = this;

            _playerFigureArray = FigureGenerator.GeneratePlayerFigureArray(_gameSettings.GateWidth - 2,_gameSettings.PlayerHeight, _gameSettings.GateWidth - 2, _gameSettings.BranchesCount);
            _barriersArrays = FigureGenerator.MakeBarriersArrays(_playerFigureArray);
            _gateArray = FigureGenerator.MakeGateArray(_gameSettings.GateWidth, _gameSettings.PlayerHeight + 1);
        }
    }
}