using UnityEngine;

public class DeactivateOnGameEnded : MonoBehaviour
{
    private void OnEnable()
    {
        TimeManager.OnTimeLimitReached += DeactivateThisObject;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeLimitReached -= DeactivateThisObject;
    }

    private void DeactivateThisObject()
    {
        gameObject.SetActive(false);
    }
}
