using MechanicalLaboratory.Scripts.LaboratoryProfile.Controllers;
using MechanicalLaboratory.Scripts.LaboratoryProfile.UI;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryProfile.Installers
{
    public class RegistrationWindowInstaller : MonoInstaller
    {
        [SerializeField] private RegistrationWindow _registrationWindow;
        public override void InstallBindings()
        {
            Container.
                Bind<RegistrationWindow>().
                FromInstance(_registrationWindow).
                AsSingle().NonLazy();
        }
    }
}