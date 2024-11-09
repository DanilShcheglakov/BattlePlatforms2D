using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
	public event Action PickUpedCoin;
	public event Action<int> PickUpedAidKit;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Coin coin))
		{
			PickUpedCoin?.Invoke();

			coin.Destroy();
		}

		if (collision.gameObject.TryGetComponent(out AidKit aidKit))
		{
			PickUpedAidKit?.Invoke(aidKit.HealPoints);

			aidKit.Destroy();
		}
	}
}
