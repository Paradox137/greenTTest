using System.Collections.Generic;
using GreenTest.Fruits.Controller;
using GreenTest.Fruits.Model;
using UnityEngine;
using Zenject;

namespace GreenTest.Fruits.Installers
{
	public sealed class FruitShopInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			List<IFruit> fruits = new List<IFruit>()
			{
				new Apple(5, 20),
				new Cherry(20, 40),
				new Apple(3, 2),
				new Cherry(8, 1),
				new Apple(5, 34),
			};
			
			Container.BindInstance(fruits).AsSingle();
			Container.Bind<FruitShop>().AsSingle();

			ShopWorkTester shopWorkTester = new ShopWorkTester();
			Container.Inject(shopWorkTester);
		}
	}
}
