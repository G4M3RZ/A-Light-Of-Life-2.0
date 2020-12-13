using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [HideInInspector]
    public string _sceneName;
    private Image _uiImage;
    private Color _black;
    private float _alpha;

    private void Start()
    {
        _uiImage = GetComponent<Image>();
        _black = Color.black;

        _alpha = (_sceneName != "") ? 0 : 1;
        _black.a = _alpha;
        _uiImage.color = _black;
    }
    private void Update()
    {
        _alpha = (_sceneName != "") ? _alpha += Time.deltaTime / 2: _alpha -= Time.deltaTime / 2;
        _alpha = Mathf.Clamp(_alpha, 0, 1);
        _black.a = _alpha;
        _uiImage.color = _black;

        if(_sceneName != "")
        {
            if (_alpha == 1) SceneManager.LoadScene(_sceneName);
        }
        else if(_sceneName == "ExitGame")
        {
            Application.Quit();
        }
        else
        {
            if (_alpha == 0) Destroy(this.gameObject);
        }
    }
}