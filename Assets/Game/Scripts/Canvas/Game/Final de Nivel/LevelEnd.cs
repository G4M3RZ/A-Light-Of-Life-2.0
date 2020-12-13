using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelEnd : MonoBehaviour
{
    [Range(1, 9)] public int _level;
    private VideoPlayer _video;
    private BoxCollider2D _collider;
    private AudioNivel _sound;

    private void Awake()
    {
        _video = GetComponent<VideoPlayer>();
        _video.enabled = false;
        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = true;
        _sound = GameObject.FindGameObjectWithTag("SoundTruck").GetComponent<AudioNivel>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(LevelComplete());
    }
    IEnumerator LevelComplete()
    {
        _collider.enabled = false;
        _sound._activado = true;

        int newLevel = PlayerPrefs.GetInt("Level");
        PlayerPrefs.SetInt("Level", (newLevel <= _level) ? _level + 1 : newLevel);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(1.5f);

        _video.enabled = true;

        yield return new WaitUntil(() => _video.isPaused);

        SceneManager.LoadScene("Levels");
    }
}