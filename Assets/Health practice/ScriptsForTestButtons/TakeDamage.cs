public class TakeDamage : ManipulationOnHealth
{
	protected override void MakeManipulation()
	{
		_healthForManipulation.TakeDamage(_healthDifferent);
	}
}
