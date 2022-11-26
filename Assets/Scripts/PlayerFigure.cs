using System.Collections.Generic;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class PlayerFigure : MonoBehaviour
    {
        private GameObject _playerUnitPrefab;
        private int _gateWidth;
        private int _playerHeight;
        private int _branchesCount;
        private Vector3 _offset;

        private int[,,] _figure;
        

        private void Awake()
        {
            SetupThis();
            FigurePlacer.PlaceFigure(_playerUnitPrefab, _figure, _offset, transform);
        }
        
        private void SetupThis()
        {
            _playerUnitPrefab = Game.instance.GameSettings.PlayerUnitPrefab;
            _gateWidth = Game.instance.GameSettings.GateWidth - 2;
            _playerHeight = Game.instance.GameSettings.PlayerHeight;
            _branchesCount = Game.instance.GameSettings.BranchesCount;
            _offset = Game.instance.GameSettings.PlayerOffset;
            _figure = Game.instance.PlayerFigureArray;
        }

        private void Update()
        {
            
        }    

        

        



    }
}