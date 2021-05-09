using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
	int levelsUnlocked;
	public Button[] buttons;
	string mode;
	void Start()
	{
		// mode = PlayerPrefs.GetString("Mode");
		// Debug.Log("Start LvlManager");
		// SetLevelUnlocked(); // ???
		// UpdateSelectionLevels();
		Debug.Log("Start LvlManager");
	}

	public void UpdateSelectionLevels()
	{
		int i;

		mode = PlayerPrefs.GetString("Mode");
		levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
		if (mode == "TestMode")
		{
			Debug.Log("Test mode");
			for (i = 0; i < buttons.Length; i++)
			{
				buttons[i].interactable = true;
			}
		}
		else if (mode == "NormalMode")
		{
			Debug.Log("Normal mode");
			for (i = 0; i < buttons.Length; i++)
			{
				buttons[i].interactable = false;
			}
			for (i = 0; i < levelsUnlocked; i++)
			{
				buttons[i].interactable = true;
			}
		}
	}

	public void SetLevelUnlocked()
	{
		int currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
		if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
		{
			PlayerPrefs.SetInt("levelsUnlocked", currentLevel);
			PlayerPrefs.Save();
		}
		UpdateSelectionLevels();
	}
}
