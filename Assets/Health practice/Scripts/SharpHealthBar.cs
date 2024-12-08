public class SharpHealthBar : HealthBar
{
	protected override void UpdateState(int currentHealth)
	{
		HealtBar.value = ((float)currentHealth) / HealthClass.Max;
	}
}
