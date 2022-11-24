using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class PlayerFigure : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerUnitPrefab;

        [SerializeField]
        private Material _playerFigureMaterial;

        [SerializeField]
        private int _playerHeight = 8;

        [SerializeField]
        private int _branchesCount = 4;

        [SerializeField]
        private int _gateWidth = 5;

        private Vector3 _offset = new Vector3(0.5f, 2, -0.5f);

        [SerializeField]
        private float _rotationSpeed = 500f;

        private int[,,] _figure;
        public List<int[,]> _figureSlises= new List<int[,]>();

        private void Awake()
        {            
            GenerateFigure();
            SetMaterial();
            MakeSlices();
        }

        private void SetMaterial()
        {
            var renders = GetComponentsInChildren<MeshRenderer>();
            foreach (var unit in renders)
            {
                unit.material = _playerFigureMaterial;
            }
        }

        private void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.Q))
            {
                StartCoroutine(TurnLeft());
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TurnRight());
            }*/
        }

        private IEnumerator TurnRight()
        {
            float currentAngle = 0f;
            float targetAngle = 90f;

            while (true)
            {
                float step = _rotationSpeed * Time.deltaTime;
                if (currentAngle + step > targetAngle)
                {
                    step = targetAngle - currentAngle;
                    transform.Rotate(Vector3.up, step);
                    break;
                }
                currentAngle += step;
                transform.Rotate(Vector3.up, step);
                yield return null;
            }
        }

        private IEnumerator TurnLeft()
        {
            float currentAngle = 0f;
            float targetAngle = -90f;

            while (true)
            {
                float step = -_rotationSpeed * Time.deltaTime;
                if (currentAngle + step < targetAngle)
                {
                    step = targetAngle - currentAngle;
                    transform.Rotate(Vector3.up, step);
                    break;
                }
                currentAngle += step;
                transform.Rotate(Vector3.up, step);
                yield return null;
            }
        }

        private void GenerateFigure()
        {
            int XfigureSize = _gateWidth;
            int YfigureSize = _playerHeight;
            int ZfigureSize = _gateWidth;
            
            _figure = new int[XfigureSize, YfigureSize, ZfigureSize];

            // clear array
            for (int x = 0; x < XfigureSize; x++)
            {
                for (int y = 0; y < YfigureSize; y++)
                {
                    for (int z = 0; z < ZfigureSize; z++)
                    {
                        _figure[x, y, z] = 0;
                    }
                }
            }

            int XcenterIndex = XfigureSize / 2;
            int ZcenterIndex = ZfigureSize / 2;

            
            //core
            for (int height = 0; height < YfigureSize; height++)
            {
                _figure[XcenterIndex, height, ZcenterIndex] = 1;
            }

            //branches
            for (int branchIndex = 0; branchIndex < _branchesCount; branchIndex++)
            {
                var direction = DirectionToVector(GetRandomDirection());
                var branchAtHeight = Random.Range(0, _playerHeight);
                var branchLength = Random.Range(1, XfigureSize / 2 + 1);

                for (int branchElement = 1; branchElement <= branchLength; branchElement++)
                {
                    Vector3Int coordinatsToPlace = new Vector3Int(XcenterIndex, branchAtHeight, ZcenterIndex) + (direction * branchElement);
                    _figure[coordinatsToPlace.x, coordinatsToPlace.y, coordinatsToPlace.z] = 1;                   
                }
            }

            for (int x = 0; x < XfigureSize; x++)
            {
                for (int y = 0; y < YfigureSize; y++)
                {
                    for (int z = 0; z < ZfigureSize; z++)
                    {
                        if (_figure[x, y, z] == 1)
                        {
                            var figureElement = Instantiate(_playerUnitPrefab, transform);
                            figureElement.transform.localPosition = _offset + new Vector3Int(x, y, z) - new Vector3Int(XcenterIndex, 0, ZcenterIndex);
                        }                      
                    }
                }
            }
        }


        private void MakeSlices()
        {
            int XfigureSize = _gateWidth;
            int YfigureSize = _playerHeight;
            int ZfigureSize = _gateWidth;

            int XcenterIndex = XfigureSize / 2;
            int ZcenterIndex = ZfigureSize / 2;
            
            _figureSlises.Clear();

            int[,] slice1 = new int[XfigureSize, YfigureSize];
            int[,] slice2 = new int[ZfigureSize, YfigureSize];

            for (int x = 0; x < XfigureSize; x++)
            {
                for (int y = 0; y < YfigureSize; y++)
                {
                    for (int z = 0; z < ZfigureSize; z++)
                    {
                        slice1[x, y] = _figure[x, y, ZcenterIndex];
                        slice2[z, y] = _figure[z, y, XcenterIndex];
                    }                   
                }
            }

            _figureSlises.Add(slice1);
            _figureSlises.Add(slice2);
        }
        

        private BranchDirection GetRandomDirection()
        {
            return (BranchDirection)Random.Range(0, (int)BranchDirection.NumValues);
        }

        private Vector3Int DirectionToVector(BranchDirection direction)
        {
            switch (direction)
            {
                case BranchDirection.Left: return Vector3Int.left;
                case BranchDirection.Right: return Vector3Int.right;
                case BranchDirection.Front: return Vector3Int.forward;
                case BranchDirection.Back: return Vector3Int.back;
            }

            return Vector3Int.zero;
        }

        private enum BranchDirection
        {
            Left,
            Right,
            Front,
            Back,

            NumValues
        }



    }
}