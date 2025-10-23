using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Mixer")]
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Header("Clips")]
    public AudioClip[] musicClips;
    public AudioClip[] sfxClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region Música
    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (clip == null) return;

        _musicSource.clip = clip;
        _musicSource.loop = loop;
        _musicSource.Play();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }

    public void PauseMusic(bool pause)
    {
        if (pause) _musicSource.Pause();
        else _musicSource.UnPause();
    }
    #endregion

    #region SFX
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        _sfxSource.PlayOneShot(clip);
    }

    public void StopSFX()
    {
        _sfxSource.Stop();
    }

    public void PauseSFX(bool pause)
    {
        if (pause) _sfxSource.Pause();
        else _sfxSource.UnPause();
    }

    public void PlaySFXByName(string clipName)
    {
        AudioClip clip = System.Array.Find(sfxClips, c => c.name == clipName);
        if (clip != null) _sfxSource.PlayOneShot(clip);
    }
    #endregion
}
