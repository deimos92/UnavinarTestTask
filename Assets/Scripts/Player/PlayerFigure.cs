using UnavinarTestTask.Assets.Scripts.Game;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Player
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
            _playerUnitPrefab = Level.Instance.GameSettings.PlayerUnitPrefab;
            _offset = Level.Instance.GameSettings.PlayerOffset;
            _figure = Level.Instance.PlayerFigureArray;
        }







    }
}