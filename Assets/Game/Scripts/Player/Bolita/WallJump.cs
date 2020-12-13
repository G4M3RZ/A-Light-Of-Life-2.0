using UnityEngine;

public class WallJump : MonoBehaviour
{
    public LayerMask _wjLayer;
    [Range(0, 2)] public float _rayDistance = 1f;
    [Range(1, 5)] public float _speed = 2f, _jumpForce = 3f;
    [HideInInspector] public bool _canDoJump;

    private Rigidbody2D _rgb;
    private Raycaster2D _ray;
    private PlayerMove _moves;
    private JumpController _jump;

    void Awake()
    {
        _rgb = GetComponent<Rigidbody2D>();
        _ray = GetComponent<Raycaster2D>();
        _moves = GetComponent<PlayerMove>();
        _jump = GetComponent<JumpController>();
    }
    void Update()
    {
        if (_canDoJump)
        {
            Vector2 pos = transform.position;
            Vector2 direction = Vector2.right * transform.localScale.x;
            RaycastHit2D hit = _ray.Ray2D(pos, direction, _rayDistance, _wjLayer, Color.blue);

            if (Input.GetAxis("Vertical") > 0 && hit.collider != null)
            {
                _rgb.velocity = new Vector2(_speed * hit.normal.x, _speed * _jumpForce);
                transform.localScale = (transform.localScale.x == 1) ? new Vector3(-1, 1, 1) : Vector3.one;
                _moves.enabled = false;
            }
            else if (_jump._grounded)
            {
                _moves.enabled = true;
            }
        }
    }
}