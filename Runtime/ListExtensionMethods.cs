using System;
using System.Collections.Generic;

namespace Kogane
{
    /// <remarks>
    /// List 型の拡張メソッド
    /// このスクリプトでは List 型でよく使う独自の拡張メソッドを定義
    /// </remarks>
    public static partial class EnumerableExtensionMethods
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// 指定したコレクションの要素をリストの末尾に追加します
        /// </summary>
        public static void Add<T>( this List<T> self, IEnumerable<T> collection )
        {
            self.AddRange( collection );
        }

        /// <summary>
        /// match 関数で一致した最初の要素をリストから削除します
        /// </summary>
        public static bool Remove<T>( this List<T> self, Predicate<T> match )
        {
            var index = self.FindIndex( match );
            if ( index == -1 ) return false;
            self.RemoveAt( index );
            return true;
        }

        /// <summary>
        /// すべての要素を削除して、指定したコレクションの要素を追加します
        /// </summary>
        public static void Set<T>( this List<T> list, IEnumerable<T> collection )
        {
            list.Clear();
            list.AddRange( collection );
        }

        /// <summary>
        /// すべての要素を削除して、指定したコレクションの要素を追加します
        /// </summary>
        public static void Set<T>( this List<T> list, params T[] collection )
        {
            list.Clear();
            list.AddRange( collection );
        }

        /// <summary>
        /// 指定した Comparison&lt;T&gt; を使用して要素を並べ替えます
        /// </summary>
        public static void Sort<T>( this List<T> self, Comparison<T> comparison )
        {
            self.Sort( comparison );
        }

        /// <summary>
        /// 指定した Func&lt;TSource, TResult&gt; を使用して要素を並べ替えます
        /// </summary>
        public static void Sort<TSource, TResult>( this List<TSource> self, Func<TSource, TResult> selector ) where TResult : IComparable
        {
            self.Sort( ( x, y ) => selector( x ).CompareTo( selector( y ) ) );
        }

        /// <summary>
        /// 要素をランダムに並び替えます
        /// </summary>
        public static List<T> Shuffle<T>( this List<T> self )
        {
            var n = self.Count;
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
        /// 指定された条件を満たす場合、要素の順序を反転させます
        /// </summary>
        public static void ReverseIf<T>( this List<T> self, bool condition )
        {
            if ( !condition ) return;
            self.Reverse();
        }

        /// <summary>
        /// 指定された述語によって定義された条件と一致する要素を検索し、
        /// List&lt;T&gt; 全体の中で最もインデックス番号の小さい要素を返します
        /// </summary>
        public static bool TryFind<T>
        (
            this List<T> self,
            Predicate<T> match,
            out T        result
        ) where T : class
        {
            result = self.Find( match );
            return result != null;
        }

        /// <summary>
        /// 指定された述語によって定義された条件と一致する要素を、
        /// List&lt;T&gt; 全体を対象に検索し、最もインデックス番号の大きい要素を返します
        /// </summary>
        public static bool TryFindLast<T>
        (
            this List<T> self,
            Predicate<T> match,
            out T        result
        ) where T : class
        {
            result = self.FindLast( match );
            return result != null;
        }

        /// <summary>
        /// List&lt;T&gt; 内の要素をランダムに返して List&lt;T&gt; からは削除します
        /// </summary>
        public static T RemoveAtRandom<T>( this List<T> self )
        {
            var element = self.ElementAtRandom();
            self.Remove( element );
            return element;
        }
    }
}