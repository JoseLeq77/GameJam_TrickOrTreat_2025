using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    /*[SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioData audioData;

    private void OnEnable()
    {
        audioData.OnVolumeChanged += UpdateVolumes;
    }

    private void OnDisable()
    {
        audioData.OnVolumeChanged -= UpdateVolumes;
    }

    private void Start()
    {
        UpdateVolumes();
    }

    void UpdateVolumes()
    {
        //valores al mixer dx
        mixer.SetFloat("MasterVolume", Mathf.Log10(audioData.master) * 20f);
        mixer.SetFloat("MusicVolume", Mathf.Log10(audioData.music) * 20f);
        mixer.SetFloat("SFXVolume", Mathf.Log10(audioData.sfx) * 20f);
        mixer.SetFloat("AmbientVolume", Mathf.Log10(audioData.ambient) * 20f);
    } */

}