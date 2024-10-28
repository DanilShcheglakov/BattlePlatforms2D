using UnityEngine;

public class CameraRig : MonoBehaviour
{
	[SerializeField] protected float Offset = 2f;
	[SerializeField] private Transform _target;

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

		return differenceDistance > Offset;
	}

	private void ChangePosition()
	{
		Vector2 direction = -_differenceOfPosition;

		transform.Translate(direction * Time.fixedDeltaTime);
	}
}
