using System;
namespace SeleniumXUnit.Setting
{
	public class TestSetting
	{
		public TestSetting()
		{
		}

		public BrowserType BrowserType { get; set; }
		public Uri ApplicationUrl  { get; set; }
		public int TimeOutInterval { get; set; }
	}
}

