using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ActivadorRecuerdo : MonoBehaviour
{
    public PostProcessingProfile _gameplayPsPr;

    private void Awake()
    {
        ChromaticIntensity(0);
    }
    IEnumerator LevelEnd()
    {
        //cambiar animacion player == win
        float intencity = 0;

        while (intencity < 1)
        {
            intencity = Mathf.Clamp(intencity += Time.deltaTime, 0, 1);
            ChromaticIntensity(intencity);
        }

        yield return null;
    }
    void ChromaticIntensity(float _intensidad)
    {
        if (_gameplayPsPr.chromaticAberration.enabled)
        {
            ChromaticAberrationModel.Settings newSettings = _gameplayPsPr.chromaticAberration.settings;
            newSettings.intensity = _intensidad;
            _gameplayPsPr.chromaticAberration.settings = newSettings;
        }
    }
}