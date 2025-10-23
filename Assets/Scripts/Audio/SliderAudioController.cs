using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderAudioController : MonoBehaviour
{
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private TMP_Text textMasterPercent;
    [SerializeField] private TMP_Text textMusicPercent;
    [SerializeField] private TMP_Text textSFXPercent;
    public AudioData audioData;

    private void Start()
    {
        sliderMaster.value = audioData.GetMaster();
        sliderMusic.value = audioData.GetMusic();
        sliderSFX.value = audioData.GetSFX();

        UpdateMasterText(sliderMaster.value);
        UpdateMusicText(sliderMusic.value);
        UpdateSFXText(sliderSFX.value);

        sliderMaster.onValueChanged.AddListener(OnMasterSliderChanged);
        sliderMusic.onValueChanged.AddListener(OnMusicSliderChanged);
        sliderSFX.onValueChanged.AddListener(OnSFXSliderChanged);
    }

    private void OnDestroy()
    {
        sliderMaster.onValueChanged.RemoveListener(OnMasterSliderChanged);
        sliderMusic.onValueChanged.RemoveListener(OnMusicSliderChanged);
        sliderSFX.onValueChanged.RemoveListener(OnSFXSliderChanged);
    }

    private void OnMasterSliderChanged(float value)
    {
        audioData.SetMaster(value);
        UpdateMasterText(value);
    }

    private void OnMusicSliderChanged(float value)
    {
        audioData.SetMusic(value);
        UpdateMusicText(value);
    }

    private void OnSFXSliderChanged(float value)
    {
        audioData.SetSFX(value);
        UpdateSFXText(value);
    }

    private void UpdateMasterText(float value)
    {
        textMasterPercent.text = Mathf.RoundToInt(value * 100f) + "%";
    }

    private void UpdateMusicText(float value)
    {
        textMusicPercent.text = Mathf.RoundToInt(value * 100f) + "%";
    }

    private void UpdateSFXText(float value)
    {
        textSFXPercent.text = Mathf.RoundToInt(value * 100f) + "%";
    }
}
