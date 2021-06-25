using UnityEngine;
using UnityEngine.UI;

public class RaycastObject : MonoBehaviour
{
	public GameObject Selected;

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo);
			if (hit)
			{
				if (hitInfo.transform.tag == "Rotatetable")
					Selected = hitInfo.transform.gameObject;
			}
		}
	}
}
