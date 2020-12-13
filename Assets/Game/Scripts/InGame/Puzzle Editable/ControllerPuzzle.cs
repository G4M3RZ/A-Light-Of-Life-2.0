using UnityEngine;

public class ControllerPuzzle : MonoBehaviour
{
    [Range(0, 10)]
    public float _puzzleSizeCam;
    public bool _entrar, _needFocus;

    private CerrarPuzzle _startDoor;
    private GameObject _puzzle;
    private FollowPlayer _follow;
    private ResizeCamera _size;
    private float _curretSize;

    private void Awake()
    {
        _startDoor = transform.GetChild(0).GetComponent<CerrarPuzzle>();
        _puzzle = transform.GetChild(2).gameObject;
        _puzzle.SetActive(false);

        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        _follow = cam.GetComponent<FollowPlayer>();
        _size = cam.GetComponent<ResizeCamera>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _puzzle.SetActive(true);
            _startDoor._playerIn = true;

            if (_needFocus)
            {
                _follow._room = this.gameObject.transform;
                _curretSize = _size._camSize;
                _size._camSize = _puzzleSizeCam;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _startDoor._playerIn = false;
            PlayerController player = other.GetComponent<PlayerController>();
            player._player = 1;
            player.PlayerTransform();

            if (_needFocus)
            {
                _follow._room = null;
                _size._camSize = _curretSize;
            }
        }
    }
}