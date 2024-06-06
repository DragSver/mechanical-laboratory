using UnityEngine;

namespace MechanicalLaboratory.Scripts.PlayerLogic.Interfaces
{
    public interface ICameraZoom
    {
        public void Init(Camera camera);
        public void Zoom();
    }
}
