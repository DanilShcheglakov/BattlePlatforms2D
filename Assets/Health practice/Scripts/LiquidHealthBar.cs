using System.Collections;
using UnityEngine;

public class LiquidHealthBar : HealthBar
{
	[SerializeField] private float _maxDelta;

	private Coroutine _healthTaker;

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

		while (currentBarValue != HealtBar.value)
		{
			HealtBar.value = Mathf.MoveTowards(HealtBar.value, currentBarValue, _maxDelta * Time.deltaTime);
			yield return delay;
		}
	}
}
