using System.Collections.Generic;
using UnityEngine;

public class SeparacionDeFases : MonoBehaviour
{
    private List<GameObject> _fases;
    private RectTransform _canvas;
    
    [HideInInspector]
    public float _separacion;

    private void Awake()
    {
        _canvas = GetComponentInParent<RectTransform>();

        _separacion = _canvas.rect.x * -4;

        _fases = new List<GameObject>();
        float moveUi = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            _fases.Add(transform.GetChild(i).gameObject);
            _fases[i].transform.localPosition = new Vector2(moveUi, 0);
            moveUi += _separacion;
        }
    }
}