using UnityEngine;

public class MisParticulas : MonoBehaviour
{
    public JumpController _jump;
    public ParticleSystem _particulas;

    void Update()
    {
        if(!_jump._grounded || Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") != 0)
            _particulas.Play();
    }
}