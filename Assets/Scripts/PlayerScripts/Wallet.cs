using UnityEngine;

public class Wallet : MonoBehaviour
{
	[SerializeField] private Collector _collector;

	public int Amount { get; private set; } = 0;

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
		Amount++;
	}
}
