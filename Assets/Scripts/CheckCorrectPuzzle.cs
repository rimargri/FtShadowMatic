using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


class CheckCorrectPuzzle : MonoBehaviour
{
	public GameObject LevelChoiceWindow;
	public GameObject ButtonPause;
	public GameObject Definitions;
	private bool isComplete = false;


	bool IsRotationCorrect(CorrectRotation target)
	{
		Quaternion targetRotation = target.transform.rotation;
		Quaternion correctRotation = target.GetCorrectRotation(target.gameObject);

		float angle = Quaternion.Angle(targetRotation, correctRotation);
		return (angle <= 15f);
	}

	// bool IsTranslateCorrect(CorrectRotation target)
	// {
	// 	Vector3 targetTranslate = target.transform.translate;
	// }

	void LoadAnimation()
	{
		if (!(SceneManager.GetActiveScene().name == "Menu")) {
			Debug.Log("Animation");
			var animObject = GameObject.Find("Animation");
			var scriptAnimationButton = animObject.GetComponent <AnimationButton> ();
			scriptAnimationButton.Animate();
		}
	}

	void AddDelay()
	{
		StartCoroutine(SceneShowDelay());
	}

	private IEnumerator SceneShowDelay()
	{
		Debug.Log(Time.time);
		yield return new WaitForSeconds(.1f);
		Debug.Log(Time.time);
	}

	void ShowLevelsWindow()
	{
		// AddDelay();
		LoadAnimation();
		Debug.Log("Add Delay");
		var GameObjLvlUnlock = GameObject.Find("Canvas/LvlManager");
		var lvlUnlocker = GameObjLvlUnlock.GetComponent <LvlManager> ();
		lvlUnlocker.SetLevelUnlocked();
		LevelChoiceWindow.SetActive(true);
		ButtonPause.SetActive(false);
		Definitions.SetActive(false);
	}

    void Update()
    {
		var array = FindObjectsOfType<CorrectRotation>();
		var targets = new List<CorrectRotation>(array);

		if (!isComplete && targets.TrueForAll((target) => IsRotationCorrect(target)))
		{
			isComplete = true;
			if ((SceneManager.GetActiveScene().buildIndex < 3 && PlayerPrefs.GetString("Mode") == "NormalMode") || (PlayerPrefs.GetString("Mode") == "TestMode"))
			{
				Invoke("ShowLevelsWindow", 3);
				// ShowLevelsWindow();
			}
			else
			{
				SceneManager.LoadScene("Final Scene");
			}
		}
    }
}
