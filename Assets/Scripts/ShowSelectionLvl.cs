using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

class ShowSelectionLvl : MonoBehaviour
{
	public GameObject NormalModeUI;
	public GameObject TestModeUI;

	public GameObject Panel;
	public GameObject ButtonPause;
	public GameObject Definitions;

	public Image black;
	public Animator anim;


	void LoadAnimationButton()
	{
		if (!(SceneManager.GetActiveScene().name == "Menu")) {
			Debug.Log("Animation");
			var animObject = GameObject.Find("Animation");
			var classAnimationButton = animObject.GetComponent <AnimationButton> ();
			classAnimationButton.Animate();
		}
	}

	// void AddDelay()
	// {
	// 	StartCoroutine(SceneShowDelay());
	// }

	// private IEnumerator SceneShowDelay()
	// {
	// 	Debug.Log(Time.time);
	// 	yield return new WaitForSeconds(.1f);
	// 	Debug.Log(Time.time);
	// }


	// void CheckTrigger() {
	// 	if (trigger) {
	// 		StartCoroutine();
	// 	}
	// }

	public void StartingCourutine() {
		StartCoroutine(Fading());
	}

	// {
	// 	parentObject = GameObject.Find("Parent");// The name of the parent object
	// 	childObject = parentObject.transform.GetChild(0).gameObject; // the parent index (starting from 0)
	// }

	IEnumerator Fading() {
		anim.SetBool("Fade", true);
		ShowLevelsWindow();
		var parentObject = GameObject.Find("Canvas/LvlManager/Panel/Buttons");
		Debug.Log("Child obj count" + parentObject.transform.childCount);
		// foreach (GameObject but in parentObject)
		// {
		// 	childObject = parentObject.transform.GetChild(0).gameObject;
		// 	var classButton = but.GetComponent <HandlerButton> ();
		// 	if (classButton.clicked == true) {
				// yield return new WaitUntil(()=>black.color.a == 1);
				yield return null;
		// 	}
		// }
	}

	void ShowLevelsWindow()
	{
		string mode;

		LoadAnimationButton();
		var GameObjLvlUnlock = GameObject.Find("Canvas/LvlManager");
		var lvlUnlocker = GameObjLvlUnlock.GetComponent <LvlManager> ();
		mode = PlayerPrefs.GetString("Mode");
		lvlUnlocker.SetLevelUnlocked();
		ButtonPause.SetActive(false);
		Definitions.SetActive(false);
		Panel.SetActive(true);
		if (mode == "NormalMode") {
			NormalModeUI.SetActive(true);
		}
		else if (mode == "TestMode") {
			TestModeUI.SetActive(true);
		}
	}
}