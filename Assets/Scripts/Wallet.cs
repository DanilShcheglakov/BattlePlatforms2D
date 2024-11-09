using UnityEngine;

public class Wallet : MonoBehaviour
{
	[SerializeField] private Collector _collector;

	public int Amaunt { get; private set; } = 0;

	private void OnEnable()
	{
		_collector.PickUpedCoin += AddCoin;
	}

	private void OnDisable()
	{
		_collector.PickUpedCoin -= AddCoin;
	}

	private void AddCoin()
	{
		Amaunt++;
	}
}
