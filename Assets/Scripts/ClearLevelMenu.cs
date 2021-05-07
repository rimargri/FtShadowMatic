using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ClearLevelMenu : MonoBehaviour
{
	void Start()
	{
		PlayerPrefs.DeleteAll();
	}
}
