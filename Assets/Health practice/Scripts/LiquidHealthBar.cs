using System.Collections;
using UnityEngine;

public class LiquidHealthBar : BarHealthMotherClass
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

		float currentBarValue = ((float)currentHealth) / _healthClass.Max;

		while (currentBarValue != _healtBar.value)
		{
			_healtBar.value = Mathf.MoveTowards(_healtBar.value, currentBarValue, _maxDelta * Time.deltaTime);
			yield return delay;
		}
	}
}
