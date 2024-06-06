using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Installers.UI
{
    public class InformationWindowInstaller : MonoInstaller
    {
        [SerializeField] private InformationWindow _informationWindows;

        public override void InstallBindings()
        {
            Container
                .Bind<IInformationWindow>()
                .To<InformationWindow>()
                .FromInstance(_informationWindows)
                .AsSingle();
        }
    }
}
