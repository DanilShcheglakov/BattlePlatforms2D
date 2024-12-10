using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
	[SerializeField] Enemy _enemy;

	private void OnEnable()
	{
		_enemy.Died += OnDestroy;
	}

	private void OnDisable()
	{
		_enemy.Died += OnDestroy;
	}

	private void OnDestroy()
	{
		Destroy(gameObject);
	}
}
