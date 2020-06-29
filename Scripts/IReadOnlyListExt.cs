using System;
using System.Collections.Generic;

namespace Kogane
{
	/// <summary>
	/// IReadOnlyList 型の拡張メソッドを管理するクラス
	/// </summary>
	public static partial class LINQExtensionMethods
	{
		//================================================================================
		// ElementAtRandom
		//================================================================================
		/// <summary>
		/// シーケンス内の要素をランダムに返します
		/// </summary>
		public static T ElementAtRandom<T>( this IReadOnlyList<T> self )
		{
			return self.Count <= 0 ? default : self[ Random.Next( self.Count ) ];
		}

		//================================================================================
		// ForEach
		//================================================================================
		/// <summary>
		/// シーケンスの各要素に対して指定された処理を実行します
		/// </summary>
		public static void ForEach<T>( this IReadOnlyList<T> self, Action<T> action )
		{
			for ( var i = 0; i < self.Count; i++ ) 
			{
				action( self[ i ] );
			}
		}

		/// <summary>
		/// シーケンスの各要素に対して指定された処理を実行します
		/// </summary>
		public static void ForEach<T>( this IReadOnlyList<T> self, Action<T, int> action )
		{
			for ( var i = 0; i < self.Count; i++ ) 
			{
				action( self[ i ], i );
			}
		}

		/// <summary>
		/// シーケンスの各要素に対して指定された処理を逆順に実行します
		/// </summary>
		public static void ForEachReverse<T>( this IReadOnlyList<T> self, Action<T> action )
		{
			for ( var i = self.Count - 1; i >= 0; i-- )
			{
				action( self[ i ] );
			}
		}

		/// <summary>
		/// シーケンスの各要素に対して指定された処理を逆順に実行します
		/// </summary>
		public static void ForEachReverse<T>( this IReadOnlyList<T> self, Action<T, int> action )
		{
			for ( var i = self.Count - 1; i >= 0; i-- )
			{
				action( self[ i ], i );
			}
		}

		//================================================================================
		// IsEmpty
		//================================================================================
		/// <summary>
		/// シーケンスが空の場合 true を返します
		/// </summary>
		public static bool IsEmpty<TSource>( this IReadOnlyList<TSource> self )
		{
			return self.Count <= 0;
		}

		/// <summary>
		/// シーケンスが空ではない場合 true を返します
		/// </summary>
		public static bool IsNotEmpty<TSource>( this IReadOnlyList<TSource> self )
		{
			return !self.IsEmpty();
		}

		/// <summary>
		/// シーケンスが null または空の場合 true を返します
		/// </summary>
		public static bool IsNullOrEmpty<T>( this IReadOnlyList<T> self )
		{
			return self == null || self.Count <= 0;
		}

		/// <summary>
		/// シーケンスが null でも空でもない場合 true を返します
		/// </summary>
		public static bool IsNotNullOrEmpty<T>( this IReadOnlyList<T> self )
		{
			return !self.IsNullOrEmpty();
		}
	}
}