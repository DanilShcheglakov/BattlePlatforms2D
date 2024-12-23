using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LiquidHealthBar : HealthBar
{
	[SerializeField] private Slider _healthBar;
	[SerializeField] private float _maxDelta;

	private Coroutine _healthTaker;

	protected override void SetDefaultState()
	{
		_healthBar.value = _healthBar.maxValue;
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

		while (currentBarValue != _healthBar.value)
		{
			_healthBar.value = Mathf.MoveTowards(_healthBar.value, currentBarValue, _maxDelta * Time.deltaTime);
			yield return delay;
		}
	}
}
