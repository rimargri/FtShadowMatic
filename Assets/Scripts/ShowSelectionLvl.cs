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

	public void StartingCourutine() {
		StartCoroutine(Fading());
	}


	IEnumerator Fading() {
		anim.SetBool("Fade", true);
		ShowLevelsWindow();
		var parentObject = GameObject.Find("Canvas/LvlManager/Panel/Buttons");
		yield return null;
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