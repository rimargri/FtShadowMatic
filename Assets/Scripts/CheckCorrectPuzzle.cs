using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


class CheckCorrectPuzzle : MonoBehaviour
{
	public LevelUnlocker LevelUnlocker;
	[Header("Hui")]
		public GameObject NormalModeUI;
	public GameObject TestModeUI;

	[Header("Pizdsa")]
	public GameObject Panel;
	public GameObject ButtonPause;
	public GameObject Definitions;

	public Image black;
	public Animator anim;

	public Button[] buttons;

	private bool isComplete = false;

	void Start() {
		PlayerPrefs.SetInt("completeLvl", 0);
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

	public void Fade(int nextLevel)
	{
		StartCoroutine("Fading", nextLevel);
	}

	public void ControlsTransitionBtwScenes() {
		// StartCoroutine(Fading());
	}

	// bool hasBeenClicked = false;
	// void ButtonClicked()
	// {
	// 	hasBeenClicked = true;
	// 	anim.SetBool("Fade", true);
	// }

	IEnumerator Fading(int nextLevel) {

		ShowLevelsWindow();

		// foreach (Button b in buttons)
		// {
		// 	b.onClick.AddListener(ButtonClicked);
		// }

		// while (!hasBeenClicked) yield return null;

		anim.SetBool("Fade", true);
		yield return new WaitUntil(()=>black.color.a == 1);

		LevelUnlocker.LoadLevel(nextLevel);

		// var Buttons = GameObject.Find("Canvas/LvlManager/Panel/Buttons");
		// foreach (GameObject button in Buttons)
		// {
		// 	var classButton = button.GetComponent <HandlerButton> ();
		// 	if (classButton.clicked == true) {

		// foreach (Button but in buttons) {
			// bool hasBeenClicked = false;
			// while (!hasBeenClicked)
			// {
			// 	for (int i = 0; i < buttons.Length; i++) {
			// 		var but = buttons[i].GetComponent <HandlerButton> ();
			// 		Debug.Log($"but clicked = {but.clicked}");
			// 		if (but.clicked == true) {
			// 			hasBeenClicked = true;
			// 			anim.SetBool("Fade", true);
			// 			yield return new WaitUntil(()=>black.color.a == 1);
			// 		}
			// 		// else
			// 		// continue;
			// 	}
			// 	yield return null;
			// }

			// }
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

    void Update()
    {
		var array = FindObjectsOfType<CorrectRotation>();
		var targets = new List<CorrectRotation>(array);

		if (!isComplete && targets.TrueForAll((target) => IsRotationCorrect(target)))
		{
			isComplete = true;
			PlayerPrefs.SetInt("completeLvl", 1);
			if ((SceneManager.GetActiveScene().buildIndex < 3 && PlayerPrefs.GetString("Mode") == "NormalMode") || (PlayerPrefs.GetString("Mode") == "TestMode"))
			{
				Debug.Log("Add Delay");
				// Invoke("ControlsTransitionBtwScenes", 3);
				// Invoke("ControlsTransitionBtwScenes", 3);
				Invoke("ShowLevelsWindow", 3f);
			}
			else
			{
				SceneManager.LoadScene("Final Scene");
			}
		}
    }
}


// 1. В ParentObject есть child - три кнопки. Вопрос: Как правильно их получить?
// 2. Мне нужно итерироваться по массиву кнопок, чтобы чекать, была ли хоть одна из них нажата.
// 3. Если была,  включить затемнение экрана.