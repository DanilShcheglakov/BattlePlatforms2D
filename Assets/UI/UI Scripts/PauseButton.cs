using UnityEngine;

public class PauseButton : MonoBehaviour
{
	[SerializeField] private PausePanel _panel;



	public void OpenPauseMenu()
	{
		_panel.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
