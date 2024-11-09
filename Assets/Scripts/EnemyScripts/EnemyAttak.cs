using System;
using System.Collections;
using UnityEngine;

public class EnemyAttak : MonoBehaviour
{
	[SerializeField] private int _damage;
	[SerializeField] private float _attackSpeed;

	private bool _isThereAttackTarget;

	private Coroutine _giveDamage;

	public event Action<int> Hitting;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Player player))
		{
			_isThereAttackTarget = true;

			_giveDamage = StartCoroutine(Attak(player));
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<Player>(out _))
		{
			_isThereAttackTarget = false;

			if (_giveDamage != null)
				StopCoroutine(_giveDamage);
		}
	}

	private IEnumerator Attak(Player player)
	{
		var delay = new WaitForSeconds(_attackSpeed);

		while (_isThereAttackTarget)
		{
			Hitting?.Invoke(_damage);

			yield return delay;
		}
	}
}
