using UnityEngine;
using UnityEngine.UI;

public class SliderAudioController : MonoBehaviour
{
    public Slider slider;
    public AudioData audioData;

    private void OnEnable()
    {
        slider.value = audioData.GetMaster();
        slider.value = audioData.GetMusic();
        slider.value = audioData.GetSFX();
    }
}
