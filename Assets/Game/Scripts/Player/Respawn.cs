using UnityEngine;

public class Respawn : MonoBehaviour
{
    public RespawnsController _respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
            StartCoroutine(_respawn.Respawn());
    }
}