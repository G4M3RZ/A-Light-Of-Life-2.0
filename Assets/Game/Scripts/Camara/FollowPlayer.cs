using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool _edit;
    [HideInInspector] public Transform _player, _room;
    [Range(0, 10)] public float xLimit, yLimit;

    private Vector2 lastPos;

    private void Awake()
    {
        _edit = false;
        lastPos = _player.position;
    }
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (_room == null) TrackCharacter(pos); else TrackRoom(pos);
    }
    void TrackCharacter(Vector3 camPos)
    {
        Vector3 target = _player.position;

        if (target.x > camPos.x + xLimit)
            lastPos.x = camPos.x + (target.x - (camPos.x + xLimit));

        if (target.x < camPos.x - xLimit)
            lastPos.x = camPos.x - (-target.x + (camPos.x - xLimit));

        if (target.y > camPos.y + yLimit)
            lastPos.y = camPos.y + (target.y - (camPos.y + yLimit));

        if (target.y < camPos.y - yLimit)
            lastPos.y = camPos.y - (-target.y + (camPos.y - yLimit));

        camPos.y = Mathf.Lerp(camPos.y, lastPos.y, Time.deltaTime * 2);
        camPos.x = Mathf.Lerp(camPos.x, lastPos.x, Time.deltaTime * 5);
        transform.position = camPos;
    }
    void TrackRoom(Vector3 camPos)
    {
        lastPos = _room.transform.position;
        camPos.y = Mathf.Lerp(camPos.y, lastPos.y, Time.deltaTime);
        camPos.x = Mathf.Lerp(camPos.x, lastPos.x, Time.deltaTime);
        transform.position = camPos;
    }
    private void OnDrawGizmos()
    {
        if (_edit)
        {
            Vector3 camPos = transform.position;
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(camPos, new Vector3(xLimit * 2, yLimit * 2, 0));
        }
    }
}