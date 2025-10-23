using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController2d : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("Panel de Nivel")]
    [SerializeField] private GameObject levelEnterPanel;
    [SerializeField] private string sceneToLoad;
    
    private Vector2 _inputVector;
    private Rigidbody2D _rb2d;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private bool _isWalking = false;
    private Coroutine _footstepsCoroutine;
    private float _footstepInterval = 0.45f; 
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb2d.linearVelocity = new Vector2(_inputVector.x * moveSpeed, _inputVector.y * moveSpeed);
        UpdateAnimations();
    }
    
    private void UpdateAnimations()
    {
        if (_inputVector == Vector2.zero)
        {
            _animator.Play("Idle");
            return;
        }

        if (Mathf.Abs(_inputVector.y) > Mathf.Abs(_inputVector.x))
        {
            if (_inputVector.y > 0)
            {
                _animator.Play("WalkUp");
            }
            else
            {
                _animator.Play("WalkDown");
            }
        }
        else 
        {
            _animator.Play("WalkSide");
            _sprite.flipX = _inputVector.x < 0;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
        
        if (context.performed && _inputVector != Vector2.zero && !_isWalking)
        {
            _isWalking = true;
            _footstepsCoroutine = StartCoroutine(PlayFootstepsSound());
        }
        
        if ((context.canceled || _inputVector == Vector2.zero) && _isWalking)
        {
            _isWalking = false;
            
            if (_footstepsCoroutine != null)
            {
                StopCoroutine(_footstepsCoroutine);
                _footstepsCoroutine = null;
            }
        }
    }

    private IEnumerator PlayFootstepsSound()
    {
        while (_isWalking)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[9]);
            
            yield return new WaitForSeconds(_footstepInterval);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LevelEnter"))
        {
            ShowLevelEnterPanel();
        }
    }
    
    private void ShowLevelEnterPanel()
    {
        if (levelEnterPanel != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[10]);
            levelEnterPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
        }
    }
    
    public void ConfirmLevelEnter()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);
        Time.timeScale = 1f; 
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void CancelLevelEnter()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.sfxClips[8]);
        levelEnterPanel.SetActive(false);
        Time.timeScale = 1f; 
        Cursor.visible = false;
    }
}
