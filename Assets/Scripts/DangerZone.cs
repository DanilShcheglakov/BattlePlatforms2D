using System;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
   public event Action Entered;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Player _))		
			Entered?.Invoke();		
	}
}
