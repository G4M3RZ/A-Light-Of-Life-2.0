using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadAndSaveLevel : MonoBehaviour
{
    CargarYGuardar _cargarYGuardar;

    static public int _nivelDesbloqueado;
    public int contadorDeNivel, _nivelActual;
    public List<Button> _buttons;

    private void Awake()
    {
        _cargarYGuardar = GetComponent<CargarYGuardar>();

        if(SceneManager.GetActiveScene().name == "Levels")
            Actualizar();
        else
            contadorDeNivel = _nivelDesbloqueado;

    }
    public void Actualizar()
    {
        _cargarYGuardar.Guardar();

        for (int i = 0; i < _nivelDesbloqueado + 1; i++)
            _buttons[i].interactable = true;
    }
    public void DesbloquearNivel()
    {
        if (_nivelDesbloqueado < _nivelActual)
        {
            _nivelDesbloqueado = _nivelActual;
            _nivelActual++;
        }
    }
}