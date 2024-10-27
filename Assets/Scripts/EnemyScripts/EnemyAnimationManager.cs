using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
	private Transform _transform;

	private void Awake()
	{
		_transform = GetComponent<Transform>();	
	}

	public void ChangeDirection()
	{
		float tiltAngle = 180;
		Vector3 rotateAngle = new Vector3(0, tiltAngle);

		_transform.Rotate(rotateAngle);
	}
}
