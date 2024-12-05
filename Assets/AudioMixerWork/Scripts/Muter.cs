using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Muter : MonoBehaviour
{
	[SerializeField] private AudioMixerGroup _mixer;
	[SerializeField] private Toggle _muteToggle;

	private float _masterVolume;
	private float _minValue;

	public event Action<bool> MuteToggleChangeChanging;

	private void Awake()
	{
		_mixer.audioMixer.GetFloat(_mixer.name, out _masterVolume);
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

	private void ChangeMuteSettings(bool isMusicMute)
	{
		if (isMusicMute)
		{
			_mixer.audioMixer.GetFloat(_mixer.name, out _masterVolume);
			_mixer.audioMixer.SetFloat(_mixer.name, Mathf.Log10(_minValue) * 20);
		}
		else
		{
			_mixer.audioMixer.SetFloat(_mixer.name, _masterVolume);
		}

		MuteToggleChangeChanging?.Invoke(isMusicMute);
	}
}
