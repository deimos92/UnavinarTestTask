using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class Gate : MonoBehaviour
    {
        private GameObject _gateUnitPrefab;
        private int _gateHeight;
        private int _gateWidth;
        private Vector3 _offset;
        private int[,] _gateArray;
        
        private void Awake()
        {
            SetupThis();
            FigurePlacer.PlaceFigure(_gateUnitPrefab, _gateArray, _offset, transform);
        }

        private void SetupThis()
        {
            _gateUnitPrefab = Game.instance.GameSettings.GateUnitPrefab;
            _gateHeight = Game.instance.GameSettings.PlayerHeight + 1;
            _gateWidth = Game.instance.GameSettings.GateWidth;
            _offset = Game.instance.GameSettings.GateOffset;

            _gateArray = Game.instance.GateArray;
        }
    }
}