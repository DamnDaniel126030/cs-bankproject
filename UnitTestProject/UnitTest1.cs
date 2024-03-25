namespace UnitTestProject
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void Test1()
		{
			Assert.Pass();
		}
		[Test]  // Test annotáció - ez jelöli, hogy az adott függvény egy teszteset
		public void Test2()
		{
			Assert.Fail();
		}

		public void Test3()
		{
			Assert.Pass();
		}
	}
}