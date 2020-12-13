using UnityEngine;

public class GroundHitForce : MonoBehaviour
{
    [Range(0, 5)] public float _rayDistance;
    [HideInInspector] public bool _golpe, _move;

    public LayerMask _layer;

    private Raycaster2D _raycast2D;

    private void Awake()
    {
        _raycast2D = GetComponentInParent<Raycaster2D>();
    }
    void Update()
    {
        RaycastHit2D hit = _raycast2D.Ray2D(transform.position, Vector2.down, _rayDistance, _layer, Color.red);

        if (hit.collider == null && Input.GetKeyDown(KeyCode.S))
            _golpe = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_golpe)
        {
            //mover camara
            _move = true;
            _golpe = false;
        }
    }
}