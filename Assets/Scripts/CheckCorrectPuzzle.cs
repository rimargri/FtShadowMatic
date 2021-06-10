using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

class CheckCorrectPuzzle : MonoBehaviour
{
	public GameObject LevelChoiceWindow;
	public GameObject ButtonPause;

	private bool isComplete = false;

	bool IsRotationCorrect(CorrectRotation target)
	{
		Quaternion targetRotation = target.transform.rotation;
		Quaternion correctRotation = target.GetCorrectRotation(target.gameObject);

		float angle = Quaternion.Angle(targetRotation, correctRotation);
		// Debug.Log(angle);
		return (angle <= 25f);
	}

	void ShowLevelsWindow()
	{
		var GameObjLvlUnlock = GameObject.Find("Canvas/LvlManager");
		var lvlUnlocker = GameObjLvlUnlock.GetComponent <LvlManager> ();
		lvlUnlocker.SetLevelUnlocked();
		LevelChoiceWindow.SetActive(true);
		ButtonPause.SetActive(false);
	}

    void Update()
    {
		var array = FindObjectsOfType<CorrectRotation>();
		var targets = new List<CorrectRotation>(array);

		if (!isComplete && targets.TrueForAll((target) => IsRotationCorrect(target)))
		{
			isComplete = true;
			if (SceneManager.GetActiveScene().buildIndex != 3) {
				ShowLevelsWindow();
			}
			else 
			{
				SceneManager.LoadScene("Final Scene");
			}
		}
    }
}
