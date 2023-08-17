using System;
using System.Collections.Generic;
using System.Linq;
using GreenTest.Fruits.Model;
using UniRx;
using UnityEngine;
using Zenject;

namespace GreenTest.Fruits.Controller
{
	public sealed class FruitShop
	{
		private CompositeDisposable disposables;
		
		private List<IFruit> _fruits;

		[Inject]
		public FruitShop(List<IFruit> __fruits)
		{
			Debug.Log($"<color=white>Пришла новая партия фруктов</color>");
			
			disposables = new CompositeDisposable();
			_fruits = __fruits;
			
			SetupFruitsDaysObserve();
			ObserveFreshness();
		}
		private void SetupFruitsDaysObserve()
		{
			foreach (IFruit fruit in _fruits)
			{
				fruit.DaysInShop
					.Subscribe(days => fruit.ChangeFreshness(days))
					.AddTo(disposables);
			}
		}
		
		public void UpdateShopInformationAboutFreshness(int __daysGone)
		{
			foreach (var fruit in _fruits)
			{
				fruit.DaysInShop.Value += __daysGone;
			}
			
			ObserveFreshness();
		}

		public void UpdateShopInformationAboutDays(int __daysGone)
		{
			foreach (var fruit in _fruits)
			{
				fruit.DaysInShop.Value += __daysGone;
			}

			ObserveDays();
		}
		
		public void UpdateShopInformationAboutGoodFruits(int __daysGone)
		{
			foreach (var fruit in _fruits)
			{
				fruit.DaysInShop.Value += __daysGone;
			}

			ObserveOnlyFreshFruits();
		}
		
		private void ObserveFreshness()
		{
			foreach (IFruit fruit in _fruits)
			{
				fruit.Freshness
					.Subscribe(fresh => fruit.CheckExpiration(fresh))
					.AddTo(disposables);
			}
			
			IObservable<int> allFreshness = _fruits.Select(fruit => fruit.Freshness).Merge();
			allFreshness.Subscribe(x => Debug.Log($"<color=cyan>Свежесть продукта: {x}</color>"))
				.Dispose();
		}
		private void ObserveDays()
		{
			IObservable<IEnumerable<IFruit>> allDays = Observable.Return(_fruits.AsEnumerable());
			
			allDays.
				SelectMany(fruits => fruits.Select(fruit=>fruit.DaysInShop))
				.Subscribe(x => Debug.Log($"<color=green>Дней в магазине: {x}</color>"))
				.Dispose();
		}

		private void ObserveOnlyFreshFruits()
		{
			IObservable<IEnumerable<IFruit>> onlyFresh = Observable.Return(_fruits.AsEnumerable());

			onlyFresh
				.SelectMany(fruits => fruits.Where(fruit => fruit.CanEat));
				
			onlyFresh
				.SelectMany(fruits => fruits.Where(fruit => fruit.Freshness.Value > 5))
				.Subscribe(x => Debug.Log($"<color=yellow>Нашёл: {x.ToString()} со свежестью {x.Freshness} и стоимостью {x.FruitCost}</color>"))
				.Dispose();
		}
		
		~FruitShop()
		{
			disposables.Dispose();
		}
	}
}
