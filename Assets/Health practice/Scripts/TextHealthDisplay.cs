using System;
using TMPro;
using UnityEngine;

public class TextHealthDisplay : HealthHandler
{
	[SerializeField] private TextMeshProUGUI _currentHealth;
	[SerializeField] private TextMeshProUGUI _maxHealth;

	protected override void SetDefaultState()
	{
		_currentHealth.text = Convert.ToString(HealthClass.Max);
		_maxHealth.text = Convert.ToString(HealthClass.Max);
	}

	protected override void UpdateState(int currentHealth)
	{
		_currentHealth.text = Convert.ToString(currentHealth);
	}
}
