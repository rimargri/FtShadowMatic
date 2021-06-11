using UnityEngine;

public class SoundSystem : MonoBehaviour {
	public static SoundSystem instance;
	private void Awake() {
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
