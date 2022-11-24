using System.Collections.Generic;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class Barrier : MonoBehaviour
    {
        private List<int[,]> _slices = new List<int[,]>();
        private Vector3 _offset = new Vector3(-1.5f, 2f, 0);

        [SerializeField]
        private GameObject _barrierUnitPrefab;


        private void Start()
        {
            _slices = FindObjectOfType<PlayerFigure>()._figureSlises;
            InstantiateBarrier();
        }

        private void InstantiateBarrier()
        {
            var slice = _slices[Random.Range(0, _slices.Count)];

            for (int width = 0; width < slice.GetLength(0); width++)
            {
                for (int height = 0; height < slice.GetLength(1); height++)
                {
                    if (slice[width, height] == 0)
                    {
                        var item = Instantiate(_barrierUnitPrefab, transform);
                        item.transform.localPosition = _offset + new Vector3(width, height, 0);
                    }
                }
            }
        }
    }
}
