using MechanicalLaboratory.Scripts.LaboratoryLogic.UI;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Installers.UI
{
    public class UIControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UIController>()
                .FromNew()
                .AsSingle();
        }
    }
}