using System.Collections;
using UnityEngine;

public class FireParticles : MonoBehaviour
{
    private ParticleSystem _fire;
    private PlayerController _player;

    private void Awake()
    {
        _fire = transform.GetChild(1).GetComponent<ParticleSystem>();
        _player = GetComponentInParent<PlayerController>();
    }
    private void OnEnable()
    {
        _fire.Play();
        StartCoroutine(LifeTime());
    }
    IEnumerator LifeTime()
    {
        float time = _fire.main.startLifetime.constant;
        yield return new WaitForSeconds(time);

        _player._player = 1;
        _player.PlayerTransform();
    }
}