using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
	private int _detectedCollisionsWithGround = 0;

	public event Action ConditionsChanged;

	public bool IsGrounded => _detectedCollisionsWithGround > 0;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<Ground>(out _))
		{
			_detectedCollisionsWithGround++;

			ConditionsChanged?.Invoke();
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<Ground>(out _))
		{
			_detectedCollisionsWithGround--;

			ConditionsChanged?.Invoke();
		}
	}
}
