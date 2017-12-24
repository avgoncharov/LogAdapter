using System;

namespace LogAdapter.Interfaces
{
	/// <summary>
	/// Core log API.
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// Write a log event with the 'Debug' level.
		/// </summary>
		/// <param name="message">Message describing log event.</param>
		void Debug(string message);

		/// <summary>
		/// Write a log event with Information level.
		/// </summary>
		/// <param name="message">Message describing log event.</param>
		void Information(string message);

		/// <summary>
		/// Write a log event with the 'Warning' level.
		/// </summary>
		/// <param name="message">Message describing log event.</param>
		void Warning(string message);

		/// <summary>
		/// Write a log event with the 'Error' level.
		/// </summary>
		/// <param name="message">Message describing log event.</param>
		void Error(string message);

		/// <summary>
		/// Write a log event with the 'Error' level.
		/// </summary>
		/// <param name="exception">Exception describing log event.</param>
		void Error(Exception exception);

		/// <summary>
		/// Write a log event with the 'Fatal' level.
		/// </summary>
		/// <param name="message">Message describing log event.</param>
		void Fatal(string message);

		/// <summary>
		/// Write a log event with the 'Fatal' level.
		/// </summary>
		/// <param name="exception">Exception describing log event.</param>
		void Fatal(Exception exception);		
	}
}
