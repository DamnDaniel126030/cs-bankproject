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
		Bank b;

		[SetUp]
		public void Setup()
		{
			b = new Bank();
			b.UjSzamla("Gipsz Jakab", "1234");
		}

		[Test]
		public void UjSzamlaEgyenleg0()
		{
			Assert.That(b.Egyenleg("1234"), Is.Zero);
		}

		[Test]
		public void UjSzamlaUresNev()
		{
			Assert.Throws<ArgumentException>(() => b.UjSzamla("", "1234"));
		}

		[Test]
		public void UjSzamlaUresSzamlaszam()
		{
			Assert.Throws<ArgumentException>(() => b.UjSzamla("Teszt Elek", ""));
		}

		[Test]
		public void UjSzamlaNullNev()
		{
			Assert.Throws<ArgumentNullException>(() => b.UjSzamla(null, "1234"));
		}

		[Test]
		public void UjSzamlaNullSzamlaszam()
		{
			Assert.Throws<ArgumentNullException>(() => b.UjSzamla("Teszt Elek", null));
		}

		[Test]
		public void UjSzamlaLetezoSzamlaszam()
		{
			Assert.Throws<ArgumentException>(() => b.UjSzamla("Teszt Elek", "1234"));
		}

		[Test]
		public void UjSzamlaLetezoNev()
		{
			Assert.DoesNotThrow(() => b.UjSzamla("Gipsz Jakab", "5678"));
		}
	}
}
