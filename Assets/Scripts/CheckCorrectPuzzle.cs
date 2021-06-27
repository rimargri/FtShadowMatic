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

	bool IsPositionCorrect(CorrectPos target)
	{
		Vector3 targetPosition = target.transform.position;
		Vector3 correctPos = target.GetCorrectPosition();

		float dist = Vector3.Distance(correctPos, targetPosition);
		print("Distance to other: " + dist);
		return (dist <= 0.02672781f);
	}

	void LoadAnimationButton()
	{
		if (!(SceneManager.GetActiveScene().name == "Menu")) {
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

		LoadAnimationButton();
		var GameObjLvlUnlock = GameObject.Find("Canvas/LvlManager");
		var lvlUnlocker = GameObjLvlUnlock.GetComponent <LvlManager> ();
		mode = PlayerPrefs.GetString("Mode");
		lvlUnlocker.SetLevelUnlocked();
		Definitions.SetActive(false);
		ButtonPause.SetActive(false);
		Panel.SetActive(true);
		if (mode == "NormalMode") {
			NormalModeUI.SetActive(true);
		}
		else if (mode == "TestMode") {
			TestModeUI.SetActive(true);
		}
	}	

	void LoadFinalScene()
	{
		SceneManager.LoadScene("Final Scene");
	}

    void Update()
    {
		var array = FindObjectsOfType<CorrectRotation>();
		var targets = new List<CorrectRotation>(array);

		var array2 = FindObjectsOfType<CorrectPos>();
		var targets2 = new List<CorrectPos>(array2);

		int Level3 = 3;

		if (!isCompleteLvl && targets.TrueForAll((target) => IsRotationCorrect(target)))
		{
			if ((SceneManager.GetActiveScene().buildIndex != Level3) ||
				(SceneManager.GetActiveScene().buildIndex == Level3 && targets2.TrueForAll((target) => IsPositionCorrect(target))))
			{
				isCompleteLvl = true;
				PlayerPrefs.SetInt("completeLvl", isCompleteLvl == true ? 1 : 0);
				if ((SceneManager.GetActiveScene().buildIndex < CountLevels && PlayerPrefs.GetString("Mode") == "NormalMode") || (PlayerPrefs.GetString("Mode") == "TestMode"))
				{
					Invoke("ShowLevelsWindow", WaitTime);
				}
				else
				{
					Invoke("LoadFinalScene", WaitTime);
				}
			}
		}
    }
}
