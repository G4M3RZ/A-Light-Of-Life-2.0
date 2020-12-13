using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameObject _fade;
    private AudioManager _audio;

	void Awake ()
    {
        Cursor.visible = true;
        _audio = GameObject.FindGameObjectWithTag("SoundTruck").GetComponent<AudioManager>();
    }
    public void PlayButton()
    {
        GameObject fade = Instantiate(_fade, transform);

        int level = PlayerPrefs.GetInt("Level", 1);
        string levelName = (level == 1) ? "Intro" : "Nivel-" + level;

        fade.GetComponent<Fade>()._sceneName = levelName;
        _audio._activado = true;
    }
    public void SceneButton(string sceneName)
    {
        GameObject fade = Instantiate(_fade, transform);
        fade.GetComponent<Fade>()._sceneName = sceneName;
    }
    public void ExitGame()
    {
        GameObject fade = Instantiate(_fade, transform);
        fade.GetComponent<Fade>()._sceneName = "ExitGame";
        _audio._activado = true;
    }
}