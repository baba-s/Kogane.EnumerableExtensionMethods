using System;
using System.Collections.Generic;
using System.Linq;

namespace Kogane
{
	/// <summary>
	/// IEnumerable 型の拡張メソッドを管理するクラス
	/// </summary>
	public static partial class LINQExtensionMethods
	{
		public static T Find<T>( this IReadOnlyList<T> self, Predicate<T> match )
		{
			for ( var i = 0; i < self.Count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					return self[ i ];
				}
			}

			return default;
		}

		public static List<T> FindAll<T>( this IReadOnlyList<T> self, Predicate<T> match )
		{
			var result = new List<T>();
			for ( var i = 0; i < self.Count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					result.Add( self[ i ] );
				}
			}

			return result;
		}

		public static int FindIndex<T>
		(
			this IReadOnlyList<T> self,
			int                   startIndex,
			int                   count,
			Predicate<T>          match
		)
		{
			for ( var i = startIndex; i < startIndex + count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					return i;
				}
			}

			return -1;
		}

		public static int FindIndex<T>
		(
			this IReadOnlyList<T> self,
			int                   startIndex,
			Predicate<T>          match
		)
		{
			for ( var i = startIndex; i < self.Count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					return i;
				}
			}

			return -1;
		}

		public static int FindIndex<T>( this IReadOnlyList<T> self, Predicate<T> match )
		{
			for ( var i = 0; i < self.Count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					return i;
				}
			}

			return -1;
		}

		public static T FindLast<T>( this IReadOnlyList<T> self, Predicate<T> match )
		{
			for ( var i = self.Count - 1; 0 <= i; i-- )
			{
				if ( match( self[ i ] ) )
				{
					return self[ i ];
				}
			}

			return default;
		}

		public static int FindLastIndex<T>( this IList<T> self, Predicate<T> match )
		{
			for ( int i = self.Count - 1; 0 <= i; i-- ) 
			{
				if ( match( self[ i ] ) )
				{
					return i;
				}
			}
			return -1;
		}
	}
}