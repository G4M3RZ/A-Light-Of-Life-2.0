using UnityEngine;

public class PuzzleSolved : MonoBehaviour
{
    public bool _puzzleSolved;
    public BoxCollider2D _puzzle;
    private float _currentPos, _endPos;

    void Awake()
    {
        _puzzleSolved = false;
        _currentPos = transform.localPosition.y;
        _endPos = _currentPos + 10;
    }

    void Update()
    {
        if (_puzzleSolved)
        {
            _currentPos = Mathf.Lerp(_currentPos, _endPos, Time.deltaTime * 2);
            transform.localPosition = new Vector2(transform.localPosition.x, _currentPos);
            _puzzle.enabled = false;
        }
    }
}