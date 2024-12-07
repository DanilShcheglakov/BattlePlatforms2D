using System;
using TMPro;
using UnityEngine;

public class TextHealth : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _currentHealth;
	[SerializeField] private TextMeshProUGUI _maxHealth;
	[SerializeField] private Health _healthClass;

	private void Awake()
	{
		_currentHealth.text = Convert.ToString(_healthClass.Max);
		_maxHealth.text = Convert.ToString(_healthClass.Max);
	}

	private void OnEnable()
	{
		_healthClass.ValueChanged += UpdateTextState;
	}

	private void OnDisable()
	{
		_healthClass.ValueChanged -= UpdateTextState;
	}

	private void UpdateTextState(int currentHealth)
	{
		_currentHealth.text = Convert.ToString(currentHealth);
	}
}
