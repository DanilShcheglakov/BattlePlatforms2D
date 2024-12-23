using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
	[SerializeField] private Health _health;
	[SerializeField] private int _damage;
	[SerializeField] private float _activeTime;
	[SerializeField] private float _rechargeTime;
	[SerializeField] private float _activeRadius;
	[SerializeField] private SpriteRenderer _spriteRenderer;

	private float _energy;

	private bool _isRecharged = true;

	Coroutine exhaustion;
	Coroutine recharge;

	private WaitForSeconds _waitSecond;

	public event Action<float> EnergyChanged;

	public float MaxEnergy { get; private set; }

	private void Awake()
	{
		_waitSecond = new WaitForSeconds(1);
		MaxEnergy = _activeTime;
		_energy = MaxEnergy;

		_spriteRenderer.enabled = false;
		_spriteRenderer.transform.localScale = new Vector3(1, 1, 1) * _activeRadius;
	}

	public void StartAbility()
	{
		if (_isRecharged)
		{
			_spriteRenderer.enabled = true;

			if (exhaustion != null)
			{
				StopCoroutine(exhaustion);
			}

			exhaustion = StartCoroutine(Exhaustion());
		}
	}

	private IEnumerator Exhaustion()
	{

		while (_energy > 0)
		{
			Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _activeRadius);

			foreach (var enemy in enemies)
			{
				if (enemy.gameObject.TryGetComponent(out Enemy _))
				{
					Health enemyHealth = enemy.gameObject.GetComponent<Health>();

					int healthBeforeAttac = enemyHealth.Current;

					enemyHealth.TakeDamage(_damage);

					int healAfterAttac = healthBeforeAttac - enemyHealth.Current;

					_health.Heal(healAfterAttac);
				}
			}

			_energy -= MaxEnergy / _activeTime;
			EnergyChanged?.Invoke(_energy);
			yield return _waitSecond;
		}

		_isRecharged = false;

		if (recharge != null)
			StopCoroutine(recharge);

		recharge = StartCoroutine(Recharge());
	}

	private IEnumerator Recharge()
	{
		_spriteRenderer.enabled = false;

		if (_energy < 0)
			_energy = 0;

		while (_energy < MaxEnergy)
		{
			_energy += MaxEnergy / _rechargeTime;

			EnergyChanged?.Invoke(_energy);

			yield return _waitSecond;
		}

		if (_energy > MaxEnergy)
			_energy = MaxEnergy;

		_isRecharged = true;
	}
}
