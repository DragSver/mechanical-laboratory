using UnityEngine;

namespace MechanicalLaboratory.Scripts.PlayerLogic.Interfaces
{
    public interface IEventHandler
    {
        public void Init(Camera camera, GameObject hand);
        public void ProcessEvents();
    }
}