using UniRx;
using UnityEngine;

namespace GreenTest.Fruits.Model
{
	public sealed class Apple : Fruit
	{
		public Apple(uint __fruitCost, int __freshness) : base(__fruitCost, __freshness)
		{
			
		}
		
		public override void ChangeFreshness(int __daysGone)
		{
			base.ChangeFreshness(__daysGone);
			
			Freshness.Value -= __daysGone / 2;
			
			if (Freshness.Value < 0)
				CanEat = false;
		}
	}
}