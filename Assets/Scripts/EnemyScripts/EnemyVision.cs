using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
	public event Action<Player> PlayerDetected;
	public event Action<Player> PlayerUnDetected;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Player player))
			PlayerDetected?.Invoke(player);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Player player))
			PlayerUnDetected?.Invoke(null);
	}
}
