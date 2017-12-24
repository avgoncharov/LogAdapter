using LogAdapter.Interfaces;
using System;

namespace LogAdapter.SerilogAdapter
{
	internal sealed class SerilogAdapterLogger : ILogger
	{
		private Serilog.ILogger _logger;		

		public void Debug(string message)
		{
			_logger.Debug(message);
		}

		public void Error(string message)
		{
			_logger.Error(message);
		}

		public void Error(Exception exception)
		{
			_logger.Error(exception.ToString());
		}

		public void Fatal(string message)
		{
			_logger.Fatal(message);
		}

		public void Fatal(Exception exception)
		{
			_logger.Fatal(exception.ToString());
		}

		public void Information(string message)
		{
			_logger.Information(message);
		}

		public void Warning(string message)
		{
			_logger.Warning(message);
		}

		internal SerilogAdapterLogger(Serilog.ILogger logger)
		{
			_logger = logger;
		}
	}
}
