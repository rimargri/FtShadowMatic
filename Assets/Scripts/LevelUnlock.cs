using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class LevelUnlock : MonoBehaviour
{
	public void SetLevelUnlocked()
	{
		int currentLevel = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("current level" + currentLevel);
		if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
		{
			PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
			PlayerPrefs.Save();
		}
		// Debug.Log("level unlock" + (currentLevel + 1));
	}
}
