using System;
using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
	[SerializeField] private int _damage;
	[SerializeField] private float _rechargeTime;
	private bool _isEnemyInAttackArea;
	private bool _isRecharged = true;

	public event Action<int> Hitting;

	[SerializeField] public float AttackSpeed { get; private set; }

	public void GiveDamage()
	{
		if (_isEnemyInAttackArea && _isRecharged)
		{
			Hitting?.Invoke(_damage);

			_isRecharged = false;

			Debug.Log("Attack");

			StartCoroutine(Recharge());
			StopCoroutine(Recharge());
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Enemy enemy))
			_isEnemyInAttackArea = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Enemy enemy))
			_isEnemyInAttackArea = false;
	}

	private IEnumerator Recharge()
	{
		var delay = new WaitForSeconds(_rechargeTime);

		yield return delay;

		_isRecharged = true;
	}
}
