using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LiquidHealthBar : HealthHandler
{
	[SerializeField] private Slider HealthBar;
	[SerializeField] private float _maxDelta;

	private Coroutine _healthTaker;

	protected override void SetDefaultState()
	{
		HealthBar.value = HealthBar.maxValue;
	}

	protected override void UpdateState(int currentHealth)
	{
		if (_healthTaker != null)
			StopCoroutine(_healthTaker);

		_healthTaker = StartCoroutine(TakeAwawy(currentHealth));
	}

	private IEnumerator TakeAwawy(int currentHealth)
	{
		var delay = new WaitForEndOfFrame();

		float currentBarValue = ((float)currentHealth) / HealthClass.Max;

		while (currentBarValue != HealthBar.value)
		{
			HealthBar.value = Mathf.MoveTowards(HealthBar.value, currentBarValue, _maxDelta * Time.deltaTime);
			yield return delay;
		}
	}
}
