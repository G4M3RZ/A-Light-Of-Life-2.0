using UnityEngine;

public class AudioNivel : MonoBehaviour {

    [HideInInspector] public bool _activado;
    [Range(0, 1)] public float _volume, _speed;
    private AudioSource _audio;

    void Awake ()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = _volume;
    }
	void Update ()
    {
        if(_activado)
            Botones();
    }
    void Botones()
    {
        _volume = (_volume > 0) ? _volume -= Time.deltaTime / _speed : _volume = 0;
        _audio.volume = _volume;
        if (_volume == 0) Destroy(this.gameObject);
    }
}