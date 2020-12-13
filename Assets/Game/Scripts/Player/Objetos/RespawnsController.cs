using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnsController : MonoBehaviour
{
    [HideInInspector] public bool _restart;
    
    public Transform _player;
    private Rigidbody2D _rgb;
    public List<Transform> _checkPoints;

    [Range(0,1)] public float _startTimer;
    private Vector2 _startPosition;

    private void Awake()
    {
        _rgb = _player.GetComponent<Rigidbody2D>();
        _checkPoints = new List<Transform>();
        _startPosition = _player.position;
        _restart = false;
    }
    private void Update()
    {
        if (_restart)
            _rgb.velocity = new Vector2(_rgb.velocity.x, 0);
    }
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(_startTimer);

        int chp = _checkPoints.Count;
        if (chp == 0) _player.position = _startPosition; else _player.position = _checkPoints[chp - 1].position;

        _restart = true;

        yield return new WaitForSeconds(_startTimer);
        
        _restart = false;
    }
}