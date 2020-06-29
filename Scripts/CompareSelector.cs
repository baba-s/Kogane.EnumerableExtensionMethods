using System;
using System.Collections.Generic;

namespace Kogane
{
	public static partial class LINQExtensionMethods
	{
		private sealed class CompareSelector<T, TKey> : IEqualityComparer<T>
		{
			private readonly Func<T, TKey> m_selector;

			public CompareSelector( Func<T, TKey> selector )
			{
				m_selector = selector;
			}

			public bool Equals( T x, T y )
			{
				return m_selector( x ).Equals( m_selector( y ) );
			}

			public int GetHashCode( T obj )
			{
				return m_selector( obj ).GetHashCode();
			}
		}
	}
}