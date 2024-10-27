using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
	public event Action PickUpedCoin;

	public void CoinPickUp()
	{
		PickUpedCoin?.Invoke();
	}
}
