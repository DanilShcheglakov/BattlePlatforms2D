using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
	public event Action PickUpedCoin;
	public event Action<int> PickUpedAidKit;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out CollectableThing pickUppedObject))
		{
			if (pickUppedObject is Coin)
				PickUpedCoin?.Invoke();

			if (pickUppedObject is AidKit)
				PickUpedAidKit?.Invoke(((AidKit)pickUppedObject).HealPoints);

			pickUppedObject.Destroy();
		}
	}
}
