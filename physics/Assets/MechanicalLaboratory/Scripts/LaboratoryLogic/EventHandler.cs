using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI;
using MechanicalLaboratory.Scripts.PlayerLogic.Interfaces;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic
{
    public class EventHandler : IEventHandler
    {
        [Inject] private UIController _uiController;
        
        private ActionResult<string> _currentActionResult = new (true, "");
        private ActionResult<string> _previousActionResult = new (true, "");
        
        private readonly int _lengthRay = 400;
        
        public IPickable PickableInHand { get; private set; }

        private Camera _camera;
        private GameObject _hand;

        public void Init(Camera camera, GameObject hand)
        {
            _camera = camera;
            _hand = hand;
        }
        
        public void ProcessEvents()
        {
            UpdateRaycastHit();

            if (_currentActionResult.Success is false && _currentActionResult != _previousActionResult)
            {
                _uiController.CallWarning(_currentActionResult.Message);
                _previousActionResult = _currentActionResult;
            }
        }
        
        private void UpdateRaycastHit()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, _lengthRay))
            {
                var hitGameObject = hit.collider.gameObject;
                
                if (Input.GetMouseButtonDown(1))
                    IsInfoCheck(hitGameObject);
                
                if (Input.GetMouseButtonDown(0))
                {
                    var interactable = hitGameObject.GetComponent<Interactable>();
                    if (interactable is PaperStack paperStack) 
                        paperStack.GetNewPaper();
                    if (interactable is null && PickableInHand != null)
                    {
                        var pickDownPosition = new Vector3(
                            hit.point.x, 
                            hit.point.y + 0.02f, 
                            hit.point.z);
                        PickDown(hitGameObject, pickDownPosition);
                    } 
                    else
                    {
                        if (PickableInHand is null && interactable is IPickable pickable)
                            PickUp(pickable);
                        else if (PickableInHand is IComposableChild && interactable is IComposableParent composableParent)
                            Compose(composableParent);
                    }
                }
            }
        }
        
        private void IsInfoCheck(GameObject hitGameObject)
        {
            var info = hitGameObject.GetComponent<IInfo>();
            if (info != null)
                info.CallInfo();
            else 
                _uiController.ClearInfo();
        }
        public void PickUp(IPickable pickable)
        {
            if (pickable is IComposableChild compose)
                _currentActionResult = compose.SeparateAndPickUp(_hand);
            else
                _currentActionResult = pickable.PickUp(_hand);
                
            if (_currentActionResult.Success)
                PickableInHand = pickable;
        }

        private void PickDown(GameObject loweringPlace, Vector3 hitPoint)
        {
            _currentActionResult = PickableInHand.PickDown(loweringPlace, hitPoint);
            if (_currentActionResult.Success)
                PickableInHand = null;
        }

        private void Compose(IComposableParent composeParent)
        {
            _currentActionResult = ((IComposableChild)PickableInHand).ComposedWithParent(composeParent);
            if (_currentActionResult.Success) 
                PickableInHand = null;
        }

        public GameObject Hand()
        {
            return _hand;
        }
    }
}