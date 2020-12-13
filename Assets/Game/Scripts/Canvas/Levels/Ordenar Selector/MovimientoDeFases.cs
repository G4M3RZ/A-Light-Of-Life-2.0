using UnityEngine;

public class MovimientoDeFases : MonoBehaviour
{
    private int _faseNum;
    private float _separation, _currentPos;
    private SeparacionDeFases _fases;

    void Awake()
    {
        _fases = GetComponent<SeparacionDeFases>();
    }
    void Update()
    {
        _currentPos = Mathf.Lerp(_currentPos, _separation, Time.deltaTime * 10);
        transform.localPosition = new Vector2(_currentPos, 0);
    }

    public void Left()
    {
        if (_faseNum > 0)
        {
            _faseNum--;
            _separation += _fases._separacion;
        }
    }
    public void Right()
    {
        if (_faseNum < transform.childCount - 1)
        {
            _faseNum++;
            _separation -= _fases._separacion;
        }
    }
}