using MechanicalLaboratory.Scripts.PlayerLogic.Interfaces;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Installers
{
    public class EventHandlerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IEventHandler>()
                .To<EventHandler>()
                .FromNew()
                .AsSingle();
        }
    }
}