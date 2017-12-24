namespace LogAdapter.Interfaces
{
	/// <summary>
	/// Class represents a pair of name-value. A log event will be enriched by this pair.
	/// </summary>
	public sealed class PropertyPair
	{
		/// <summary>
		/// Create new instance of class.
		/// </summary>
		/// <param name="name">Name of property.</param>
		/// <param name="value">Value of property.</param>
		public PropertyPair(string name, object value)
		{
			Name = name;
			Value = value;
		}

		/// <summary>
		/// Get name of property.
		/// </summary>
		public string Name{ get; } 

		/// <summary>
		/// Get value of property.
		/// </summary>
		public object Value { get; }
	}
}
