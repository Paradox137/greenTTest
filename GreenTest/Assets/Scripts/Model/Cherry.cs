using UniRx;

namespace GreenTest.Fruits.Model
{
	public sealed class Cherry : Fruit
	{

		public Cherry(uint __fruitCost, int __freshness) : base(__fruitCost, __freshness)
		{
			
		}
		
		public override void ChangeFreshness(int __daysGone)
		{
			base.ChangeFreshness(__daysGone);
			
			Freshness.Value -= __daysGone;

			if (Freshness.Value < 0)
				CanEat = false;
		}
	}
}
