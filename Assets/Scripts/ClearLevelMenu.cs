using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ClearLevelMenu : MonoBehaviour
{
	public void ClearPlayerPrefs()
	{
		// PlayerPrefs.DeleteAll();
		PlayerPrefs.DeleteKey("levelsUnlocked");
		PlayerPrefs.SetInt("levelsUnlocked", 1);
		Debug.Log("Clear all prefs");
		var GameObjLvlUnlock = GameObject.Find("Canvas/LvlManager");
		var lvlUnlocker = GameObjLvlUnlock.GetComponent <LvlManager> ();
		lvlUnlocker.SetLevelUnlocked();
		lvlUnlocker.UpdateSelectionLevels();
	}
}
