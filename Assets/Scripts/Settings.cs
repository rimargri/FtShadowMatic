using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
	bool isFullScreen;
	public void FullScreenToggle()
	{
		isFullScreen = !isFullScreen;
		Screen.fullScreen = isFullScreen;
	}

	public AudioMixer am;

	public void AudioVolume(float sliderValue)
	{
		am.SetFloat("volumeMaster", sliderValue);
	}

	public void Quality(int index)
	{
		QualitySettings.SetQualityLevel(index);
	}
}
