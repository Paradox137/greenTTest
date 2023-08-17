using UniRx;
using UnityEngine;

namespace GreenTest.Fruits.Model
{
	public  abstract class Fruit : IFruit
	{
		public uint FruitCost { get; set; }
		public bool CanEat { get; set; }
		
		private ReactiveProperty<int> _freshness;
		public ReactiveProperty<int> Freshness => _freshness;

		private ReactiveProperty<int> _daysInShop;
		
		public ReactiveProperty<int> DaysInShop => _daysInShop;
		
		protected Fruit(uint __fruitCost, int __freshness)
		{
			if (__freshness > 0)
				CanEat = true;
			
			_daysInShop = new ReactiveProperty<int>(0);
			_freshness = new ReactiveProperty<int>(__freshness);
			
			FruitCost = __fruitCost;
		}

		public virtual void ChangeFreshness(int __daysGone)
		{
			
		}

		public void CheckExpiration(int __newFreshness)
		{
			if (__newFreshness < 0)
			{
				CanEat = false;
			}
		}
	}
}
