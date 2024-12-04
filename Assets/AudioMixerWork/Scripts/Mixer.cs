using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Mixer : MonoBehaviour
{
	private const string MasterVolume = nameof(MasterVolume);

	[SerializeField] private AudioMixerGroup _mixer;
	[SerializeField] private Toggle _muteToggle;

	private float _masterVolume;
	private float _minValue;

	public event Action<bool> OnMuteChange;

	private void Awake()
	{
		_mixer.audioMixer.GetFloat(MasterVolume, out _masterVolume);
		_minValue = 0.0001f;
		_muteToggle.isOn = false;
	}

	private void OnEnable()
	{
		_muteToggle.onValueChanged.AddListener(ChangeMuteSettings);
	}

	private void OnDisable()
	{
		_muteToggle.onValueChanged.RemoveListener(ChangeMuteSettings);
	}

	public void ChangeVolume(string channel, float volume)
	{
		_mixer.audioMixer.SetFloat(channel, Mathf.Log10(volume) * 20);
	}

	private void ChangeMuteSettings(bool isMusicMute)
	{
		if (isMusicMute)
		{
			_mixer.audioMixer.GetFloat(MasterVolume, out _masterVolume);
			_mixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(_minValue) * 20);
		}
		else
		{
			_mixer.audioMixer.SetFloat(MasterVolume, _masterVolume);
		}

		OnMuteChange?.Invoke(isMusicMute);
	}
}
