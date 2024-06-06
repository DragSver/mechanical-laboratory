using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Installers.UI
{
    public class WarningWindowInstaller : MonoInstaller
    {
        [SerializeField] public WarningWindow _warningWindow;

        public override void InstallBindings()
        {
            Container
                .Bind<IWarningWindow>()
                .To<WarningWindow>()
                .FromInstance(_warningWindow)
                .AsSingle();
        }
    }
}