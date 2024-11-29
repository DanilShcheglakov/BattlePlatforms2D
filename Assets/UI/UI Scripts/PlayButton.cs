using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayButton : MonoBehaviour
{
	[SerializeField] private PausePanel _panel;
	[SerializeField] private PauseButton _pauseButton;

	public void ClosePauseMenu()
	{
		_panel.gameObject.SetActive(false);
		_pauseButton.gameObject.SetActive(true);
	}
}
