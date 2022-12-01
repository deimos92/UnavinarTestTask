using System;
using UnavinarTestTask.Assets.Scripts.Game;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Player
{
    public class PlayerFigure : MonoBehaviour
    {
        private GameObject _playerUnitPrefab;
        private Vector3 _offset;

        private int[,,] _figure;

        public static Transform PlayerTransform { get; private set; }
        public static event Action OnFinish;      


        private void Awake()
        {
            SetupThis();            
        }

        private void SetupThis()
        {
            PlayerTransform = transform;
            _playerUnitPrefab = Level.Instance.GameSettings.PlayerUnitPrefab;
            _offset = Level.Instance.GameSettings.PlayerOffset;
            _figure = Level.Instance.PlayerFigureArray;
            FigurePlacer.PlaceFigure(_playerUnitPrefab, _figure, _offset, transform);
        }       

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == 11)
            {
                OnFinish?.Invoke();
                LevelUI.Instance.Gameplay.Close();
                LevelUI.Instance.FlyingPoints.Close();
                LevelUI.Instance.Result.Open();
                LevelUI.Instance.Result.ShowScore(PointsCounter.CurrentPoints);
            }
        }







    }
}