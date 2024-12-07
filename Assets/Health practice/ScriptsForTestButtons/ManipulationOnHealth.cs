using UnityEngine;
using UnityEngine.UI;

public abstract class ManipulationOnHealth : MonoBehaviour
{
	[SerializeField] private Button _button;
	[SerializeField] protected Health _healthForManipulation;
	[SerializeField] protected int _healthDifferent;

	private void Awake()
	{
		_button.onClick.AddListener(MakeManipulation);
	}

	protected virtual void MakeManipulation() { }
}
