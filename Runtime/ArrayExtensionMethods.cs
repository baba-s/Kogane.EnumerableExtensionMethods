using System;
using System.Linq;

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
        /// ランダムに並び替えます（非破壊的メソッド）
        /// </summary>
        public static T[] ShuffleSafe<T>( this T[] self )
        {
            return self.ToArray().Shuffle();
        }

        /// <summary>
        /// ランダムに並び替えます（破壊的メソッド）
        /// </summary>
        public static T[] Shuffle<T>( this T[] self )
        {
            var n = self.Length;
            while ( 1 < n )
            {
                n--;
                var k   = Random.Next( n + 1 );
                var tmp = self[ k ];
                self[ k ] = self[ n ];
                self[ n ] = tmp;
            }

            return self;
        }

        /// <summary>
        /// 指定された条件を満たす場合、ランダムに並び替えます（非破壊的メソッド）
        /// </summary>
        public static T[] ShuffleIfSafe<T>( this T[] self, bool condition )
        {
            return self.ToArray().ShuffleIf( condition );
        }

        /// <summary>
        /// 指定された条件を満たす場合、ランダムに並び替えます（破壊的メソッド）
        /// </summary>
        public static T[] ShuffleIf<T>( this T[] self, bool condition )
        {
            return !condition ? self : self.Shuffle();
        }

        /// <summary>
        /// 指定された条件を満たす場合、要素の順序を反転させます（非破壊的メソッド）
        /// </summary>
        public static T[] ReverseIfSafe<T>( this T[] self, bool condition )
        {
            return self.ToArray().ReverseIfSafe( condition );
        }

        /// <summary>
        /// 指定された条件を満たす場合、要素の順序を反転させます（破壊的メソッド）
        /// </summary>
        public static T[] ReverseIf<T>( this T[] self, bool condition )
        {
            if ( !condition ) return self;
            Array.Reverse( self );
            return self;
        }
    }
}