using UnityEngine;

public class CorrectRotation : MonoBehaviour
{
	public Vector3 Euler;
	public Quaternion Rotation => Quaternion.Euler(Euler);
	// public Vector3 rightRotation;

	void Start()
	{
		QualitySettings.SetQualityLevel(5, true); 
	}

	public Vector3 getRightRotation(GameObject obj)
	{
		Vector3 rightRotation = Vector3.zero;
		rightRotation = Euler;
		return rightRotation;
	}

	public Quaternion GetCorrectRotation(GameObject obj) => Quaternion.Euler(getRightRotation(obj));

}
