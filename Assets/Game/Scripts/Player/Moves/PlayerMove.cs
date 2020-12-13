using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [HideInInspector] public float _moveSpeed;
    private Rigidbody2D _rgb;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 temporalVelocity = _rgb.velocity;
        temporalVelocity.x = h * _moveSpeed;
        _rgb.velocity = temporalVelocity;

        Flip(h);
    }
    private void Flip(float moves)
    {
        Vector3 theScale = transform.localScale;
        if (moves > 0) theScale.x = 1; else if (moves < 0) theScale.x = -1;
        transform.localScale = theScale;
    }
}