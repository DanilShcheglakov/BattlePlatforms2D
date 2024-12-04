using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioEffect : MonoBehaviour
{
	[SerializeField] private Button _button;
	private AudioSource _audio;

	private void Awake()
	{
		_audio = GetComponent<AudioSource>();
	}

	private void OnEnable()
	{
		_button.onClick.AddListener(PlayAudio);
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(PlayAudio);
	}

	private void PlayAudio()
	{
		_audio.Play();
	}
}
