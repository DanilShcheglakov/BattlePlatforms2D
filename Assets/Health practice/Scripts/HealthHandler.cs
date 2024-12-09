using UnityEngine;

public abstract class HealthHandler : MonoBehaviour
{
	[field: SerializeField] protected Health HealthClass;

	private void Awake()
	{
		SetDefaultState();
	}

	private void OnEnable()
	{
		HealthClass.ValueChanged += UpdateState;
	}

	private void OnDisable()
	{
		HealthClass.ValueChanged -= UpdateState;
	}

	protected abstract void SetDefaultState();
	protected abstract void UpdateState(int currentHealth);
}
