using UnityEngine;

public class ActivarCheckpoint : MonoBehaviour
{
    public AnimationClip _animationOn;
    private RespawnsController _rspw;
    private Animator _checkpoint;
    private LightSmartRender _lsr;

    private GameObject _light;

    private void Awake()
    {
        _rspw = GetComponentInParent<RespawnsController>();
        _checkpoint = GetComponent<Animator>();
        _lsr = GetComponent<LightSmartRender>();

        _light = transform.GetChild(0).gameObject;
        _light.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _rspw._checkPoints.Add(transform);

            _checkpoint.Play(_animationOn.name);
            _light.SetActive(true);
            _lsr._active = true;

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}