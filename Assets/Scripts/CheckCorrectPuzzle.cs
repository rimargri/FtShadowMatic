using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
// using System.Linq;
class CheckCorrectPuzzle : MonoBehaviour
{
	public GameObject Panel;

	// public void LoadGameLevel(string SceneName)
	// {
	// 	SceneManager.LoadScene(SceneName);
	// }

	// bool checkingCoordinates(Vector3 eulerAngles, Vector3 rightRotation)
	// {
	// 	float x = Math.Abs(Math.Abs(eulerAngles.x) - Math.Abs(rightRotation.x));
	// 	float y = Math.Abs(Math.Abs(eulerAngles.y) - Math.Abs(rightRotation.y));
	// 	float z = Math.Abs(Math.Abs(eulerAngles.z) - Math.Abs(rightRotation.z));
	// 	if (x <= 10 && y <= 10 && z <= 10)
	// 	{
	// 		return true;
	// 	}
	// 	return false;
	// }

	// bool IsRotationCorrect(GameObject target)
	// {
	// 	Quaternion quaternionAngles = target.transform.rotation;
	// 	Vector3 eulerAngles = quaternionAngles.eulerAngles;
	// 	// Debug.Log("Current rot: " + eulerAngles.x + " " + eulerAngles.y + " " + eulerAngles.z);

	// 	var rot = target.GetComponent <CorrectRotation> ();
	// 	if (!rot)
	// 	{
	// 		return false;
	// 	}
	// 	Vector3 rightRotation = rot.getRightRotation(target);

	// 	if (checkingCoordinates(eulerAngles, rightRotation))
	// 	{
	// 		// Debug.Log("Checking coordinates was approved");
	// 		return true;
	// 	}
	// 	// Debug.Log("Needed rot: " + rightRotation.x + " " + rightRotation.y + " " + rightRotation.z);
	// 	Debug.Log("PRINT");
	// 	Debug.Log("transform.rotation : " + transform.rotation);
	// 	return false;
	// }
	bool IsRotationCorrect(CorrectRotation target)
	{
		Quaternion targetRotation = target.transform.rotation;
		Quaternion correctRotation = target.GetCorrectRotation(target.gameObject);

		float angle = Quaternion.Angle(targetRotation, correctRotation);
		Debug.Log(angle);
		return (angle <= 25f);
	}

	void ShowLevelsWindow()
	{
		var GameObjLvlUnlock = GameObject.Find("Canvas/LvlManager");
		var lvlUnlocker = GameObjLvlUnlock.GetComponent <LvlManager> ();
		lvlUnlocker.SetLevelUnlocked();
		lvlUnlocker.UpdateSelectionLevels();
		Panel.SetActive(true);
	}

    void Update()
    {
		
		var array = FindObjectsOfType<CorrectRotation>();
		var targets = new List<CorrectRotation>(array);

		if (targets.TrueForAll((target) => IsRotationCorrect(target)))
		{
			ShowLevelsWindow();
		}
		
		// GameObject target = GameObject.Find("Floor");
		// GameObject target2 = GameObject.Find("Floor");
		// if (SceneManager.GetActiveScene().name == "Level 1")
		// {
		// 	target = GameObject.Find("42/4");
		// }
		// if (SceneManager.GetActiveScene().name == "Level 2")
		// {
		// 	target = GameObject.Find("tea_pot");
		// }
		// if ((target.name == "4" || target.name == "tea_pot") && IsRotationCorrect(target))
		// {
		// 	ShowLevelsWindow();
		// }
		// if (SceneManager.GetActiveScene().name == "Level 3")
		// {
		// 	// Debug.Log(PlayerPrefs.GetString("globe"));
		// 	if (PlayerPrefs.GetString("globe") == "earth")
		// 	{
		// 		target = GameObject.Find("Globe/globe-earth");
		// 	}
		// 	if (PlayerPrefs.GetString("globe") == "base")
		// 	{
		// 		target2 = GameObject.Find("Globe/globe-base");
		// 	}
		// 	if (IsRotationCorrect(target) && (IsRotationCorrect(target2)))
		// 	{
		// 		ShowLevelsWindow();
		// 	}
		// }
    }
}
