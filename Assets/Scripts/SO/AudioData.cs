using System;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    #region Variables
    public AudioMixer audioMixer;

    public string masterKeyVolume;
    public string musicKeyVolume;
    public string SfxKeyVolume;
    #endregion

    [Range(0f, 1f)] public float master = 1f;
    [Range(0f, 1f)] public float music = 1f;
    [Range(0f, 1f)] public float sfx = 1f;
    //[Range(0f, 1f)] public float ambient = 1f;

    #region metodo para cambiar volumenes
    public void SetMaster(float value) 
    { 
        master = value;
        audioMixer.SetFloat(masterKeyVolume, VolumeToDB(value));
    }
    public void SetMusic(float value) 
    { 
        music = value;
        audioMixer.SetFloat(musicKeyVolume, VolumeToDB(value));
    }
    public void SetSFX(float value) 
    { 
        sfx = value;
        audioMixer.SetFloat(SfxKeyVolume, VolumeToDB(value));
    }

    #region Getters
    public float GetMaster()
    {
        float value;
        audioMixer.GetFloat(masterKeyVolume, out value);
        return DBtoVolume(value);
    }

    public float GetMusic()
    {
        float value;
        audioMixer.GetFloat(musicKeyVolume, out value);
        return DBtoVolume(value);
    }

    public float GetSFX()
    {
        float value;
        audioMixer.GetFloat(SfxKeyVolume, out value);
        return DBtoVolume(value);
    }
    #endregion
    /*
    public void SetAmbient(float value) 
    { 
        ambient = value;
        audioMixer.SetFloat(masterKeyVolume, VolumeToDB(value));
    }
    */
    #endregion

    private float VolumeToDB(float f)
    {
        return Mathf.Clamp(Mathf.Log10(f) * 20f, -80f, 20f);
    }

    private float DBtoVolume(float f)
    {
        return Math.Clamp((float)Math.Pow(10, f / 20f), 0, 1f);

        //return Mathf.Clamp(Mathf.Log10(f) * 20f, -80f, 20f);
    }
}
