using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseEsc : MonoBehaviour
{
	public GameObject ButtonPause;
	public GameObject Definitions;
	public GameObject PauseMenu;
	private bool isPaused = false;

	public bool buttonWasPressed = false;

	public void ButtonWasPressed(bool buttonWasPressed)
	{
		Debug.Log(buttonWasPressed);
		updateEnablePauseMenu(buttonWasPressed);
	}

	void updateEnablePauseMenu(bool buttonWasPressed)
	{
		if (Input.GetKeyDown(KeyCode.Escape) || buttonWasPressed)
		{
			// Debug.Log("update" + buttonWasPressed);
			isPaused = !isPaused;
		}
		PauseMenu.SetActive(isPaused);
		ButtonPause.SetActive(!isPaused);
		Definitions.SetActive(!isPaused);
	}

	void Update()
	{
		updateEnablePauseMenu(buttonWasPressed); 
	}
}
