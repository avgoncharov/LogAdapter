using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Serilog;

namespace LogAdapter.SerilogAdapter.Tests
{
	[TestClass]
	public class AdapterTests
	{
		private StringWriter _recevier;
		Interfaces.ILogFactory _logFactory;
		
		[TestInitialize]
		public void Setup()
		{
			_recevier = new StringWriter();
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.Enrich.FromLogContext()
				.Enrich.WithProperty("Check", "Empty")
				.WriteTo.TextWriter(_recevier, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}[{Level:u3}][{SourceContext}][{Check}][{InnerCheck}]{Message}{NewLine}{Exception}")
				.CreateLogger();

			_logFactory = new SerilogLogFactory();
			
			
		}

		[TestCleanup]
		public void Teardown()
		{
			if (_recevier != null) {
				_recevier.Dispose();
			}
		}

		[TestMethod]
		public void InformationWithoutContextTest()
		{
			var logger = _logFactory.CreateLoggerFor<AdapterTests>();

			logger.Information("Hello from adaper.");

			Log.CloseAndFlush();

			var actual = _recevier.ToString();
			Assert.IsFalse(string.IsNullOrWhiteSpace(actual));
			Assert.IsTrue(actual.Contains("INF"));
			Assert.IsTrue(actual.Contains("Empty"));
		}

		[TestMethod]
		public void InformatinoWithContextTests()
		{
			var logger = _logFactory.CreateLoggerFor<AdapterTests>();

			using (_logFactory.CreateLogContext(
				new Interfaces.PropertyPair("Check", "Not empty"),
				new Interfaces.PropertyPair("InnerCheck", 32))) {

				logger.Warning("Wow.");
			}

			var actual = _recevier.ToString();
			Assert.IsFalse(string.IsNullOrWhiteSpace(actual));
			Assert.IsFalse(actual.Contains("INF"), actual);
			Assert.IsTrue(actual.Contains("WRN"), actual);
			Assert.IsTrue(actual.Contains("[Not empty]"));
			Assert.IsTrue(actual.Contains("[32]"));
		}
	}
}
