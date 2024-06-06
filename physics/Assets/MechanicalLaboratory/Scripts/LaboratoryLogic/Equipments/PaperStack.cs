using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class PaperStack : Interactable
    {
        [Inject] private EventHandler _eventHandler;
        
        [SerializeField] private GameObject _paperPrefab;

        private readonly Paper[] _paperLimit = new Paper[_maxCountPaper];
        
        private byte _paperCounter = 0;
        private const byte _maxCountPaper = 10;

        public void GetNewPaper()
        {
            if (_eventHandler.PickableInHand is not null)
                return;
            
            var newPaper = Instantiate(_paperPrefab.gameObject, transform.position, transform.rotation, transform).GetComponent<Paper>();
            newPaper.SetUIFactory(_uiController);
            newPaper.gameObject.SetActive(true);
            
            PaperCounter(newPaper);
            
            _eventHandler.PickUp(newPaper);
        }

        private void PaperCounter(Paper newPaper)
        {
            if (_paperCounter >= _maxCountPaper)
                _paperCounter = 0;
            if (_paperLimit[_paperCounter] is not null)
                Destroy(_paperLimit[_paperCounter]);
            
            _paperLimit[_paperCounter] = newPaper;
            _paperCounter++;
        }
    }
}