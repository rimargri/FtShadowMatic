using UnityEngine;
using UnityEngine.UI;

public class RaycastObject : MonoBehaviour
{
	public void Update()
	{
		Debug.Log("check 3");
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Mouse is down");
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.name == "globe-base")
				{
				    Debug.Log ("globe-base was found");
					PlayerPrefs.SetString("globe", "base");
					PlayerPrefs.Save();
				}
				if (hitInfo.transform.gameObject.name == "globe-earth")
				{
					Debug.Log("globe-earth was found");
					PlayerPrefs.SetString("globe", "earth");
					PlayerPrefs.Save();
				}
				// else {
				//     Debug.Log ("Nothing");
				// }
			}
			// else
			// {
			// 	Debug.Log("No hit");
			// }
			// Debug.Log("Mouse is down");
		}
	}
}
