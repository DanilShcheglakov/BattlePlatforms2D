using UnityEngine;
using UnityEngine.UI;

public class SharpHealthBar : HealthBar
{
	[SerializeField] private Slider _healthBar;

	protected override void SetDefaultState()
	{
		_healthBar.value = _healthBar.maxValue;
	}

	protected override void UpdateState(int currentHealth)
	{
		_healthBar.value = ((float)currentHealth) / HealthClass.Max;
	}
}
