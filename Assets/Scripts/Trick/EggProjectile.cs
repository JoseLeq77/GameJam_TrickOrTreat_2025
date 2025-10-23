using UnityEngine;
using DG.Tweening;

public class EggProjectile : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _targetPos;
    private float _duration;
    private float _arcHeight;
    private float _spinSpeed;
    private float _timer;
    private bool _launched;

    private Vector3 _startScale;
    private Vector3 _endScale;

    private Tween _moveTween;
    private Tween _scaleTween;

    [SerializeField] private FloatingScore floatingScorePrefab;
    [SerializeField] private float floatingScoreZ;


    public void Launch(Vector3 targetPos, float duration, float arcHeight, float startScale, float endScale, float spinSpeed)
    {
        _startPos = transform.position;
        _targetPos = targetPos;
        _duration = duration;
        _arcHeight = arcHeight;
        _spinSpeed = spinSpeed;

        _startScale = Vector3.one * startScale;
        _endScale = Vector3.one * endScale;

        transform.localScale = _startScale;
        _launched = true;
        _timer = 0f;

        _moveTween = DOTween.To(() => _timer, x => _timer = x, 1f, _duration)
            .OnUpdate(() =>
            {
                if (this == null) return; 
                Vector3 currentPos = Vector3.Lerp(_startPos, _targetPos, _timer);
                float heightOffset = Mathf.Sin(_timer * Mathf.PI) * _arcHeight;
                currentPos.y += heightOffset;
                transform.position = currentPos;
            })
            .OnComplete(() =>
            {
                if (this != null)
                    Destroy(gameObject, 0.1f);
            });

        _scaleTween = transform.DOScale(_endScale, _duration).SetEase(Ease.OutSine);
    }

    private void Update()
    {
        if (_launched)
        {
            transform.Rotate(Vector3.forward, _spinSpeed * Time.deltaTime, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Debug.Log("Impactó en Target");
            Destroy(other.gameObject);
            ScoreItem3D scoreItem = other.GetComponent<ScoreItem3D>();
            if (scoreItem != null)
            {
                scoreItem.InvokeOnScoreCollectedValue();
            }
            InstantiateFloatingScore(scoreItem.GetScoreInfo());
            KillTweensAndDestroy();
        }
        else if (other.CompareTag("Background"))
        {
            Debug.Log("Impactó en el fondo");
            InstantiateFloatingScore(-1);
            ScoreItem3D.InvokeOnScoreCollectedNegative();
            KillTweensAndDestroy();
        }
    }

    private void KillTweensAndDestroy()
    {
        if (_moveTween != null && _moveTween.IsActive())
            _moveTween.Kill();

        if (_scaleTween != null && _scaleTween.IsActive())
            _scaleTween.Kill();

        Destroy(gameObject);
    }
    private void InstantiateFloatingScore(int amount)
    {
        Vector3 newTransform = new Vector3(transform.position.x, transform.position.y, floatingScoreZ);
        FloatingScore score = Instantiate(floatingScorePrefab, newTransform, Quaternion.identity);
        score.Initialize(amount);
    }



    private void OnDestroy()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[6]);
        if (_moveTween != null && _moveTween.IsActive())
            _moveTween.Kill();

        if (_scaleTween != null && _scaleTween.IsActive())
            _scaleTween.Kill();
    }
}
