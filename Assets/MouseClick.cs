using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

	bool click = false;
	GameObject weight = null;

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = getMousePoint ();

			RaycastHit2D hit = Physics2D.Raycast(point, -Vector2.up);

			if (hit.collider != null && hit.collider.tag == "weight") {
				if (weight == null) {
					weight = hit.collider.gameObject;
				}
				click = true;
			}
		}

		if (click) {
			Vector3 point = getMousePoint ();

			weight.transform.position = new Vector3 (weight.transform.position.x, point.y, weight.transform.position.z);			
		}

		if (Input.GetMouseButtonUp(0)) {
			click = false;
		}
	}

	Vector3 getMousePoint(){
		float distance = 4.5f;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
		return ray.origin + (ray.direction * distance);
	}
}
