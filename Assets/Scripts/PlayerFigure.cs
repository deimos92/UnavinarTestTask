using System.Collections;
using UnityEngine;

public class PlayerFigure : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerUnitPrefab;

    [SerializeField]
    private Material _playerFigureMaterial;

    [SerializeField]
    private int _playerHeight = 8;

    [SerializeField]
    private int _gateWidth = 5;

    [SerializeField]
    private int _branchesCount = 4;

    [SerializeField]
    private Vector3 _pivot = new Vector3(0.5f, 0, -0.5f);

    [SerializeField]
    private float _rotationSpeed = 3f;



    private void Awake()
    {
        GenerateFigure();
        SetMaterial();       
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(TurnLeft());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(TurnRight());
        }
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
            float step = - _rotationSpeed * Time.deltaTime;
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
        for (int i = 0; i < _playerHeight; i++)
        {
            var element = Instantiate(_playerUnitPrefab, transform);
            element.transform.localPosition = _pivot + new Vector3(0, i, 0);
        }

        for (int i = 0; i < _branchesCount; i++)
        {         
            MakeBranch();
        }
    }

    private void MakeBranch()
    {
        var direction = DirectionToVector(GetRandomDirection());
        var branchAtHeight = Random.Range(0, _playerHeight);
        var branchLength = Random.Range(1, ((_gateWidth - 1) / 2 + 1));

        for (int i = 1; i <= branchLength; i++)
        {           
            var element = Instantiate(_playerUnitPrefab, transform);
            element.transform.localPosition = _pivot + new Vector3(0, branchAtHeight, 0) + direction * i;
        }
    }

    private BranchDirection GetRandomDirection()
    {
        return (BranchDirection)Random.Range(0, (int)BranchDirection.NumValues);
    }

    private Vector3 DirectionToVector(BranchDirection direction)
    {
        switch (direction)
        {
            case BranchDirection.Left: return Vector3.left;
            case BranchDirection.Right: return Vector3.right;
            case BranchDirection.Front: return Vector3.forward;
            case BranchDirection.Back: return Vector3.back;
        }

        return Vector3.zero;
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
