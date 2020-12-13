using UnityEngine;

public class ObjDetector : MonoBehaviour
{
    [Range(1,4)]
    public int _objValue;

    public void ObjectTaken(bool active)
    {
        GetComponent<SpriteRenderer>().enabled = active;
        GetComponent<CircleCollider2D>().enabled = active;
    }
    private void SetPlayerValues(GameObject playerObj, bool value)
    {
        PlayerController player = playerObj.GetComponent<PlayerController>();
        player._player = _objValue;
        player._canTransform = value;
        player._objDetect = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            SetPlayerValues(collision.gameObject, true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SetPlayerValues(collision.gameObject, false);
    }
}