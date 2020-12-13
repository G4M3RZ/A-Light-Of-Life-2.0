using UnityEngine;

public class LevelSelector : MonoBehaviour {

    [Range(0,9)]
    public int _levelLimit;
    public GameObject _fade;
    private AudioManager _audio;

    void Awake ()
    {
        Cursor.visible = true;
        _audio = GameObject.FindGameObjectWithTag("SoundTruck").GetComponent<AudioManager>();
	}
    public void LevelButton(int level)
    {
        if(level < _levelLimit)
        {
            GameObject fade = Instantiate(_fade, transform);
            string levelName = (level == 1) ? "Intro" : "Nivel-" + level;
            fade.GetComponent<Fade>()._sceneName = levelName;

            if (_audio != null) _audio._activado = true;
        }
    }
    public void SceneButton(string sceneName)
    {
        GameObject fade = Instantiate(_fade, transform);
        fade.GetComponent<Fade>()._sceneName = sceneName;
    }
}