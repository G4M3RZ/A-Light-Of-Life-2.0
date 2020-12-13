using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TamañoNivel : MonoBehaviour
{
    public bool _editable;
    private BoxCollider2D _collider;
    private List<Transform> _doors;

    [Range(0,100)] public float _tamañoX, _tamañoY;
    [Range(-50, 50)] public float _posYPuerta1, _posYPuerta2;

    void Awake()
    {
        _editable = false;

        _doors = new List<Transform>();

        for (int i = 0; i < 2; i++)
            _doors.Add(transform.GetChild(i));

        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
    }

    void Update()
    {
        if (_editable)
        {
            _collider.size = new Vector2(_tamañoX,_tamañoY);

            _doors[0].localPosition = new Vector2(-_tamañoX / 2, _posYPuerta1);
            _doors[1].localPosition = new Vector2(_tamañoX / 2, _posYPuerta2);
        }
    }
}