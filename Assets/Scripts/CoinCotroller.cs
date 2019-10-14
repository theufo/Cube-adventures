using UnityEngine;

public class CoinCotroller : MonoBehaviour {

    public float RotationSpeed;

    void Update () {
        var angle = RotationSpeed * Time.deltaTime;
        this.transform.Rotate(Vector3.up * angle, Space.World);
	}
}
