using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Vector3 InitialPosition;
    public float Speed = 0.3f;
    public float Range;

    private int direction = 1;
    private float _speedMultiplier = 1.2f;
    private Rigidbody _rigidbody;

    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        InitialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float movementY = Speed * Time.deltaTime * direction;

        //transform.RotateAround(transform.position + new Vector3(1, 1, 0f), Vector3.up, 10*Time.deltaTime);

        if (direction < 0)
            movementY *= _speedMultiplier;

            var newY = transform.position.y + movementY;

        if ((Mathf.Abs(newY - InitialPosition.y) > Range) || newY<InitialPosition.y)
            direction *= -1;
        else
            transform.position += new Vector3(0, movementY, 0);
	}
}
