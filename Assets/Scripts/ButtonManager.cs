using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Scene Change")]
    [SerializeField] private Button[] SceneChangeButtons;
    [SerializeField] private string[] Scenes;

    public void Start()
    {
        AsignChangeScene();
    }

    public void AsignChangeScene()
    {
        if (SceneChangeButtons.Length != Scenes.Length)
        {
            Debug.LogWarning("El numero de botones y escenas no coincide");
        }

        for (int i = 0; i < SceneChangeButtons.Length; i++)
        {
            int index = i;

            if (SceneChangeButtons[i] != null && Scenes[i] != null)
            {
                SceneChangeButtons[index].onClick.AddListener(() => ChangeScene(Scenes[index]));
            }
        }
    }

    public void ChangeScene(string scene)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);
        SceneManager.LoadScene(scene);
    }

}