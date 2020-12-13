using UnityEngine;

public class MovePasto : MonoBehaviour
{
    public string _animation;
    private Animator anim;
    private BoxCollider2D _collider;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = false;

        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            anim.Play(_animation);
    }
    private void OnBecameVisible()
    {
        _collider.enabled = true;
        anim.enabled = true;
    }
    private void OnBecameInvisible()
    {
        _collider.enabled = false;
        anim.enabled = false;
    }
}