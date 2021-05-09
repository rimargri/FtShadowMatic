using UnityEngine;

public class CorrectRotation : MonoBehaviour
{
	public Vector3 rightRotation;

	void Start()
	{
		QualitySettings.SetQualityLevel(5, true); 
	}
	public Vector3 getRightRotation(GameObject obj)
	{
		if (obj.name == "4")
		{
			Vector3 rightRotation = new Vector3(355.762f, 194.1526f, 359.0841f);
			return rightRotation;
		}
		if (obj.name == "tea_pot")
		{
			rightRotation = new Vector3(13.41894f, 0.850712f, 354.5559f);
		}
		if (obj.name == "globe-earth")
		{
			Debug.Log("CorrectRotation: earth");
			rightRotation = new Vector3(339.4669f, 278.5495f, 99.99731f);
		}
		if (obj.name == "globe-base")
		{
			Debug.Log("CorrectRotation: base");
			rightRotation = new Vector3(271.8717f, 20.10208f, 0.00028f);
		}
		return rightRotation;
	}
}
