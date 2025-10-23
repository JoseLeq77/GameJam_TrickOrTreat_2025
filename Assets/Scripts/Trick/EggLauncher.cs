using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class EggLauncher : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private CanvasManager canvasManager; 
    [SerializeField] private Transform spawnPoint;


    [Header("Launch Settings")]
    [SerializeField] private float launchDuration = 0.8f;
    [SerializeField] private float arcHeight = 1.5f;
    [SerializeField] private float startScale = 0.6f;
    [SerializeField] private float endScale = 1.0f;
    [SerializeField] private float spinSpeed = 400f;
    [SerializeField] private float cooldownTime = 0.5f; 

    private float _lastLaunchTime = -999f;

    #region Unity Methods
    private void Update()
    {
        if (CanLaunch() && Input.GetMouseButtonDown(0))
        {
            LaunchEgg();
        }
    }
    #endregion

    #region Launch Logic
    private bool CanLaunch()
    {
        if (canvasManager == null)
        {
            return true;
        }

        bool isCooldown = Time.time < _lastLaunchTime + cooldownTime;
        return !canvasManager.IsPaused() && !isCooldown;
    }

    private void LaunchEgg()
    {
        _lastLaunchTime = Time.time;

        GameObject egg = Instantiate(eggPrefab, transform.position, Quaternion.identity);

        Vector3 targetPos = aimTransform.position;

        EggProjectile projectile = egg.GetComponent<EggProjectile>();
        if (projectile != null)
        {
            projectile.Launch(targetPos, launchDuration, arcHeight, startScale, endScale, spinSpeed);
        }
    }
    #endregion

    private void OnDrawGizmos()
    {
        if (spawnPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(spawnPoint.position, 0.2f);
            Gizmos.DrawLine(spawnPoint.position, spawnPoint.position + Vector3.up * 0.5f);
        }
    }

    public float GetCooldownProgress()
    {
        float elapsed = Time.time - _lastLaunchTime;
        float progress = Mathf.Clamp01(elapsed / cooldownTime);
        return progress;
    }

}
