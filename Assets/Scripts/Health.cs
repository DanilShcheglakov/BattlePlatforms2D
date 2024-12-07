using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private Collector _collector;

	[field: SerializeField] public uint Max { get; private set; }
	public int Current { get; private set; }

	public event Action<int> ValueChanged;
	public event Action Die;

	private void Awake()
	{
		Current = (int)Max;
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
		Current -= damage;

		if (Current <= 0)
		{
			Current = 0;

			Die?.Invoke();
		}

		ValueChanged?.Invoke(Current);
	}

	public void Heal(int healPoints)
	{
		Current += healPoints;

		if (Current >= Max)
			Current = (int)Max;

		ValueChanged?.Invoke(Current);
	}
}