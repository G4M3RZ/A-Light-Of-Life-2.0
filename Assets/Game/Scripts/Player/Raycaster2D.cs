using UnityEngine;

public class Raycaster2D : MonoBehaviour
{
    public RaycastHit2D Ray2D(Vector2 initPos, Vector2 direction, float rayDistance, LayerMask layer, Color rayColor)
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hitInfo = Physics2D.Raycast(initPos, direction, rayDistance, layer);
        Debug.DrawLine(initPos, initPos + direction * rayDistance, rayColor);
        return hitInfo;
    }
}