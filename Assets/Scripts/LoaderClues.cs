// public GameObject Mode;


// 1. Проверяем режим
// 	если тест, то:
// 		Mode.SetActive(true)
// 	если нормал, то:
// 		проверка, какой сейчас лвл достигнут (PlayerPrefs.GetInt("levelComplited"))
// 		в зависимости от того, какой лвл достигнут:
// 			Mode.SetActive(true);
// 			*digit*LvlStart.SetActive(true);	

using UnityEngine;

class LoaderClues : MonoBehaviour
{
	// [Header("Mode")]
	// public GameObject Mode;


	public GameObject[] Clues;


	public void LoadClue(GameObject Mode)
	{
		Mode.SetActive(true);
		if (PlayerPrefs.GetString("Mode") == "NormalMode")
		{
			int levelUnlock = PlayerPrefs.GetInt("levelsUnlocked", 1);

			// Clues[levelUnlock - 1].SetActive(true);
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
