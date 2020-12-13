using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class FinalDeIntro : MonoBehaviour
{
    public string _sceneName;
    public GameObject _fade;
    private Transform _canvas;
    private VideoPlayer _clip;

    private void Awake()
    {
        _canvas = transform.parent;
        _clip = GetComponent<VideoPlayer>();
        StartCoroutine(Clip());
    }
    IEnumerator Clip()
    {
        yield return new WaitUntil(() => _clip.isPaused);

        GameObject fade = Instantiate(_fade, _canvas);
        fade.GetComponent<Fade>()._sceneName = _sceneName;
    }
}