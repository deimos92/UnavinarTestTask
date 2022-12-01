using UnityEngine;
using Cinemachine;

namespace UnavinarTestTask.Assets.Scripts.Game
{   
    public class EntityPlacer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;

        [SerializeField]
        private GameObject _gatePrefab;

        [SerializeField]
        private GameObject _finishPrefab;

        [SerializeField]
        private GameObject _fieldPrefab;

        [SerializeField]
        private CinemachineVirtualCamera _cinemachineVirtualCamera;       
        

        private void Start()
        {
            SetupOther();
        }

        private void SetupOther()
        {
            var settings = Level.Instance.GameSettings;
            var playerInstance = Instantiate(_playerPrefab, transform);            
            var fieldInstance = Instantiate(_fieldPrefab, transform);

            var finishInstance = Instantiate(_finishPrefab, transform);
            finishInstance.transform.localPosition = new Vector3(0, 0, settings.FieldLenght - 7);

            PlaceGates(settings.GatesCount, settings.FieldLenght);

            _cinemachineVirtualCamera.Follow = playerInstance.transform;
            _cinemachineVirtualCamera.LookAt = playerInstance.transform;            
        }

        private void PlaceGates(int gatesCount, float fieldLenght)
        {
            for (int gateIndex = 1; gateIndex <= gatesCount; gateIndex++)
            {
                var gatePosition = (fieldLenght - 100) / gatesCount;
                var gateInstance = Instantiate(_gatePrefab, transform);
                gateInstance.transform.localPosition = new Vector3(0, 0, 50 + gatePosition * gateIndex);
            }
        }

    }
}
