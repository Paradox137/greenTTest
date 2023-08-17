using UniRx;

namespace GreenTest.Fruits.Model
{
	public interface IFruit
	{
		public uint FruitCost { get; set; }
		
		public ReactiveProperty<int> DaysInShop { get; }
		public ReactiveProperty<int> Freshness { get; }
		
		public bool CanEat { get; set; }

		public void ChangeFreshness(int __daysGone);

		public void CheckExpiration(int __newFreshness);
	}
	public enum FruitColor
	{
		Green,
		Red,
		NotFreshColor
	}
}
