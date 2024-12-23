using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
	[SerializeField] private Slider _healthBar;
	[SerializeField] private Vampirism _vampirism;

	private void Awake()
	{
		SetDefaultState();
	}

	private void OnEnable()
	{
		_vampirism.EnergyChanged += UpdateState;
	}

	private void OnDisable()
	{
		_vampirism.EnergyChanged -= UpdateState;
	}

	private void SetDefaultState()
	{
		_healthBar.value = _healthBar.maxValue;
	}

	private void UpdateState(float currentValue)
	{
		_healthBar.value = (currentValue / _vampirism.MaxEnergy);
	}
}
