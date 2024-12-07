public class AddHealth : ManipulationOnHealth
{
	protected override void MakeManipulation()
	{
		_healthForManipulation.Heal(_healthDifferent);
	}
}
