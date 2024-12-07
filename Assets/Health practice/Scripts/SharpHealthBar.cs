public class SharpHealthBar : BarHealthMotherClass
{
	protected override void UpdateState(int currentHealth)
	{
		_healtBar.value = ((float)currentHealth) / _healthClass.Max;
	}
}
