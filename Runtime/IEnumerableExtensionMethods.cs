using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Kogane
{
    /// <remarks>
    /// IEnumerable 型の拡張メソッド
    /// このスクリプトでは IEnumerable 型でよく使う独自の拡張メソッドを定義
    /// </remarks>
    public static partial class EnumerableExtensionMethods
    {
        //================================================================================
        // 変数(static readonly)
        //================================================================================
        private static Random m_randomCache;

        //================================================================================
        // プロパティ(static)
        //================================================================================
        private static Random Random => m_randomCache ??= new();

        //================================================================================
        // ElementAtRandom
        //================================================================================
        /// <summary>
        /// シーケンス内の要素をランダムに返します
        /// </summary>
        public static T ElementAtRandom<T>( this IEnumerable<T> self )
        {
            return self.Any()
                    ? self.ElementAt( Random.Next( self.Count() ) )
                    : default
                ;
        }

        //================================================================================
        // ForEach
        //================================================================================
        /// <summary>
        /// シーケンスの各要素に対して指定された処理を実行します
        /// </summary>
        public static void ForEach<T>( this IEnumerable<T> self, Action<T> action )
        {
            foreach ( var n in self )
            {
                action( n );
            }
        }

        /// <summary>
        /// シーケンスの各要素に対して指定された処理を実行します
        /// </summary>
        public static void ForEach<T>( this IEnumerable<T> self, Action<T, int> action )
        {
            var index = 0;
            foreach ( var n in self )
            {
                action( n, index++ );
            }
        }

        /// <summary>
        /// シーケンスの各要素に対して指定された処理を逆順に実行します
        /// </summary>
        public static void ForEachReverse<T>( this IEnumerable<T> self, Action<T> action )
        {
            foreach ( var n in self.Reverse() )
            {
                action( n );
            }
        }

        /// <summary>
        /// シーケンスの各要素に対して指定された処理を逆順に実行します
        /// </summary>
        public static void ForEachReverse<T>( this IEnumerable<T> self, Action<T, int> action )
        {
            var index = self.Count() - 1;
            foreach ( var n in self.Reverse() )
            {
                action( n, index-- );
            }
        }

        //================================================================================
        // IsEmpty
        //================================================================================
        /// <summary>
        /// シーケンスが空の場合 true を返します
        /// </summary>
        public static bool IsEmpty<TSource>( this IEnumerable<TSource> self )
        {
            return !self.Any();
        }

        /// <summary>
        /// シーケンスが空ではない場合 true を返します
        /// </summary>
        public static bool IsNotEmpty<TSource>( this IEnumerable<TSource> self )
        {
            return !self.IsEmpty();
        }

        /// <summary>
        /// シーケンスが null または空の場合 true を返します
        /// </summary>
        public static bool IsNullOrEmpty<T>( this IEnumerable<T> self )
        {
            return self == null || !self.Any();
        }

        /// <summary>
        /// シーケンスが null でも空でもない場合 true を返します
        /// </summary>
        public static bool IsNotNullOrEmpty<T>( this IEnumerable<T> self )
        {
            return !self.IsNullOrEmpty();
        }

        //================================================================================
        // Pager
        //================================================================================
        /// <summary>
        /// 指定されたページに存在する要素を返します
        /// </summary>
        public static IEnumerable<T> Pager<T>
        (
            this IEnumerable<T> self,
            int                 pageIndex,
            int                 pageCount
        )
        {
            return self.Skip( pageIndex * pageCount ).Take( pageCount );
        }

        //================================================================================
        // NotNull
        //================================================================================
        /// <summary>
        /// シーケンスの null ではない要素を返します
        /// </summary>
        public static IEnumerable<TSource> NotNull<TSource>( this IEnumerable<TSource> self )
        {
            return self.Where( x => x != null );
        }

        //================================================================================
        // WithIndex
        //================================================================================
        /// <summary>
        /// シーケンスの要素をインデックス付きで返します
        /// </summary>
        public static IEnumerable<(int index, T value)> WithIndex<T>( this IEnumerable<T> self )
        {
            IEnumerable<(int index, T value)> Impl()
            {
                var i = 0;
                foreach ( var value in self )
                {
                    yield return ( i, value );
                    i++;
                }
            }

            return Impl();
        }

        //================================================================================
        // Flatten
        //================================================================================
        /// <summary>
        /// シーケンスを平坦化して返します
        /// </summary>
        public static IEnumerable<T> Flatten<T>( this IEnumerable<IEnumerable<T>> self )
        {
            return self.SelectMany( x => x );
        }

        //================================================================================
        // CompareSelector
        //================================================================================
        /// <summary>
        /// 指定した要素がシーケンスに格納されているかどうかを調べます
        /// </summary>
        public static bool Contains<T, TKey>
        (
            this IEnumerable<T> self,
            T                   value,
            Func<T, TKey>       selector
        )
        {
            return self.Contains( value, new CompareSelector<T, TKey>( selector ) );
        }

        /// <summary>
        /// シーケンスから一意の要素を返します
        /// </summary>
        public static IEnumerable<T> Distinct<T, TKey>( this IEnumerable<T> self, Func<T, TKey> selector )
        {
            return self.Distinct( new CompareSelector<T, TKey>( selector ) );
        }

        /// <summary>
        /// 2 つのシーケンスの差集合を生成します
        /// </summary>
        public static IEnumerable<T> Except<T, TKey>
        (
            this IEnumerable<T> self,
            IEnumerable<T>      second,
            Func<T, TKey>       selector
        )
        {
            return self.Except( second, new CompareSelector<T, TKey>( selector ) );
        }

        /// <summary>
        /// 2 つのシーケンスの積集合を生成します
        /// </summary>
        public static IEnumerable<T> Intersect<T, TKey>
        (
            this IEnumerable<T> source,
            IEnumerable<T>      second,
            Func<T, TKey>       selector
        )
        {
            return source.Intersect( second, new CompareSelector<T, TKey>( selector ) );
        }

        /// <summary>
        /// 等値比較子に従って 2 つのシーケンスが等しいかどうかを判断します
        /// </summary>
        public static bool SequenceEqual<T, TKey>
        (
            this IEnumerable<T> self,
            IEnumerable<T>      second,
            Func<T, TKey>       selector
        )
        {
            return self.SequenceEqual( second, new CompareSelector<T, TKey>( selector ) );
        }

        /// <summary>
        /// 2 つのシーケンスの和集合を生成します
        /// </summary>
        public static IEnumerable<T> Union<T, TKey>
        (
            this IEnumerable<T> source,
            IEnumerable<T>      second,
            Func<T, TKey>       selector
        )
        {
            return source.Union( second, new CompareSelector<T, TKey>( selector ) );
        }

        //================================================================================
        // MaxBy, MinBy
        //================================================================================
        /// <summary>
        /// シーケンスから最大値を持つ要素を返します
        /// </summary>
        public static TSource MaxBy<TSource, TResult>( this IEnumerable<TSource> self, Func<TSource, TResult> selector )
        {
            var value = self.Max( selector );
            return self.FirstOrDefault( x => selector( x ).Equals( value ) );
        }

        /// <summary>
        /// シーケンスから最小値を持つ要素を返します
        /// </summary>
        public static TSource MinBy<TSource, TResult>( this IEnumerable<TSource> self, Func<TSource, TResult> selector )
        {
            var value = self.Min( selector );
            return self.FirstOrDefault( x => selector( x ).Equals( value ) );
        }

        //================================================================================
        // Concat
        //================================================================================
        /// <summary>
        /// 2 つのシーケンスを連結します
        /// </summary>
        public static IEnumerable<TSource> Concat<TSource>( this IEnumerable<TSource> self, TSource second )
        {
            return self.Concat( new[] { second } );
        }

        //================================================================================
        // RandomAtWeight
        //================================================================================
        /// <summary>
        /// シーケンスの要素の中から確率抽選します
        /// </summary>
        public static T RandomAtWeight<T>( this IEnumerable<T> self, Func<T, int> selector )
        {
            var current = 0;
            var rate    = Random.Next( 0, self.Sum( selector ) );

            var result = self.FirstOrDefault
            (
                x =>
                {
                    current += selector( x );
                    return rate < current;
                }
            );

            return result;
        }

        //================================================================================
        // Chunks
        //================================================================================
        /// <summary>
        /// シーケンスを指定された要素数で分割して返します
        /// </summary>
        public static IEnumerable<IEnumerable<TSource>> Chunks<TSource>( this IEnumerable<TSource> self, int size )
        {
            while ( self.Any() )
            {
                yield return self.Take( size );
                self = self.Skip( size );
            }
        }

        //================================================================================
        // ReverseIf
        //================================================================================
        /// <summary>
        /// 指定された条件を満たす場合にシーケンスの要素の順序を反転させます
        /// </summary>
        public static IEnumerable<T> ReverseIf<T>( this IEnumerable<T> self, bool condition )
        {
            return condition ? self.Reverse() : self;
        }

        //================================================================================
        // Peek
        //================================================================================
        public static IEnumerable<T> Peek<T>
        (
            [NotNull] this IEnumerable<T> source,
            [NotNull]      Action<T>      action
        )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );
            if ( action == null ) throw new ArgumentNullException( nameof( action ) );

            IEnumerable<T> Iterator()
            {
                foreach ( var x in source )
                {
                    action( x );
                    yield return x;
                }
            }

            return Iterator();
        }

        public static IEnumerable<T> PeekMany<T>
        (
            [NotNull] this IEnumerable<T>         source,
            [NotNull]      Action<IEnumerable<T>> action
        )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );
            if ( action == null ) throw new ArgumentNullException( nameof( action ) );

            IEnumerable<T> Iterator()
            {
                action( source );

                foreach ( var x in source )
                {
                    yield return x;
                }
            }

            return Iterator();
        }

        //================================================================================
        // TryElementAt
        //================================================================================
        public static bool TryElementAt<TSource>
        (
            this IEnumerable<TSource> source,
            int                       index,
            out TSource               result
        )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );

            var i = 0;
            foreach ( var element in source )
            {
                if ( i == index )
                {
                    result = element;
                    return true;
                }

                i++;
            }

            result = default;
            return false;
        }

        //================================================================================
        // WithIsLast
        //================================================================================
        public static IEnumerable<(T value, bool isLast)> WithIsLast<T>( this IEnumerable<T> source )
        {
            if ( source == null ) throw new ArgumentNullException( nameof( source ) );

            IEnumerable<(T value, bool isLast)> Iterator()
            {
                var array = source.ToArray();
                var count = array.Length;

                for ( var i = 0; i < array.Length; i++ )
                {
                    yield return ( array[ i ], i + 1 == count );
                }
            }

            return Iterator();
        }

        //================================================================================
        // AppendIf
        //================================================================================
        public static IEnumerable<T> AppendIf<T>( this IEnumerable<T> self, bool conditional, T element )
        {
            return conditional ? self.Append( element ) : self;
        }
    }
}