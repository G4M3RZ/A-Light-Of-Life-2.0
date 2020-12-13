using UnityEngine;

public class ResizeCamera : MonoBehaviour
{
    [Range(0, 5)]
    public float _speed;
    public float _camSize;
    private Camera _cam;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if(_cam.orthographicSize != _camSize)
            _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, _camSize, Time.deltaTime * _speed);
    }
}