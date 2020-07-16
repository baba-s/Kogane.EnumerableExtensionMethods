using System;
using System.Collections.ObjectModel;

namespace Kogane
{
	/// <remarks>
	/// 配列の拡張メソッド
	/// このスクリプトでは Array クラスの static 関数を拡張メソッドで呼び出せるようにしたものを定義
	/// </remarks>
	public static partial class LINQExtensionMethods
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// 指定した配列をラップする読み取り専用のラッパーを作成します
		/// </summary>
		public static ReadOnlyCollection<T> AsReadOnly<T>( this T[] array )
		{
			return Array.AsReadOnly( array );
		}

		/// <summary>
		/// Array 内の要素の範囲を、要素の型に応じて、0 (ゼロ)、false、または null に設定します
		/// </summary>
		public static void Clear( this Array array )
		{
			Array.Clear( array, 0, array.Length );
		}

		/// <summary>
		/// Array 内の要素の範囲を、要素の型に応じて、0 (ゼロ)、false、または null に設定します
		/// </summary>
		public static void Clear( this Array array, int index )
		{
			Array.Clear( array, index, array.Length );
		}

		/// <summary>
		/// Array 内の要素の範囲を、要素の型に応じて、0 (ゼロ)、false、または null に設定します
		/// </summary>
		public static void Clear
		(
			this Array array,
			int        index,
			int        length
		)
		{
			Array.Clear( array, index, length );
		}

		/// <summary>
		/// 指定された配列に、指定された述語によって定義された条件と一致する要素が
		/// 含まれているかどうかを判断します
		/// </summary>
		public static bool Exists<T>( this T[] array, Predicate<T> match )
		{
			return Array.Exists( array, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を検索し、
		/// Array 全体の中で最もインデックス番号の小さい要素を返します
		/// </summary>
		public static T Find<T>( this T[] array, Predicate<T> match )
		{
			return Array.Find( array, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致するすべての要素を取得します
		/// </summary>
		public static T[] FindAll<T>( this T[] array, Predicate<T> match )
		{
			return Array.FindAll( array, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、Array 全体を対象に検索し、
		/// 最もインデックス番号の小さい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindIndex<T>( this T[] array, Predicate<T> match )
		{
			return Array.FindIndex( array, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、
		/// Array の指定されたインデックスから、最後の要素までを範囲として検索し、
		/// 最もインデックス番号の小さい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindIndex<T>
		(
			this T[]     array,
			int          startIndex,
			Predicate<T> match
		)
		{
			return Array.FindIndex( array, startIndex, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、
		/// Array の指定されたインデックスから、指定された要素数を範囲として検索し、
		/// 最もインデックス番号の小さい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindIndex<T>
		(
			this T[]     array,
			int          startIndex,
			int          count,
			Predicate<T> match
		)
		{
			return Array.FindIndex( array, startIndex, count, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、
		/// Array 全体を対象に検索し、最もインデックス番号の大きい要素を返します
		/// </summary>
		public static T FindLast<T>( this T[] array, Predicate<T> match )
		{
			return Array.FindLast( array, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、
		/// Array 全体を対象に検索し、最もインデックス番号の大きい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindLastIndex<T>( this T[] array, Predicate<T> match )
		{
			return Array.FindLastIndex( array, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、
		/// Array の先頭の要素から、指定されたインデックス位置までを範囲として検索し、
		/// 最もインデックス番号の大きい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindLastIndex<T>
		(
			this T[]     array,
			int          startIndex,
			Predicate<T> match
		)
		{
			return Array.FindLastIndex( array, startIndex, match );
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、
		/// Array の指定されたインデックス位置から、指定された要素数までを範囲として検索し、
		/// 最もインデックス番号の大きい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindLastIndex<T>
		(
			this T[]     array,
			int          startIndex,
			int          count,
			Predicate<T> match
		)
		{
			return Array.FindLastIndex( array, startIndex, count, match );
		}

		/// <summary>
		/// 指定された配列内の各要素に対して、指定された処理を実行します
		/// </summary>
		public static void ForEach<T>( this T[] array, Action<T> action )
		{
			for ( int i = 0; i < array.Length; i++ )
			{
				action( array[ i ] );
			}
		}

		/// <summary>
		/// 指定された配列内の各要素に対して、指定された処理を実行します
		/// </summary>
		public static void ForEach<T>( this T[] array, Action<T, int> action )
		{
			for ( int i = 0; i < array.Length; i++ )
			{
				action( array[ i ], i );
			}
		}

		/// <summary>
		/// Array 全体を対象に指定したオブジェクトを検索し、
		/// インデックス番号の最も小さい要素のインデックスを返します
		/// </summary>
		public static int IndexOf<T>( this T[] array, T value )
		{
			return Array.IndexOf( array, value );
		}

		/// <summary>
		/// 指定したオブジェクトを検索し、
		/// 1 次元の Array 全体でそのオブジェクトが最初に見つかった位置のインデックス番号を返します
		/// </summary>
		public static int IndexOf( this Array array, Object value )
		{
			return Array.IndexOf( array, value );
		}

		/// <summary>
		/// 指定したオブジェクトを、Array の指定したインデックス位置から最後の要素までを範囲として検索し、
		/// 最もインデックス番号の小さい要素のインデックス番号を返します
		/// </summary>
		public static int IndexOf<T>
		(
			this T[] array,
			T        value,
			int      startIndex
		)
		{
			return Array.IndexOf( array, value, startIndex );
		}

		/// <summary>
		/// 指定されたオブジェクトを、
		/// 1 次元 Array の指定されたインデックスから最後の要素までを範囲として検索し、
		/// インデックス番号の最も小さい要素のインデックス番号を返します
		/// </summary>
		public static int IndexOf
		(
			this Array array,
			Object     value,
			int        startIndex
		)
		{
			return Array.IndexOf( array, value, startIndex );
		}

		/// <summary>
		/// 指定したオブジェクトを、Array の指定したインデックスから指定した要素数を範囲として検索し、
		/// インデックス番号の最も小さい要素のインデックス番号を返します
		/// </summary>
		public static int IndexOf<T>
		(
			this T[] array,
			T        value,
			int      startIndex,
			int      count
		)
		{
			return Array.IndexOf( array, value, startIndex, count );
		}

		/// <summary>
		/// 指定したオブジェクトを、指定したインデックス位置から、
		/// 指定した要素数を範囲とする 1 次元 Array 要素の範囲内で検索し、
		/// 最もインデックス番号の小さい要素のインデックス番号を返します
		/// </summary>
		public static int IndexOf
		(
			this Array array,
			Object     value,
			int        startIndex,
			int        count
		)
		{
			return Array.IndexOf( array, value, startIndex, count );
		}

		/// <summary>
		/// 指定したオブジェクトを Array 全体を対象に検索し、
		/// インデックス番号の最も大きい要素のインデックスを返します
		/// </summary>
		public static int LastIndexOf<T>( this T[] array, T value )
		{
			return Array.LastIndexOf( array, value );
		}

		/// <summary>
		/// 指定したオブジェクトを検索し、
		/// 1 次元の Array 全体でそのオブジェクトが最後に見つかった位置のインデックス番号を返します
		/// </summary>
		public static int LastIndexOf( this Array array, Object value )
		{
			return Array.LastIndexOf( array, value );
		}

		/// <summary>
		/// 指定したオブジェクトを、Array の先頭の要素から、
		/// 指定されたインデックス位置までを範囲として検索し、
		/// インデックス番号の最も大きい要素のインデックス番号を返します
		/// </summary>
		public static int LastIndexOf<T>
		(
			this T[] array,
			T        value,
			int      startIndex
		)
		{
			return Array.LastIndexOf( array, value, startIndex );
		}

		/// <summary>
		/// 1 次元 Array の先頭の要素から、指定したインデックスまでを対象に指定したオブジェクトを検索し、
		/// インデックス番号の最も大きい要素のインデックス番号を返します
		/// </summary>
		public static int LastIndexOf
		(
			this Array array,
			Object     value,
			int        startIndex
		)
		{
			return Array.LastIndexOf( array, value, startIndex );
		}

		/// <summary>
		/// 指定したオブジェクトを、Array の指定したインデックス位置から、
		/// 指定した要素数を範囲として検索し、インデックス番号の最も大きい要素のインデックス番号を返します
		/// </summary>
		public static int LastIndexOf<T>
		(
			this T[] array,
			T        value,
			int      startIndex,
			int      count
		)
		{
			return Array.LastIndexOf( array, value, startIndex, count );
		}

		/// <summary>
		/// 指定したオブジェクトを、1 次元 Array の指定したインデックス位置から、
		/// 指定した要素数を範囲として検索し、インデックス番号の最も大きい要素のインデックス番号を返します
		/// </summary>
		public static int LastIndexOf
		(
			this Array array,
			Object     value,
			int        startIndex,
			int        count
		)
		{
			return Array.LastIndexOf( array, value, startIndex, count );
		}

		/// <summary>
		/// 1 次元の Array 内全体の要素のシーケンスを反転させます
		/// </summary>
		public static T[] Reverse<T>( this T[] array )
		{
			Array.Reverse( array );
			return array;
		}

		/// <summary>
		/// 1 次元 Array 内の要素範囲の並び順を反転させます
		/// </summary>
		public static T[] Reverse<T>
		(
			this T[] array,
			int      index,
			int      length
		)
		{
			Array.Reverse( array, index, length );
			return array;
		}

		/// <summary>
		/// 配列内のすべての要素が、指定された述語によって定義された条件と一致するかどうかを調べます
		/// </summary>
		public static bool TrueForAll<T>( this T[] array, Predicate<T> match )
		{
			return Array.TrueForAll( array, match );
		}

		/// <summary>
		/// Array 全体の要素を並べ替えます
		/// </summary>
		public static void Sort<T>( this T[] array )
		{
			Array.Sort( array );
		}

		/// <summary>
		/// Array 内の要素を、指定した Comparison&lt;T&gt; を使用して並べ替えます
		/// </summary>
		public static void Sort<T>( this T[] array, Comparison<T> comparison )
		{
			Array.Sort( array, comparison );
		}

		/// <summary>
		/// Array 内の要素を、指定した Func&lt;TSource, TResult&gt; を使用して並べ替えます
		/// </summary>
		public static void Sort<TSource, TResult>( this TSource[] array, Func<TSource, TResult> selector ) where TResult : IComparable
		{
			Array.Sort( array, ( x, y ) => selector( x ).CompareTo( selector( y ) ) );
		}
	}
}