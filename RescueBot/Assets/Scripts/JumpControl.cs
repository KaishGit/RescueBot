using UnityEngine;


public class JumpControl : MonoBehaviour
{
    public float Force;
    public GameObject BurningPrefab;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private GameObject _burning;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_burning == null)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidBody.AddForce(Vector2.up * Force);
                AudioManager.Instance.PlaySfxImpulse();
                _animator.Play("Impulse");
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _rigidBody.AddForce(Vector2.left * Force / 2);
                _spriteRenderer.flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _rigidBody.AddForce(Vector2.right * Force / 2);
                _spriteRenderer.flipX = false;
            }
        }
        else
        {
            _burning.transform.position = transform.position;
        }

    }

    public void Burn()
    {
        _burning = Instantiate(BurningPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, 3);
        Destroy(_burning, 3);
        GameManager.Instance.RobotDestroyed();
    }
}