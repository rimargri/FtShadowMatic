using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlocker : MonoBehaviour
{
	public void LoadLevel(int levelIndex)
	{		
		SceneManager.LoadScene(levelIndex);
	}
}
