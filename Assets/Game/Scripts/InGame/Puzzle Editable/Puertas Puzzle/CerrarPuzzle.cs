using UnityEngine;

public class CerrarPuzzle : MonoBehaviour
{
    [HideInInspector]
    public bool _playerIn;
    private float _currentPos, _initPos, _endPos;

    private void Awake()
    {
        _playerIn = false;
        _initPos = transform.localPosition.y;
        _endPos = _initPos + 10;
        _currentPos = _initPos;
    }
    void Update()
    {
        if (!_playerIn)
        {
            _currentPos = Mathf.Lerp(_currentPos, _endPos, Time.deltaTime * 2);
            transform.localPosition = new Vector2(transform.localPosition.x, _currentPos);
        }
        else
        {
            _currentPos = Mathf.Lerp(_currentPos, _initPos, Time.deltaTime * 2);
            transform.localPosition = new Vector2(transform.localPosition.x, _currentPos);
        }
    }
}