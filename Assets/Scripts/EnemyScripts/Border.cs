using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Border : MonoBehaviour
{
	private BoxCollider2D _collider2D;

	private void Awake()
	{
		_collider2D = GetComponent<BoxCollider2D>();

		_collider2D.isTrigger = true;
	}
}
