using UnityEngine;

public class AudioManager : MonoBehaviour {

    [Range(0, 1)] public float _volume;
    [HideInInspector] public bool _activado;
    private AudioSource _audio;
    private static AudioManager _audioScript;

	void Awake ()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = _volume;

        if (_audioScript == null)
        {
            _audioScript = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
	
	void Update ()
    {
        if (_activado)
        {
            _audio.volume = (_audio.volume > 0) ? _audio.volume -= Time.deltaTime : _audio.volume = 0;

            if (_audio.volume == 0)
                Destroy(this.gameObject);
        }
	}
}