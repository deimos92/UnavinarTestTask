using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class Gate : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gateUnitPrefab;

        [SerializeField]
        private Material _gateFigureMaterial;

        [SerializeField]
        private int _gateWidth = 7;

        [SerializeField]
        private int _playerHeight = 8;

        private Vector3 _offset = new Vector3(-3.5f, 1, 0);

        private void Awake()
        {
            GenerateFigure();
        }

        private void GenerateFigure()
        {
            var array = new int[_playerHeight + 1, _gateWidth];

            for (int height = 0; height < _playerHeight + 1; height++)
            {
                for (int width = 0; width < _gateWidth; width++)
                {
                    array[height, width] = 0;
                }
            }

            for (int height = 0; height < _playerHeight + 1; height++)
            {
                array[height, 0] = 1;
                array[height, _gateWidth - 1] = 1;
            }

            for (int width = 0; width < _gateWidth - 1; width++)
            {
                array[_playerHeight, width] = 1;
            }

            for (int height = 1; height <= _playerHeight + 1; height++)
                for (int width = 1; width <= _gateWidth; width++)
                {
                    if (array[height - 1, width - 1] == 1)
                    {
                        var element = Instantiate(_gateUnitPrefab, transform);
                        element.transform.localPosition = _offset + new Vector3(width, height, 0);
                        element.GetComponentInChildren<MeshRenderer>().material = _gateFigureMaterial;
                    }
                }


        }
    }
}