using System;
using UnityEngine;
using Zenject;

namespace GreenTest.Fruits.Controller
{
	public sealed class ShopWorkTester
	{
		private FruitShop _fruitShop;

		[Inject]
		public void Init(FruitShop __fruitShop)
		{
			_fruitShop = __fruitShop;
			StartTesting();
		}
		private void StartTesting()
		{
			int daysgone = 7;
			
			Debug.Log($"<color=white>Прошло {daysgone} дней, нужно посмотреть свежесть всех продуктов</color>");
			
			_fruitShop.UpdateShopInformationAboutFreshness(daysgone);
			
			
			daysgone = 6;
			
			Debug.Log($"<color=white>Прошло ещё {daysgone} дней, нужно посчитать сколько лежат продукты</color>");
			
			_fruitShop.UpdateShopInformationAboutDays(daysgone);
			
			
			daysgone = 1;
			
			Debug.Log($"<color=white>Прошло ещё {daysgone} дней, пришёл хороший клиент, нужно отобрать только съедобные фрукты со свежестью > 5</color>");
			
			_fruitShop.UpdateShopInformationAboutGoodFruits(daysgone);
		}
	}
}
