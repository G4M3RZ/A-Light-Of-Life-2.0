using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator _anim;
    public AnimationClip _iddle, _move, _jump, _hide;
    private string currentState;

    private JumpController _jc;

    private void Awake()
    {
        _jc = GetComponent<JumpController>();
    }
    private void Update()
    {
        if (_anim == null) return;

        if (_jc._grounded)
            ChangeAnimationState(_iddle.name);

        if (!_jc._grounded)
            ChangeAnimationState(_jump.name);
    }
    public void ChangeAnimationState(string newState)
    {
        //stop if its playing same animation
        if (currentState == newState) return;
        _anim.Play(newState);
        currentState = newState;
    }
}