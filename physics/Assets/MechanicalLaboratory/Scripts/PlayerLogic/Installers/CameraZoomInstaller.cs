using MechanicalLaboratory.Scripts.PlayerLogic.Controllers;
using MechanicalLaboratory.Scripts.PlayerLogic.Interfaces;
using Zenject;

namespace MechanicalLaboratory.Scripts.PlayerLogic.Installers
{
    public class CameraZoomInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICameraZoom>()
                .To<CameraZoom>()
                .FromNew()
                .AsSingle();
        }
    }
}