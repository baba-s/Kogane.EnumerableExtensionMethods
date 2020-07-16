using System;
using System.Collections.Generic;

namespace Kogane
{
	/// <remarks>
	/// IReadOnlyList 型の拡張メソッド
	/// このスクリプトでは List 型の読み取り専用の機能を呼び出せるようにした拡張メソッドを定義
	/// </remarks>
	public static partial class LINQExtensionMethods
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// IReadOnlyList&lt;T&gt; に、
		/// 指定された述語によって定義された条件と一致する要素が含まれているかどうかを判断します
		/// </summary>
		public static bool Exists<T>( this IReadOnlyList<T> self, Predicate<T> match )
		{
			for ( var i = 0; i < self.Count; i++ )
			{
				if ( match( self[ i ] ) )
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を検索し、
		/// IReadOnlyList&lt;T&gt; 全体の中で最もインデックス番号の小さい要素を返します
		/// </summary>
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

		/// <summary>
		/// 指定された述語によって定義された条件と一致するすべての要素を取得します
		/// </summary>
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

		/// <summary>
		/// IReadOnlyList&lt;T&gt; またはその一部分から、
		/// 指定した述語によって定義される条件に一致する要素を検索し、
		/// 最もインデックス番号の小さい要素の 0 から始まるインデックスを返します。
		/// このメソッドは、条件に一致する項目が見つからなかった場合に -1 を返します
		/// </summary>
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

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を、
		/// IReadOnlyList&lt;T&gt; 全体を対象に検索し、
		/// 最もインデックス番号の大きい要素を返します
		/// </summary>
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

		/// <summary>
		/// IReadOnlyList&lt;T&gt; またはその一部分から、
		/// 指定した述語によって定義される条件に一致する要素を検索し、
		/// 最もインデックス番号の大きい要素の 0 から始まるインデックスを返します
		/// </summary>
		public static int FindLastIndex<T>( this IReadOnlyList<T> self, Predicate<T> match )
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

		/// <summary>
		/// IReadOnlyList&lt;T&gt; 全体またはその一部において、
		/// 最初に値が出現した位置のインデックス番号 (0 から始まる) を返します
		/// </summary>
		public static int IndexOf<T>( this IReadOnlyList<T> self, T item )
		{
			for ( var i = 0; i < self.Count; i++ )
			{
				if ( self[ i ].Equals( item ) )
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// IReadOnlyList&lt;T&gt; 全体またはその一部において、
		/// 最後に値が出現した位置のインデックス番号 (0 から始まる) を返します
		/// </summary>
		public static int LastIndexOf<T>( this IReadOnlyList<T> self, T item )
		{
			for ( var i = self.Count - 1; i >= 0; i-- )
			{
				if ( self[ i ].Equals( item ) )
				{
					return i;
				}
			}

			return -1;
		}
	}
}