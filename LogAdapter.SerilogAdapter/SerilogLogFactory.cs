using LogAdapter.Interfaces;
using System;
using System.Linq;
using Serilog.Context;
using Serilog.Core.Enrichers;


namespace LogAdapter.SerilogAdapter
{
	public sealed class SerilogLogFactory : ILogFactory
	{
		public ILogger CreateLoggerFor<T>()
		{
			return new SerilogAdapterLogger(Serilog.Log.Logger.ForContext<T>());
		}

		public IDisposable CreateLogContext(params PropertyPair[] propertyPairs)
		{
			return LogContext.Push(
				 propertyPairs
					.Select(pp => new PropertyEnricher(pp.Name, pp.Value))
					.ToArray());
		}
	}
}
