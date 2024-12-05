using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
	[SerializeField] private AudioMixerGroup _channelAudioMixer;
	[SerializeField] private Muter _muter;

	private Slider _slider;

	private void Awake()
	{
		_slider = gameObject.GetComponent<Slider>();
		_slider.value = _slider.maxValue;

		SetVolume(_slider.value);
	}

	private void OnEnable()
	{
		_muter.MuteToggleChangeChanging += SetInterectable;
		_slider.onValueChanged.AddListener(SetVolume);
	}

	private void OnDisable()
	{
		_muter.MuteToggleChangeChanging -= SetInterectable;
		_slider.onValueChanged.RemoveListener(SetVolume);
	}

	private void SetInterectable(bool isMusicMute)
	{
		if (isMusicMute)
			_slider.interactable = false;
		else
			_slider.interactable = true;
	}

	private void SetVolume(float volume)
	{
		_channelAudioMixer.audioMixer.SetFloat(_channelAudioMixer.name, Mathf.Log10(volume) * 20);
	}
}