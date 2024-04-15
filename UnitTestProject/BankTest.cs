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

		[Test]
		public void Egyenleg_NullSzamlaszam()
		{
			Assert.Throws<ArgumentNullException>(() => b.Egyenleg(null));
		}

		[Test]
		public void Egyenleg_UresSzamlaszam()
		{
			Assert.Throws<ArgumentException>(() => b.Egyenleg(""));
		}

		[Test]
		public void Egyenleg_NemLetezoSzamlaszam()
		{
			Assert.Throws<HibasSzamlaszamException>(() => b.Egyenleg("4321"));
		}

		[Test]
		public void EgyenlegFeltolt_NullSzamlaszam()
		{
			Assert.Throws<ArgumentNullException>(() => b.EgyenlegFeltolt(null, 10000));
		}

		[Test]
		public void EgyenlegFeltolt_UreSzamlaszam()
		{
			Assert.Throws<ArgumentException>(() => b.EgyenlegFeltolt("", 10000));
		}

		[Test]
		public void EgyenlegFeltolt_NemLetezoSzamlaszam()
		{
			Assert.Throws<HibasSzamlaszamException>(() => b.EgyenlegFeltolt("4321", 10000));
		}

		[Test]
		public void EgyenlegFeltolt_0OsszegSzamlaszam()
		{
			Assert.Throws<ArgumentException>(() => b.EgyenlegFeltolt("1234", 0));
		}

		[Test]
		public void EgyenlegFeltolt_OsszegMegvaltozik()
		{
			b.EgyenlegFeltolt("1234", 10000);
			Assert.That(b.Egyenleg("1234"), Is.EqualTo(10000));
		}

		[Test]
		public void EgyenlegFeltolt_OsszegHozzaadodik()
		{
			b.EgyenlegFeltolt("1234", 10000);
			Assert.That(b.Egyenleg("1234"), Is.EqualTo(10000));
			b.EgyenlegFeltolt("1234", 20000);
			Assert.That(b.Egyenleg("1234"), Is.EqualTo(30000));
		}

		[Test]
		public void EgyenlegFeltolt_JoSzamlaraKerulAzOsszeg()
		{
			b.UjSzamla("Teszt Elek", "4321");
			b.UjSzamla("Gipsz Jakab", "5678");
			b.EgyenlegFeltolt("1234", 10000);
			Assert.That(b.Egyenleg("1234"), Is.EqualTo(10000));
			b.EgyenlegFeltolt("4321", 20000);
			Assert.That(b.Egyenleg("4321"), Is.EqualTo(20000));
			Assert.That(b.Egyenleg("5678"), Is.Zero);
		}

		public void Utal_Setup()
		{
			b.EgyenlegFeltolt("1234", 50000);
			b.UjSzamla("Teszt Elek", "5678");
			b.EgyenlegFeltolt("5678", 20000);
		}
		[Test]
		public void Utal_NullSzamlaszamHonnan()
		{
			Utal_Setup();
			Assert.Throws<ArgumentNullException>(() => b.Utal(null, "5678", 10000));
		}

		[Test]
		public void Utal_NullSzamlaszamHova()
		{
			Utal_Setup();
			Assert.Throws<ArgumentNullException>(() => b.Utal("1234", null, 10000));
		}

		[Test]
		public void Utal_NemLetezoSzamlaszamHonnan()
		{
			Utal_Setup();
			Assert.Throws<HibasSzamlaszamException>(() => b.Utal("7891", "5678", 10000));
		}

		[Test]
		public void Utal_NemLetezoSzamlaszamHova()
		{
			Utal_Setup();
			Assert.Throws<HibasSzamlaszamException>(() => b.Utal("1234", "7865", 10000));
		}

		[Test]
		public void Utal_UresSzamlaszamHonnan()
		{
			Utal_Setup();
			Assert.Throws<ArgumentException>(() => b.Utal("", "5678", 10000));
		}

		[Test]
		public void Utal_UresSzamlaszamHova()
		{
			Utal_Setup();
			Assert.Throws<ArgumentException>(() => b.Utal("1234", "", 10000));
		}

		[Test]
		public void Utal_0OsszegUtalas()
		{
			Utal_Setup();
			Assert.Throws<ArgumentException>(() => b.Utal("1234", "5678", 0));
		}

		[Test]
		public void Utal_OsszegMegvaltozik()
		{
			Utal_Setup();
			Assert.True(b.Utal("1234", "5678", 10000));
			Assert.That(b.Egyenleg("1234"), Is.EqualTo(40000));
			Assert.That(b.Egyenleg("5678"), Is.EqualTo(30000));
		}

		[Test]
		public void Utal_SikertelenUtalasEgyenlegNemValtozik()
		{
			Utal_Setup();
			Assert.False(b.Utal("1234", "5678", 50001));
			Assert.That(b.Egyenleg("1234"), Is.EqualTo(50000));
			Assert.That(b.Egyenleg("5678"), Is.EqualTo(20000));
		}

		[Test]
		public void Utal_VanETobb()
		{
			Utal_Setup();
			Assert.That(b.Egyenleg("1234"), Is.GreaterThan(20000));
			Assert.True(b.Utal("1234", "5678", 20000));
			Assert.That(b.Egyenleg("1234"), Is.EqualTo(30000));
			Assert.That(b.Egyenleg("5678"), Is.EqualTo(40000));

		}

		[Test]
		public void Utal_VanEUgyanannyi()
		{
			Utal_Setup();
			Assert.True(b.Utal("1234", "5678", 50000));
			Assert.That(b.Egyenleg("1234"), Is.Zero);
		}

		[Test]
		public void Utal_UgyanolyanSzamlszamok()
		{
			Utal_Setup();
			Assert.Throws<ArgumentException>(() => b.Utal("1234", "1234", 10000));
		}
	}
}
