using UnityEngine;

public class ChangeStateUI : MonoBehaviour {
	public GameObject TestMode;
	public GameObject NormalMode;

	public void CheckModeActive() {
		if (TestMode.activeSelf) {
			TestMode.SetActive(false);
		}
		if (NormalMode.activeSelf) {
			NormalMode.SetActive(false);
		}
	}
}
