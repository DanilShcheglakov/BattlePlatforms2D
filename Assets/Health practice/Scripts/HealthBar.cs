using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
	[field: SerializeField] protected Slider HealtBar;
	[field: SerializeField] protected Health HealthClass;

	private void Awake()
	{
		HealtBar.value = HealtBar.maxValue;
	}

	private void OnEnable()
	{
		HealthClass.ValueChanged += UpdateState;
		HealthClass.Die += Die;
	}

	protected abstract void UpdateState(int currentHealth);

	private void OnDisable()
	{
		HealthClass.ValueChanged -= UpdateState;
	}

	private void Die()
	{
		HealtBar.fillRect.GetComponent<Image>().enabled = false;
	}
}
