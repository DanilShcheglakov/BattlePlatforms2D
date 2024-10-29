using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
	public event Action ConditionsChanged;

	private int _detectedCollisionsWithGround = 0;

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
