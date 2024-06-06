using MechanicalLaboratory.Scripts.PlayerLogic.Interfaces;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.PlayerLogic
{
    public class PlayerLogic : MonoBehaviour
    {
        [Inject] private IEventHandler _eventHandler;
        [Inject] private ICameraZoom _cameraZoom;
        [Inject] private IMoveController _moveController;

        [SerializeField] private GameObject _hand;
        [SerializeField] private Camera _camera;

        private void Start()
        {
            _eventHandler.Init(_camera, _hand);
            _cameraZoom.Init(_camera);
            _moveController.Init(transform);
        }

        private void Update()
        {
            _moveController.UpdateLocation();
            _cameraZoom.Zoom();
            _eventHandler.ProcessEvents();
        }
    }
}