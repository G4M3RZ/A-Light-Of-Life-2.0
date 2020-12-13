using UnityEngine;

public class JumpController : MonoBehaviour {

    public LayerMask _layer;
    [Range(0, 3)] public float _radius, _rayDistance;
    [HideInInspector] public float _jumpForce, _nGravity, _hGravity;
    [HideInInspector] public bool _grounded, _canJump;
    [HideInInspector] public Rigidbody2D _rgb;

    void Awake()
    {
        _grounded = false;
        _rgb = GetComponent<Rigidbody2D>();
    }
	void Update ()
    {
        if (_canJump)
        {
            _grounded = (Physics2D.CircleCast(transform.position, _radius, -transform.up, _rayDistance, _layer)) ? true : false;

            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && _grounded)
                _rgb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        _rgb.gravityScale = (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? _hGravity : _nGravity;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position - transform.up * _rayDistance, _radius);
    }
}