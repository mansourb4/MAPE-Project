using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Music
{
    public class VolumeSaveController : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private TextMeshProUGUI volumeTextUI;

        private void Start()
        {
            LoadValues();
        }

        public void VolumeSlider(float volume)
        {
            volumeTextUI.text = volume.ToString("0.0");
        }

        public void SaveVolumeButton()
        {
            float volumeValue = volumeSlider.value;
            PlayerPrefs.SetFloat("VolumeValue", volumeValue);
            LoadValues();
        }

        void LoadValues()
        {
            float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
            volumeSlider.value = volumeValue;
            AudioListener.volume = volumeValue;
        }
    }
}