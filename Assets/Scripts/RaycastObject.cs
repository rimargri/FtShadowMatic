using UnityEngine;
using UnityEngine.UI;

public class RaycastObject : MonoBehaviour
{

	// public void Start()
	// {

	// }

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Mouse is down");
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo);
			if (hit) 
			{
				// Debug.Log($"Hit {hitInfo.transform.gameObject.name} [{hitInfo.transform.gameObject.GetInstanceId()}]");
				if (hitInfo.transform.gameObject.name == "globe-base")
				{
				    Debug.Log("globe-base was found");
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
