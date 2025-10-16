using UnityEngine;

[CreateAssetMenu(fileName = "AudioChannel", menuName = "Scriptable Objects/AudioManager")]
public class AudioData : ScriptableObject
{
    [Range(0f, 1f)] public float masterValue = 1f;
    [Range(0f, 1f)] public float musicValue = 1f;
    [Range(0f, 1f)] public float sfxValue = 1f;
}
