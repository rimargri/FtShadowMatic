using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
	int levelsUnlocked;
	public Button[] buttons;

	void Start()
	{
		int i;

		levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
		Debug.Log("levelsUnlocked" + levelsUnlocked);
		
		for (i = 0; i < buttons.Length; i++)
		{
			buttons[i].interactable = false;
		}

		for (i = 0; i < levelsUnlocked; i++)
		{
			buttons[i].interactable = true;
		}
	}

	public void LoadLevel(int levelIndex)
	{		
		SceneManager.LoadScene(levelIndex);
	}

	public void SetLevelUnlocked()
	{
		int currentLevel = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("currentLevel" + currentLevel);
		if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
		{
			PlayerPrefs.SetInt("levelsUnlocked", currentLevel);
			PlayerPrefs.Save();
		}
	}
}
