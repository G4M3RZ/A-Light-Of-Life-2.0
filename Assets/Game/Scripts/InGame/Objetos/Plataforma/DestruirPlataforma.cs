using System.Collections;
using UnityEngine;

public class DestruirPlataforma : MonoBehaviour
{
    [Range(0, 5)] public float _standTime, _backTime;

    private Animator _anim;
    private BoxCollider2D _collider;
    private SpriteRenderer _sprite;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            StartCoroutine(Plataforma());
    }
    IEnumerator Plataforma()
    {
        _anim.Play("start_breack");

        yield return new WaitForSeconds(_standTime);

        _collider.isTrigger = true;
        _sprite.enabled = false;

        yield return new WaitForSeconds(_backTime);

        _anim.Play("Iddle");
        _sprite.enabled = true;
        _collider.isTrigger = false;
    }
}