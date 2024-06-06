using UnityEngine;
using UnityEngine.SceneManagement;

namespace MechanicalLaboratory.Scripts
{
    public class Preload : MonoBehaviour
    {
        public void Start()
        {
            SceneManager.LoadScene("Registration");
        }
    }
}