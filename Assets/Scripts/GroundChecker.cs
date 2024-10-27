using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
	public event Action Grounded;
	public event Action Fly;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<Ground>(out _))
			Grounded?.Invoke();
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<Ground>(out _))
			Fly?.Invoke();
	}
}
