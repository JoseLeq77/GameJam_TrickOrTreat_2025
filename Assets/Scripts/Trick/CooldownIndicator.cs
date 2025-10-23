using UnityEngine;
using UnityEngine.UI;

public class CooldownIndicator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EggLauncher eggLauncher; 
    [SerializeField] private Image cooldownImage;     

    private void Update()
    {
        if (eggLauncher == null || cooldownImage == null)
            return;

        float cooldownProgress = eggLauncher.GetCooldownProgress();
        cooldownImage.fillAmount = cooldownProgress;
    }
}
