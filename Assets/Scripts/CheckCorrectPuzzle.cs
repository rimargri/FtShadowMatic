using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


class CheckCorrectPuzzle : MonoBehaviour
{
	public LevelUnlocker LevelUnlocker;
	[Header("Modes buttons")]
	public GameObject NormalModeUI;
	public GameObject TestModeUI;

	[Header("Window select levels")]
	public GameObject Panel;
	public GameObject ButtonPause;
	public GameObject Definitions;

	[Header("Animation IN and OUT")]
	public Image black;
	public Animator anim;

	private bool isCompleteLvl = false;

	private float WaitTime = 3f;

	private int CountLevels = 3;

	void Start()
	{
		isCompleteLvl = false;
		PlayerPrefs.SetInt("completeLvl", isCompleteLvl == false ? 0 : 1);
	}

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

	void LoadAnimationButton()
	{
		if (!(SceneManager.GetActiveScene().name == "Menu")) {
			Debug.Log("Animation");
			var animObject = GameObject.Find("Animation");
			var classAnimationButton = animObject.GetComponent <AnimationButton> ();
			classAnimationButton.Animate();
		}
	}

	public void Fade(int nextLevel)
	{
		StartCoroutine("Fading", nextLevel);
	}

	IEnumerator Fading(int nextLevel)
	{
		ShowLevelsWindow();
		anim.SetBool("Fade", true);
		yield return new WaitUntil(()=>black.color.a == 1);
		LevelUnlocker.LoadLevel(nextLevel);
	}

	void ShowLevelsWindow()
	{
		string mode;

		Debug.Log("show lvls window");
		LoadAnimationButton();
		var GameObjLvlUnlock = GameObject.Find("Canvas/LvlManager");
		var lvlUnlocker = GameObjLvlUnlock.GetComponent <LvlManager> ();
		mode = PlayerPrefs.GetString("Mode");
		lvlUnlocker.SetLevelUnlocked();
		Definitions.SetActive(false);
		ButtonPause.SetActive(false);
		// Debug.Log("Definitions.SetActive(false)");
		Panel.SetActive(true);
		if (mode == "NormalMode") {
			NormalModeUI.SetActive(true);
		}
		else if (mode == "TestMode") {
			TestModeUI.SetActive(true);
		}
	}

    void Update()
    {
		var array = FindObjectsOfType<CorrectRotation>();
		var targets = new List<CorrectRotation>(array);

		if (!isCompleteLvl && targets.TrueForAll((target) => IsRotationCorrect(target)))
		{
			isCompleteLvl = true;
			PlayerPrefs.SetInt("completeLvl", isCompleteLvl == true ? 1 : 0);
			if ((SceneManager.GetActiveScene().buildIndex < CountLevels && PlayerPrefs.GetString("Mode") == "NormalMode") || (PlayerPrefs.GetString("Mode") == "TestMode"))
			{
				Invoke("ShowLevelsWindow", WaitTime);
			}
			else
			{
				SceneManager.LoadScene("Final Scene");
			}
		}
    }
}
