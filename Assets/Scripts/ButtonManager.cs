using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Cinemachine;

public class ButtonManager : MonoBehaviour
{
    [Header("Scene Change")]
    [SerializeField] private Button[] SceneChangeButtons;
    [SerializeField] private string[] Scenes;

    [Header("Camera Change")]
    [SerializeField] private Button[] CameraChangeButtons;
    [SerializeField] private CinemachineCamera[] Cameras;

    public void Start()
    {
        AsignChangeScene();
        AsignChangeCamera();
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
        SceneManager.LoadScene(scene);
    }

    public void AsignChangeCamera()
    {
        if (CameraChangeButtons.Length != Cameras.Length)
        {
            Debug.LogWarning("El numero de botones y cámaras no coincide");
        }

        for (int i = 0; i < CameraChangeButtons.Length; i++)
        {
            int index = i;

            if (CameraChangeButtons[i] != null && Cameras[i] != null)
            {
                CameraChangeButtons[index].onClick.AddListener(() => ChangeCamera(Cameras[index]));
            }
        }
    }

    public void ChangeCamera(CinemachineCamera newCamera)
    {
        foreach (CinemachineCamera cameras in Cameras)
        {
            cameras.Priority = 0;
        }
        newCamera.Priority = 1;
    }


    public void ExitGame()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}