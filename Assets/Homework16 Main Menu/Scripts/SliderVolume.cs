using UnityEngine;
using UnityEngine.UI;

namespace Homework16_Main_Menu.Scripts
{
    [RequireComponent(typeof(Slider))]
    public class SliderVolume : MonoBehaviour
    {
        [field: SerializeField] public string MixerGroupParameter { get; private set; }
        public Slider Slider { get; private set; }

        private void Awake()
        {
            Slider = GetComponent<Slider>();
        }
    }
}