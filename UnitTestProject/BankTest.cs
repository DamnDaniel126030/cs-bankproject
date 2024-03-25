using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject;

namespace UnitTestProject
{
	internal class BankTest
	{
		[Test]
		public void UjSzamlaEgyenleg0()
		{
			Bank b = new Bank();
			b.UjSzamla("Gipsz Jakab", "1234");
			Assert.That(b.Egyenleg("1234"), Is.Zero);
		}
	}
}
