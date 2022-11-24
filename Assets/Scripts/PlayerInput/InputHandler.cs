using UnityEngine;
using UnityEngine.InputSystem;

namespace UnavinarTestTask.Assets.Scripts.PlayerInput
{
    public class InputHandler : MonoBehaviour
    {

        public delegate void StartTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch;
        public delegate void EndTouch(Vector2 position, float time);
        public event StartTouch OnEndTouch;

        private PlayerControl _playerControl;
        private Camera _mainCamera;

        private void Awake()
        {
            _playerControl = new PlayerControl();
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            _playerControl.Enable();
        }

        private void OnDisable()
        {
            _playerControl.Disable();
        }

        private void Start()
        {
            _playerControl.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
            _playerControl.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        }        

        private void StartTouchPrimary(InputAction.CallbackContext ctx)
        {
            if (OnStartTouch != null)
            {
                OnStartTouch(Utils.ScreenToWorld(_mainCamera, _playerControl.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)ctx.startTime);
            }
        }

        private void EndTouchPrimary(InputAction.CallbackContext ctx)
        {
            if (OnEndTouch != null)
            {
                OnEndTouch(Utils.ScreenToWorld(_mainCamera, _playerControl.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)ctx.time);
            }
        }

        public Vector2 PrimaryPosition()
        {
            return Utils.ScreenToWorld(_mainCamera, _playerControl.Touch.PrimaryPosition.ReadValue<Vector2>());
        }
    }
}
