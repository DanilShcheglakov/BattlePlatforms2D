using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
	public event Action PickUpedCoin;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Coin coin))
		{
			PickUpedCoin?.Invoke();

			coin.Destroy();
		}
	}
}
