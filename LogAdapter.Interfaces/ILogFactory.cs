using System;

namespace LogAdapter.Interfaces
{
    public interface ILogFactory
    {
		/// <summary>
		/// Create new logger for type T.
		/// </summary>
		/// <typeparam name="T">Type which logger is creating for.</typeparam>
		/// <returns></returns>
		ILogger CreateLoggerFor<T>();

		/// <summary>
		/// Create new log context.
		/// </summary>
		/// <param name="propertyPairs">Properties for context.</param>
		/// <returns>New log context.</returns>
		IDisposable CreateLogContext(params PropertyPair[] propertyPairs);
	}
}
