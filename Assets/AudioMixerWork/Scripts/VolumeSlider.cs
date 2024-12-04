using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
	[HideInInspector] public int IndexOfChannel = 0;
	public string[] Channels = new string[] { "MasterVolume", "BackgroundVolume", "ButtonsVolume" };

	[SerializeField] private Mixer _audioMixer;
	private string _channel;

	private Slider _slider;

	private void Awake()
	{
		_slider = gameObject.GetComponent<Slider>();
		_slider.value = _slider.maxValue;

		_channel = Channels[IndexOfChannel];
		SetVolume(_slider.value);
	}

	private void OnEnable()
	{
		_audioMixer.OnMuteChange += SetInterectable;

		_slider.onValueChanged.AddListener(SetVolume);
	}

	private void OnDisable()
	{
		_audioMixer.OnMuteChange -= SetInterectable;
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
		_audioMixer.ChangeVolume(_channel, volume);
	}
}
