using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
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
