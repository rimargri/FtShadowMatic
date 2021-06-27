using UnityEngine;

class LoaderClues : MonoBehaviour
{
	public GameObject[] Clues;


	public void LoadClue(GameObject Mode)
	{
		Mode.SetActive(true);
		if (PlayerPrefs.GetString("Mode") == "NormalMode")
		{
			int levelUnlock = PlayerPrefs.GetInt("levelsUnlocked", 1);
		}
	}


	public void LoadTestMode(GameObject Mode)
	{
		Mode.SetActive(true);
	}

	public void LoadNormalMode()
	{
		var NormalMode = GameObject.Find("Canvas/LvlManager/Panel/Clues/NormalMode");
		NormalMode.SetActive(true);
		int levelUnlock = PlayerPrefs.GetInt("levelsUnlocked", 1);
		Clues[levelUnlock - 1].SetActive(true);
	}
}
