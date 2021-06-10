using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public void MainMenuLoad()
	{
		SceneManager.LoadScene("Menu");
	}

	public void ExitPressed()
	{
		Debug.Log("Exit pressed");
		Application.Quit();
	}
}
