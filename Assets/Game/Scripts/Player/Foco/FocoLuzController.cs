using System.Collections;
using UnityEngine;

public class FocoLuzController : MonoBehaviour {

    private Light _light;
    private AudioSource _flashSound;
    [Range(0, 50)]
    public float _flashLimit;
    private float _intencity;
    private bool _flash;

    private void Awake()
    {
        _light = transform.GetChild(0).GetComponent<Light>();
        _flashSound = transform.GetChild(1).GetComponent<AudioSource>();
    }
    void Update ()
    {
        _light.intensity = _intencity;

        if(!_flashSound.isPlaying && (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Z)) && !_flash)
        {
            StartCoroutine(LightIntencity());
            _flash = false;
        }
	}
    IEnumerator LightIntencity()
    {
        _flashSound.Play();

        do
        {
            _intencity += Time.deltaTime * 300;
            yield return _intencity;
        } 
        while (_intencity < _flashLimit);

        do
        {
            _intencity -= Time.deltaTime * 50;
            yield return _intencity;
        } 
        while (_intencity > 0);
        
        _flash = false;
    }
}