using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class DeactivateOnGameEnded : MonoBehaviour
{
    private void OnEnable()
    {
        TimePanel.OnTimeLimitReached += DeactivateThisObject;
    }

    private void OnDisable()
    {
        TimePanel.OnTimeLimitReached -= DeactivateThisObject;
    }

    private void DeactivateThisObject()
    {
        gameObject.SetActive(false);
    }
}
