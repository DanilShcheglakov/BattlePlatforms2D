using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private Collector _collector;
	[SerializeField] private uint _max;
	private int _current;

	public event Action<int> ValueChanged;
	public event Action Die;

	private void Awake()
	{
		_current = (int)_max;
	}

	private void OnEnable()
	{
		if (_collector != null)
			_collector.PickUpedAidKit += Heal;

	}

	private void OnDisable()
	{
		if (_collector != null)
			_collector.PickUpedAidKit -= Heal;
	}

	public void TakeDamage(int damage)
	{
		_current -= damage;

		if (_current <= 0)
		{
			_current = 0;

			Die?.Invoke();
		}

		ValueChanged?.Invoke(_current);
	}

	public void Heal(int healPoints)
	{
		_current += healPoints;

		if (_current >= _max)
			_current = (int)_max;

		ValueChanged?.Invoke(_current);
	}
}