using MechanicalLaboratory.Scripts.PlayerLogic.Controllers;
using MechanicalLaboratory.Scripts.PlayerLogic.Interfaces;
using Zenject;

namespace MechanicalLaboratory.Scripts.PlayerLogic.Installers
{
    public class MoveControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var moveController = new MoveController();
            
            Container
                .Bind<IMoveController>()
                .To<MoveController>()
                .FromInstance(moveController)
                .AsSingle();
        }
    }
}