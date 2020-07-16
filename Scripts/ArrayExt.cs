using System;

namespace Kogane
{
	/// <remarks>
	/// 配列の拡張メソッド
	/// このスクリプトでは配列でよく使う独自の拡張メソッドを定義
	/// </remarks>
	public static partial class EnumerableExtensionMethods
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// ランダムに並び替えます
		/// </summary>
		public static T[] Shuffle<T>( this T[] array )
		{
			int n = array.Length;
			while ( 1 < n )
			{
				n--;
				int k   = Random.Next( n + 1 );
				var tmp = array[ k ];
				array[ k ] = array[ n ];
				array[ n ] = tmp;
			}

			return array;
		}
	}
}