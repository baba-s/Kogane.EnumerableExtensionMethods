using System;
using System.Collections.Generic;
using System.Linq;

namespace Kogane
{
	/// <remarks>
	/// IReadOnlyList 型の拡張メソッド
	/// このスクリプトでは Nearest 系の拡張メソッドを定義
	/// </remarks>
	public static partial class EnumerableExtensionMethods
	{
		//================================================================================
		// Nearest
		//================================================================================
		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int Nearest
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var min = self.Min( c => Math.Abs( c - target ) );
			return self.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int Nearest<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( self.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearest
		//================================================================================
		/// <summary>
		/// 目的の値に最も近い値を持つ要素を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearest<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return self.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrDefault
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var min = self.Min( c => Math.Abs( c - target ) );
			return self.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( self.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近い値を持つ要素を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var min = self.Min( c => Math.Abs( selector( c ) - target ) );
			return self.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestMoreThan
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestMoreThan
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var list = self.Where( c => target < c ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestMoreThan<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestMoreThan
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearestMoreThan<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestMoreThanOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestMoreThanOrDefault
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var list = self.Where( c => target < c ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestMoreThanOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestMoreThanOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestMoreThanOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrLess
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestOrLess
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var list = self.Where( c => c <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestOrLess<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrLess
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearestOrLess<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrLessOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrLessOrDefault
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var list = self.Where( c => c <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrLessOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrLessOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestOrLessOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrMore
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestOrMore
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var list = self.Where( c => target <= c ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestOrMore<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrMore
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearestOrMore<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrMoreOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrMoreOrDefault
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var list = self.Where( c => target <= c ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestOrMoreOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrMoreOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestOrMoreOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.Find( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestMoreLess
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestMoreLess
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var list = self.Where( c => c < target ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static int NearestMoreLess<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestMoreLess
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します。見つからなかった場合は例外を投げます
		/// </summary>
		public static TSource FindNearestMoreLess<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestMoreLessOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestMoreLessOrDefault
		(
			this IReadOnlyList<int> self,
			int                     target
		)
		{
			var list = self.Where( c => c < target ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.Find( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は null を返します
		/// </summary>
		public static int NearestMoreLessOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.Find( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestMoreLessOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します。見つからなかった場合は null を返します
		/// </summary>
		public static TSource FindNearestMoreLessOrDefault<TSource>
		(
			this IReadOnlyList<TSource> self,
			int                         target,
			Func<TSource, int>          selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.Find( c => Math.Abs( selector( c ) - target ) == min );
		}
	}
}