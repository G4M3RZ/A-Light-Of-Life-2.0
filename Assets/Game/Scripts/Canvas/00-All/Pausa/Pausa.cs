using UnityEngine;

public class Pausa : MonoBehaviour {

    public bool _isPause;
    public GameObject _fade;
    public AudioNivel _audio;
    private GameObject _pause;

    private void Awake()
    {
        Cursor.visible = _isPause = false;
        _pause = transform.GetChild(0).gameObject;
    }
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseController();
    }
    void PauseController()
    {
        _isPause = !_isPause;
        Cursor.visible = _isPause;
        _pause.SetActive(_isPause);
        Time.timeScale = (_isPause) ? 0f : 1f;
    }
    public void ResumeButton()
    {
        PauseController();
    }
    public void SceneButton(string _sceneName)
    {
        GameObject fade = Instantiate(_fade, transform) as GameObject;
        fade.GetComponent<Fade>()._sceneName = _sceneName;
        PauseController();
    }
}