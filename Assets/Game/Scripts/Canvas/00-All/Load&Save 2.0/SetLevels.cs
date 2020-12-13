using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevels : MonoBehaviour
{
    private int _level;
    public List<Button> _buttons;

    private void Awake()
    {
        _level = PlayerPrefs.GetInt("Level", 1);
        
        for (int i = 0; i < _buttons.Count; i++)
            _buttons[i].interactable = (i <= _level - 1) ? true : false;
    }
}