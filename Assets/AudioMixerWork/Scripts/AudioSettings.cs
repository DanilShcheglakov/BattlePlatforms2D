using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
	private const string MasterVolume = nameof(MasterVolume);
	private const string BackgroundVolume = nameof(BackgroundVolume);
	private const string ButtonsVolume = nameof(ButtonsVolume);

	[SerializeField] private AudioMixerGroup _mixer;
	[SerializeField] private List<Slider> _sliders;
	[SerializeField] private Toggle _toggle;

	private float _masterVolume;
	private float _minValue;
	private float _maxValue;

	private void Awake()
	{
		_mixer.audioMixer.GetFloat(MasterVolume, out _masterVolume);
		_minValue = 0.0001f;
		_maxValue = 1;

		SetDefaultSettings();
	}

	public void ToggleMusic(bool isMusicEnable)
	{
		bool sliderInterectable = true;
		bool sliderUnInterectable = false;

		if (isMusicEnable)
		{
			_mixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(_minValue) * 20);

			ChangeSliderInterectableState(sliderUnInterectable);
		}
		else
		{
			_mixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(_masterVolume) * 20);

			ChangeSliderInterectableState(sliderInterectable);
		}
	}

	public void ChangeMasterVolume(float volume)
	{
		ChangeVolume(MasterVolume, volume);

		_masterVolume = volume;
	}

	public void ChangeBackgroundVolume(float volume)
	{
		ChangeVolume(BackgroundVolume, volume);
	}

	public void ChangeButtonsVolume(float volume)
	{
		ChangeVolume(ButtonsVolume, volume);
	}

	private void SetDefaultSettings()
	{
		_toggle.isOn = false;

		foreach (Slider slider in _sliders)
			slider.value = _maxValue;
	}

	private void ChangeVolume(string channel, float volume)
	{
		_mixer.audioMixer.SetFloat(channel, Mathf.Log10(volume) * 20);
	}

	private void ChangeSliderInterectableState(bool isSliderInterectable)
	{
		foreach (Slider slider in _sliders)
			slider.interactable = isSliderInterectable;
	}
}
