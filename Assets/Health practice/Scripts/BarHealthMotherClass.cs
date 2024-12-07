using UnityEngine;
using UnityEngine.UI;

public abstract class BarHealthMotherClass : MonoBehaviour
{
	[field: SerializeField] protected Slider _healtBar;
	[field: SerializeField] protected Health _healthClass;

	private void Awake()
	{
		_healtBar.value = _healtBar.maxValue;
	}

	private void OnEnable()
	{
		_healthClass.ValueChanged += UpdateState;
		_healthClass.Die += Die;
	}

	protected virtual void UpdateState(int currentHealth)
	{
	}

	private void OnDisable()
	{
		_healthClass.ValueChanged -= UpdateState;
	}

	private void Die()
	{
		_healtBar.fillRect.GetComponent<Image>().enabled = false;
	}
}
