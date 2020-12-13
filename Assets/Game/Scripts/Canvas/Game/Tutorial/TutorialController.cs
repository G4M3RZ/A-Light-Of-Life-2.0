using UnityEngine;
using TMPro;
public class TutorialController : MonoBehaviour
{
    private bool _isSee;
    private float _alpha;
    private Color _textColor;
    private TextMeshPro _text;

    private void Awake()
    {
        _textColor = Color.white;
        _textColor.a = _alpha;
        
        _text = GetComponent<TextMeshPro>();
        _text.color = _textColor;
    }
    private void Update()
    {
        if (_isSee)
        {
            _textColor.a = _alpha;
            _text.color = _textColor;
            _alpha = Mathf.Lerp(_alpha, 1, Time.deltaTime);
        }       
    }
    private void OnBecameVisible()
    {
        _isSee = true;
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject, 20f);
    }
}