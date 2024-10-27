using UnityEngine;

public class Camera : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] protected float _offset = 2f;

	private Vector3 _differenceOfPosition;

	private void Start()
	{
		transform.position = _target.position + new Vector3(0f, 0f, -1f);
	}

	private void LateUpdate()
	{
		_differenceOfPosition = transform.position - _target.position;

		if (IsTargetGetOut())
			ChangePosition();
	}

	private bool IsTargetGetOut()
	{
		float differenceDistance = _differenceOfPosition.magnitude;

		return differenceDistance > _offset;
	}

	private void ChangePosition()
	{
		Vector2 direction = -_differenceOfPosition;

		transform.Translate(direction * Time.fixedDeltaTime);
	}
}
