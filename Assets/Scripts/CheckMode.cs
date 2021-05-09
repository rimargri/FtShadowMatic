using UnityEngine;
using UnityEngine.UI;

class CheckMode : MonoBehaviour
{
	public void ClickButton(Object objButton)
	{
		PlayerPrefs.SetString("Mode", objButton.name);
		PlayerPrefs.Save();
		Debug.Log("ClickButton ::: Mode     " + objButton.name);
	}
}
