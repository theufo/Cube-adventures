using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MovementSpeed;
    public float JumpForce;
    public AudioSource CoinSound;

    private Rigidbody _rigidbody;
    private Collider  _collider;
    private bool _jumpPressed;

    Vector3 playerSize;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        playerSize = _collider.bounds.size;
    }
    void FixedUpdate () {
        WalkHandler();
        JumpHandler();
    }

    private void WalkHandler() {
        float horizonalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MovementSpeed * horizonalAxis * Time.deltaTime, 0, MovementSpeed * verticalAxis * Time.deltaTime);

        Vector3 newPositon = transform.position + movement;

        _rigidbody.MovePosition(newPositon);
    }
    private void JumpHandler()
    {
        float jumpAxis = Input.GetAxis("Jump");

        if (jumpAxis > 0)
        {
            bool isGrounded = CheckGrounded();
            if (!_jumpPressed && isGrounded)
            {
                _jumpPressed = true;

                Vector3 jumpVector = new Vector3(0, jumpAxis * JumpForce, 0);

                _rigidbody.AddForce(jumpVector, ForceMode.VelocityChange);
            }
        }
        else
            _jumpPressed = false;
    }

    private bool CheckGrounded()
    {
        Vector3 corner1 = transform.position + new Vector3(playerSize.x / 2, -playerSize.y / 2 + 0.01f, -playerSize.z / 2);
        Vector3 corner2 = transform.position + new Vector3(-playerSize.x / 2, -playerSize.y / 2 + 0.01f, -playerSize.z / 2);
        Vector3 corner3 = transform.position + new Vector3(playerSize.x / 2, -playerSize.y / 2 + 0.01f, playerSize.z / 2);
        Vector3 corner4 = transform.position + new Vector3(-playerSize.x / 2, -playerSize.y / 2 + 0.01f, playerSize.z / 2);

        bool grounded1 = Physics.Raycast(corner1, -Vector3.up, 0.02f);
        bool grounded2 = Physics.Raycast(corner2, -Vector3.up, 0.02f);
        bool grounded3 = Physics.Raycast(corner3, -Vector3.up, 0.02f);
        bool grounded4 = Physics.Raycast(corner4, -Vector3.up, 0.02f);

        return (grounded1 || grounded2 || grounded3 || grounded4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            CoinSound.Play();
            GameManager.Instance.IncreaseScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }
        else if (other.CompareTag("Goal"))
        {
            GameManager.Instance.IncreaseLevel();
        }
    }
}
