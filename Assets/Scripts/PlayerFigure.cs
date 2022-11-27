using System.Collections.Generic;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class PlayerFigure : MonoBehaviour
    {
        private GameObject _playerUnitPrefab;        
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
            _offset = Game.instance.GameSettings.PlayerOffset;
            _figure = Game.instance.PlayerFigureArray;
        }

        private void Update()
        {
            
        }    

        

        



    }
}