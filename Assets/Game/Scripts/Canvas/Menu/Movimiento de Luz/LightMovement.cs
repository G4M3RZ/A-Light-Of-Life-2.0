using UnityEngine;

public class LightMovement : MonoBehaviour {

	void Update ()
    {
		Vector2 aux = Input.mousePosition;
		transform.position = Camera.main.ScreenToWorldPoint(aux);
	}
}