using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadingBtwScenes : MonoBehaviour
{
	public LevelUnlocker LevelUnlocker;
	public Animator anim;
	public Image black;

	public void Fade(int nextLevel)
	{
		StartCoroutine("Fading", nextLevel);
	}

	IEnumerator Fading(int nextLevel)
	{
		anim.SetBool("Fade", true);
		yield return new WaitUntil(()=>black.color.a == 1);
		LevelUnlocker.LoadLevel(nextLevel);
	}

}
