using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public Animator anim;
	public Image black;

	public void MainMenuLoad()
	{
		StartCoroutine("FadingMenu");
	}

	IEnumerator FadingMenu()
	{
		anim.SetBool("Fade", true);
		yield return new WaitUntil(()=>black.color.a == 1);
		SceneManager.LoadScene("Menu");
	}

	public void ExitPressed()
	{
		StartCoroutine("FadingExit");
	}

	IEnumerator FadingExit()
	{
		Debug.Log("Exit pressed");
		anim.SetBool("Fade", true);
		yield return new WaitUntil(()=>black.color.a == 1);
		Application.Quit();
	}
}
