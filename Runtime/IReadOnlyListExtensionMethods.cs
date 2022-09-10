using System;
using System.Collections.Generic;
using System.Linq;

namespace Kogane
{
    /// <remarks>
    /// IReadOnlyList 型の拡張メソッド
    /// このスクリプトではIReadOnlyList 型でよく使う独自の拡張メソッドを定義
    /// </remarks>
    public static partial class EnumerableExtensionMethods
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

        //================================================================================
        // FindMin, FindMax
        //================================================================================
        /// <summary>
        /// int 値の最小値を持つ要素を返します
        /// </summary>
        public static T FindMin<T>( this IReadOnlyList<T> self, Func<T, int> selector )
        {
            return self.Find( x => selector( x ) == self.Min( selector ) );
        }

        /// <summary>
        /// uint 値の最小値を持つ要素を返します
        /// </summary>
        public static T FindMin<T>( this IReadOnlyList<T> self, Func<T, uint> selector )
        {
            return self.Find( x => selector( x ) == self.Min( selector ) );
        }

        /// <summary>
        /// int 値の最大値を持つ要素を返します
        /// </summary>
        public static T FindMax<T>( this IReadOnlyList<T> self, Func<T, int> selector )
        {
            return self.Find( x => selector( x ) == self.Max( selector ) );
        }

        /// <summary>
        /// uint 値の最大値を持つ要素を返します
        /// </summary>
        public static T FindMax<T>( this IReadOnlyList<T> self, Func<T, uint> selector )
        {
            return self.Find( x => selector( x ) == self.Max( selector ) );
        }

        //================================================================================
        // TryFind, TryFindLast
        //================================================================================
        /// <summary>
        /// 指定された述語によって定義された条件と一致する要素を検索し、
        /// List&lt;T&gt; 全体の中で最もインデックス番号の小さい要素を返します
        /// </summary>
        public static bool TryFind<T>
        (
            this IReadOnlyList<T> self,
            Predicate<T>          match,
            out T                 result
        ) where T : class
        {
            result = null;

            for ( var i = 0; i < self.Count; i++ )
            {
                var item = self[ i ];
                if ( match( item ) )
                {
                    result = item;
                    break;
                }
            }

            return result != null;
        }

        /// <summary>
        /// 指定された述語によって定義された条件と一致する要素を、
        /// List&lt;T&gt; 全体を対象に検索し、最もインデックス番号の大きい要素を返します
        /// </summary>
        public static bool TryFindLast<T>
        (
            this IReadOnlyList<T> self,
            Predicate<T>          match,
            out T                 result
        ) where T : class
        {
            result = null;

            for ( var i = self.Count - 1; i >= 0; i-- )
            {
                var item = self[ i ];
                if ( match( item ) )
                {
                    result = item;
                    break;
                }
            }

            return result != null;
        }
    }
}