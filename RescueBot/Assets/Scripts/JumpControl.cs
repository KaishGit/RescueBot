using UnityEngine;

public class JumpControl : MonoBehaviour
{
    [SerializeField] float Force;


    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector2.up * Force);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rigidBody.AddForce(Vector2.left * Force / 2);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rigidBody.AddForce(Vector2.right * Force / 2);
        }
    }
}