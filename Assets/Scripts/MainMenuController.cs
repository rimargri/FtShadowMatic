using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public void NextLevelPressed()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	// public void ContinuePlayPressed()
	// {
	// 	var pauseMenu = GameObject.Find("Canvas/Pause Menu/Menu");
	// 	pauseMenu.SetActive(false);
	// 	var pauseButton = GameObject.Find("Canvas/Pause Menu/ButtonPause");
	// 	pauseButton.SetActive(true);
	// }

	public void ExitPressed()
	{
		Debug.Log("Exit pressed");
		Application.Quit();
	}
}
