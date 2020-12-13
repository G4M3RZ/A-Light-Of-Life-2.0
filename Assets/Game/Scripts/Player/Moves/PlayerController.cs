using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    List<GameObject> _lights;
    [Range(1, 5)] public int _player;
    [HideInInspector] public bool _canTransform;

    [HideInInspector] public ObjDetector _objDetect;
    private Rigidbody2D _rgb;

    private void Awake()
    {
        _player = 1;
        _lights = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
            _lights.Add(transform.GetChild(i).gameObject);

        _rgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_canTransform && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.C)))
        {
            PlayerTransform();
        }
    }

    public void PlayerTransform()
    {
        for (int i = 0; i < _lights.Count; i++)
        {
            bool newPlayer = (i + 1 == _player) ? true : false;
            _lights[i].SetActive(newPlayer);
        }

        if (_objDetect != null)
            _objDetect.ObjectTaken(!_canTransform);

        _rgb.velocity = new Vector2(_rgb.velocity.x, 0);
        _canTransform = false;
    }
}