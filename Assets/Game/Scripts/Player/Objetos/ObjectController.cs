using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [Range(5, 10)] public float _camSize;
    [Range(0, 30)] public float _speed, _jumpForce;
    [Range(-1, 2)] public float _nGravity, _hGravity;

    public bool _canJump, _wallJump;

    private ResizeCamera _cam;
    [Range(0.01f, 2)] public float _sizeX, _sizeY;
    [Range(0, 1)] public float _radious;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ResizeCamera>();
        _collider = GetComponentInParent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        PlayerMove move = GetComponentInParent<PlayerMove>();
        JumpController jump = GetComponentInParent<JumpController>();
        WallJump walljump = GetComponentInParent<WallJump>();

        _cam._camSize = _camSize;

        jump._canJump = _canJump;
        jump._jumpForce = _jumpForce;
        jump._nGravity = _nGravity;
        jump._hGravity = _hGravity;

        move._moveSpeed = _speed;

        walljump._canDoJump = _wallJump;

        _collider.size = new Vector2(_sizeX, _sizeY);
        _collider.edgeRadius = _radious;
    }
}