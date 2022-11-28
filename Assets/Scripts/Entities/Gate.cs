using System;
using UnityEngine;
using UnavinarTestTask.Assets.Scripts.Game;

namespace UnavinarTestTask.Assets.Scripts.Entities
{
    public class Gate : MonoBehaviour
    {
        private GameObject _gateUnitPrefab;
        private Vector3 _offset;
        private int[,] _gateArray;
        private BoxCollider _collider;

        public event Action OnCrossing;

        private void Awake()
        {
            SetupThis();
        }

        private void SetupThis()
        {
            var gameSettings = Level.Instance.GameSettings;

            _gateUnitPrefab = gameSettings.GateUnitPrefab;
            _offset = gameSettings.GateOffset;
            _gateArray = Level.Instance.GateArray;
            FigurePlacer.PlaceFigure(_gateUnitPrefab, _gateArray, _offset, transform);

            _collider = GetComponent<BoxCollider>();
            _collider.size = new Vector3(gameSettings.GateWidth, gameSettings.PlayerHeight + 1, 1);

            _collider.center = new Vector3(0, 6.5f, 0.5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnCrossing?.Invoke();
        }
    }
}