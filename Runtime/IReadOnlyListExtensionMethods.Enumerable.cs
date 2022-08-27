using System;
using System.Collections.Generic;

namespace Kogane
{
    /// <remarks>
    /// IReadOnlyList 型の拡張メソッド
    /// このスクリプトでは LINQ の同名の拡張メソッドを定義することで GC Alloc を削減することが目的
    /// </remarks>
    public static partial class EnumerableExtensionMethods
    {
        //================================================================================
        // ElementAt
        //================================================================================
        /// <summary>
        /// シーケンス内の指定されたインデックス位置にある要素を返します
        /// </summary>
        public static TSource ElementAt<TSource>
        (
            this IReadOnlyList<TSource> source,
            int                         index
        )
        {
            return source[ index ];
        }

        //================================================================================
        // ElementAtOrDefault
        //================================================================================
        /// <summary>
        /// シーケンス内の指定したインデックス位置にある要素を返します。
        /// インデックスが範囲外の場合は既定値を返します
        /// </summary>
        public static TSource ElementAtOrDefault<TSource>
        (
            this IReadOnlyList<TSource> source,
            int                         index
        )
        {
            return source.ElementAtOrDefault( index, default );
        }

        /// <summary>
        /// シーケンス内の指定したインデックス位置にある要素を返します。
        /// インデックスが範囲外の場合は既定値を返します
        /// </summary>
        public static TSource ElementAtOrDefault<TSource>
        (
            this IReadOnlyList<TSource> source,
            int                         index,
            TSource                     defaultValue
        )
        {
            return 0 <= index && index < source.Count ? source[ index ] : defaultValue;
        }

        //================================================================================
        // First
        //================================================================================
        /// <summary>
        /// シーケンスの最初の要素を返します
        /// </summary>
        public static TSource First<TSource>( this IReadOnlyList<TSource> source )
        {
            return source[ 0 ];
        }

        /// <summary>
        /// 指定された条件を満たす、シーケンスの最初の要素を返します
        /// </summary>
        public static TSource First<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( predicate( source[ i ] ) )
                {
                    return source[ i ];
                }
            }

            throw new InvalidOperationException();
        }

        //================================================================================
        // FirstOrDefault
        //================================================================================
        /// <summary>
        /// シーケンスの最初の要素を返します。要素が見つからない場合は既定値を返します
        /// </summary>
        public static TSource FirstOrDefault<TSource>( this IReadOnlyList<TSource> source )
        {
            return source.FirstOrDefault( defaultValue: default );
        }

        /// <summary>
        /// シーケンスの最初の要素を返します。要素が見つからない場合は既定値を返します
        /// </summary>
        public static TSource FirstOrDefault<TSource>
        (
            this IReadOnlyList<TSource> source,
            TSource                     defaultValue
        )
        {
            return 0 < source.Count ? source[ 0 ] : defaultValue;
        }

        /// <summary>
        /// 条件を満たす、シーケンスの最初の要素を返します。
        /// このような要素が見つからない場合は既定値を返します
        /// </summary>
        public static TSource FirstOrDefault<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            return source.FirstOrDefault( predicate: predicate, defaultValue: default );
        }

        /// <summary>
        /// 条件を満たす、シーケンスの最初の要素を返します。
        /// このような要素が見つからない場合は既定値を返します
        /// </summary>
        public static TSource FirstOrDefault<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate,
            TSource                     defaultValue
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( predicate( source[ i ] ) )
                {
                    return source[ i ];
                }
            }

            return defaultValue;
        }

        //================================================================================
        // Last
        //================================================================================
        /// <summary>
        /// シーケンスの最後の要素を返します
        /// </summary>
        public static TSource Last<TSource>( this IReadOnlyList<TSource> source )
        {
            return source[ source.Count - 1 ];
        }

        /// <summary>
        /// 指定された条件を満たす、シーケンスの最後の要素を返します
        /// </summary>
        public static TSource Last<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            for ( var i = source.Count - 1; i >= 0; i-- )
            {
                if ( predicate( source[ i ] ) )
                {
                    return source[ i ];
                }
            }

            throw new InvalidOperationException();
        }

        //================================================================================
        // LastOrDefault
        //================================================================================
        /// <summary>
        /// シーケンスの最後の要素を返します。要素が見つからない場合は既定値を返します
        /// </summary>
        public static TSource LastOrDefault<TSource>( this IReadOnlyList<TSource> source )
        {
            return source.LastOrDefault( defaultValue: default );
        }

        /// <summary>
        /// シーケンスの最後の要素を返します。要素が見つからない場合は既定値を返します
        /// </summary>
        public static TSource LastOrDefault<TSource>
        (
            this IReadOnlyList<TSource> source,
            TSource                     defaultValue
        )
        {
            return 0 < source.Count ? source[ source.Count - 1 ] : defaultValue;
        }

        /// <summary>
        /// 条件を満たす、シーケンスの最後の要素を返します。
        /// このような要素が見つからない場合は既定値を返します
        /// </summary>
        public static TSource LastOrDefault<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            return source.LastOrDefault( predicate: predicate, defaultValue: default );
        }

        /// <summary>
        /// 条件を満たす、シーケンスの最後の要素を返します。
        /// このような要素が見つからない場合は既定値を返します
        /// </summary>
        public static TSource LastOrDefault<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate,
            TSource                     defaultValue
        )
        {
            for ( var i = source.Count - 1; i >= 0; i-- )
            {
                if ( predicate( source[ i ] ) )
                {
                    return source[ i ];
                }
            }

            return defaultValue;
        }

        //================================================================================
        // Where
        //================================================================================
        /// <summary>
        /// 述語に基づいて値のシーケンスをフィルター処理します
        /// </summary>
        public static IEnumerable<TSource> Where<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, int, bool>    predicate
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( predicate( source[ i ], i ) )
                {
                    yield return source[ i ];
                }
            }
        }

        /// <summary>
        /// 述語に基づいて値のシーケンスをフィルター処理します
        /// </summary>
        public static IEnumerable<TSource> Where<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( predicate( source[ i ] ) )
                {
                    yield return source[ i ];
                }
            }
        }

        //================================================================================
        // Skip
        //================================================================================
        /// <summary>
        /// シーケンス内の指定された数の要素をバイパスし、残りの要素を返します
        /// </summary>
        public static IEnumerable<TSource> Skip<TSource>
        (
            this IReadOnlyList<TSource> source,
            int                         count
        )
        {
            for ( var i = count; i < source.Count; i++ )
            {
                yield return source[ i ];
            }
        }

        //================================================================================
        // SkipWhile
        //================================================================================
        /// <summary>
        /// 指定された条件が満たされる限り、シーケンスの要素をバイパスした後、残りの要素を返します
        /// </summary>
        public static IEnumerable<TSource> SkipWhile<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            var i = 0;

            for ( ; i < source.Count; i++ )
            {
                if ( !predicate( source[ i ] ) )
                {
                    break;
                }
            }

            for ( ; i < source.Count; i++ )
            {
                yield return source[ i ];
            }
        }

        /// <summary>
        /// 指定された条件が満たされる限り、シーケンスの要素をバイパスした後、残りの要素を返します
        /// </summary>
        public static IEnumerable<TSource> SkipWhile<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, int, bool>    predicate
        )
        {
            var i = 0;

            for ( ; i < source.Count; i++ )
            {
                if ( !predicate( source[ i ], i ) )
                {
                    break;
                }
            }

            for ( ; i < source.Count; i++ )
            {
                yield return source[ i ];
            }
        }

        //================================================================================
        // Take
        //================================================================================
        /// <summary>
        /// シーケンスの先頭から、指定された数の連続する要素を返します
        /// </summary>
        public static IEnumerable<TSource> Take<TSource>
        (
            this IReadOnlyList<TSource> source,
            int                         count
        )
        {
            for ( var i = 0; i < count; i++ )
            {
                yield return source[ i ];
            }
        }

        //================================================================================
        // TakeWhile
        //================================================================================
        /// <summary>
        /// 指定された条件を満たされる限り、シーケンスから要素を返した後、残りの要素をスキップします
        /// </summary>
        public static IEnumerable<TSource> TakeWhile<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( predicate( source[ i ] ) )
                {
                    yield return source[ i ];
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 指定された条件を満たされる限り、シーケンスから要素を返した後、残りの要素をスキップします
        /// </summary>
        public static IEnumerable<TSource> TakeWhile<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, int, bool>    predicate
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( predicate( source[ i ], i ) )
                {
                    yield return source[ i ];
                }
                else
                {
                    break;
                }
            }
        }

        //================================================================================
        // Max
        //================================================================================
        /// <summary>
        /// 値のシーケンスの最大値を返します
        /// </summary>
        public static int Max<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, int>          selector
        )
        {
            var result = int.MinValue;

            for ( var i = 0; i < source.Count; i++ )
            {
                var value = selector( source[ i ] );

                if ( result < value )
                {
                    result = value;
                }
            }

            return result;
        }

        /// <summary>
        /// 値のシーケンスの最大値を返します
        /// </summary>
        public static int Max( this IReadOnlyList<int> source )
        {
            var result = int.MinValue;

            for ( var i = 0; i < source.Count; i++ )
            {
                if ( result < source[ i ] )
                {
                    result = source[ i ];
                }
            }

            return result;
        }

        /// <summary>
        /// 値のシーケンスの最大値を返します
        /// </summary>
        public static uint Max<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, uint>         selector
        )
        {
            var result = uint.MinValue;

            for ( var i = 0; i < source.Count; i++ )
            {
                var value = selector( source[ i ] );

                if ( result < value )
                {
                    result = value;
                }
            }

            return result;
        }

        /// <summary>
        /// 値のシーケンスの最大値を返します
        /// </summary>
        public static uint Max( this IReadOnlyList<uint> source )
        {
            var result = uint.MinValue;

            for ( var i = 0; i < source.Count; i++ )
            {
                if ( result < source[ i ] )
                {
                    result = source[ i ];
                }
            }

            return result;
        }

        //================================================================================
        // Min
        //================================================================================
        /// <summary>
        /// 値のシーケンスの最小値を返します
        /// </summary>
        public static int Min<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, int>          selector
        )
        {
            var result = int.MaxValue;

            for ( var i = 0; i < source.Count; i++ )
            {
                var value = selector( source[ i ] );

                if ( value < result )
                {
                    result = value;
                }
            }

            return result;
        }

        /// <summary>
        /// 値のシーケンスの最小値を返します
        /// </summary>
        public static int Min( this IReadOnlyList<int> source )
        {
            var result = int.MaxValue;

            for ( var i = 0; i < source.Count; i++ )
            {
                if ( source[ i ] < result )
                {
                    result = source[ i ];
                }
            }

            return result;
        }

        /// <summary>
        /// 値のシーケンスの最小値を返します
        /// </summary>
        public static uint Min<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, uint>         selector
        )
        {
            var result = uint.MaxValue;

            for ( var i = 0; i < source.Count; i++ )
            {
                var value = selector( source[ i ] );

                if ( value < result )
                {
                    result = value;
                }
            }

            return result;
        }

        /// <summary>
        /// 値のシーケンスの最小値を返します
        /// </summary>
        public static uint Min( this IReadOnlyList<uint> source )
        {
            var result = uint.MaxValue;

            for ( var i = 0; i < source.Count; i++ )
            {
                if ( source[ i ] < result )
                {
                    result = source[ i ];
                }
            }

            return result;
        }

        //================================================================================
        // Average
        //================================================================================
        /// <summary>
        /// 数値のシーケンスの平均を計算します
        /// </summary>
        public static int Average<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, int>          selector
        )
        {
            var result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                result += selector( source[ i ] );
            }

            return result / source.Count;
        }

        /// <summary>
        /// 数値のシーケンスの平均を計算します
        /// </summary>
        public static int Average( this IReadOnlyList<int> source )
        {
            var result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                result += source[ i ];
            }

            return result / source.Count;
        }

        /// <summary>
        /// 数値のシーケンスの平均を計算します
        /// </summary>
        public static uint Average<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, uint>         selector
        )
        {
            uint result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                result += selector( source[ i ] );
            }

            return result / ( uint )source.Count;
        }

        /// <summary>
        /// 数値のシーケンスの平均を計算します
        /// </summary>
        public static uint Average( this IReadOnlyList<uint> source )
        {
            uint result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                result += source[ i ];
            }

            return result / ( uint )source.Count;
        }

        //================================================================================
        // Sum
        //================================================================================
        /// <summary>
        /// 数値のシーケンスの合計を計算します
        /// </summary>
        public static int Sum<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, int>          selector
        )
        {
            var result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                result += selector( source[ i ] );
            }

            return result;
        }

        /// <summary>
        /// 数値のシーケンスの合計を計算します
        /// </summary>
        public static int Sum( this IReadOnlyList<int> source )
        {
            var result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                result += source[ i ];
            }

            return result;
        }

        /// <summary>
        /// 数値のシーケンスの合計を計算します
        /// </summary>
        public static uint Sum<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, uint>         selector
        )
        {
            uint result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                result += selector( source[ i ] );
            }

            return result;
        }

        /// <summary>
        /// 数値のシーケンスの合計を計算します
        /// </summary>
        public static uint Sum( this IReadOnlyList<uint> source )
        {
            uint result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                result += source[ i ];
            }

            return result;
        }

        //================================================================================
        // Count
        //===============================================================================
        /// <summary>
        /// シーケンス内の要素数を返します
        /// </summary>
        public static int Count<TSource>( this IReadOnlyList<TSource> source )
        {
            return source.Count;
        }

        /// <summary>
        /// 条件を満たす、指定されたシーケンス内の要素の数を表す数値を返します
        /// </summary>
        public static int Count<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            var result = 0;

            for ( var i = 0; i < source.Count; i++ )
            {
                if ( predicate( source[ i ] ) )
                {
                    result++;
                }
            }

            return result;
        }

        //================================================================================
        // All
        //================================================================================
        /// <summary>
        /// シーケンスのすべての要素が条件を満たしているかどうかを判断します
        /// </summary>
        public static bool All<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( !predicate( source[ i ] ) )
                {
                    return false;
                }
            }

            return true;
        }

        //================================================================================
        // Any
        //================================================================================
        /// <summary>
        /// シーケンスに要素が含まれているかどうかを判断します
        /// </summary>
        public static bool Any<TSource>( this IReadOnlyList<TSource> source )
        {
            return 0 < source.Count;
        }

        /// <summary>
        /// シーケンスの任意の要素が条件を満たしているかどうかを判断します
        /// </summary>
        public static bool Any<TSource>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, bool>         predicate
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( predicate( source[ i ] ) )
                {
                    return true;
                }
            }

            return false;
        }

        //================================================================================
        // Contains
        //================================================================================
        /// <summary>
        /// 指定した要素がシーケンスに格納されているかどうかを調べます
        /// </summary>
        public static bool Contains<TSource>
        (
            this IReadOnlyList<TSource> source,
            TSource                     value
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( source[ i ].Equals( value ) )
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 指定した要素がシーケンスに格納されているかどうかを調べます
        /// </summary>
        public static bool Contains<TSource>
        (
            this IReadOnlyList<TSource> source,
            TSource                     value,
            IEqualityComparer<TSource>  comparer
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                if ( comparer.Equals( source[ i ], value ) )
                {
                    return true;
                }
            }

            return false;
        }

        //================================================================================
        // SequenceEqual
        //================================================================================
        /// <summary>
        /// 等値比較子に従って 2 つのシーケンスが等しいかどうかを判断します
        /// </summary>
        public static bool SequenceEqual<TSource>
        (
            this IReadOnlyList<TSource> first,
            IReadOnlyList<TSource>      second,
            IEqualityComparer<TSource>  comparer
        )
        {
            if ( first.Count != second.Count )
            {
                return false;
            }

            for ( var i = 0; i < first.Count; i++ )
            {
                if ( !comparer.Equals( first[ i ], second[ i ] ) )
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 等値比較子に従って 2 つのシーケンスが等しいかどうかを判断します
        /// </summary>
        public static bool SequenceEqual<TSource>
        (
            this IReadOnlyList<TSource> first,
            IReadOnlyList<TSource>      second
        )
        {
            if ( first.Count != second.Count )
            {
                return false;
            }

            for ( var i = 0; i < first.Count; i++ )
            {
                if ( !first[ i ].Equals( second[ i ] ) )
                {
                    return false;
                }
            }

            return true;
        }

        //================================================================================
        // Reverse
        //================================================================================
        /// <summary>
        /// シーケンスの要素の順序を反転させます
        /// </summary>
        public static IEnumerable<TSource> Reverse<TSource>( this IReadOnlyList<TSource> source )
        {
            for ( var i = source.Count - 1; i >= 0; i-- )
            {
                yield return source[ i ];
            }
        }

        //================================================================================
        // Select
        //================================================================================
        /// <summary>
        /// シーケンスの各要素を新しいフォームに射影します
        /// </summary>
        public static IEnumerable<TResult> Select<TSource, TResult>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, TResult>      selector
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                yield return selector( source[ i ] );
            }
        }

        /// <summary>
        /// シーケンスの各要素を新しいフォームに射影します
        /// </summary>
        public static IEnumerable<TResult> Select<TSource, TResult>
        (
            this IReadOnlyList<TSource> source,
            Func<TSource, int, TResult> selector
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                yield return selector( source[ i ], i );
            }
        }

        //================================================================================
        // SelectMany
        //================================================================================
        /// <summary>
        /// シーケンスの各要素を IEnumerable&lt;TResult&gt; に射影し、
        /// 結果のシーケンスを 1 つのシーケンスに平坦化します
        /// </summary>
        public static IEnumerable<TResult> SelectMany<TSource, TResult>
        (
            this IReadOnlyList<TSource>         source,
            Func<TSource, IEnumerable<TResult>> selector
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                foreach ( var result in selector( source[ i ] ) )
                {
                    yield return result;
                }
            }
        }

        /// <summary>
        /// シーケンスの各要素を IEnumerable&lt;TResult&gt; に射影し、
        /// 結果のシーケンスを 1 つのシーケンスに平坦化します
        /// </summary>
        public static IEnumerable<TResult> SelectMany<TSource, TResult>
        (
            this IReadOnlyList<TSource>              source,
            Func<TSource, int, IEnumerable<TResult>> selector
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                foreach ( var result in selector( source[ i ], i ) )
                {
                    yield return result;
                }
            }
        }

        //================================================================================
        // Concat
        //================================================================================
        /// <summary>
        /// 2 つのシーケンスを連結します
        /// </summary>
        public static IEnumerable<TSource> Concat<TSource>
        (
            this IReadOnlyList<TSource> first,
            IReadOnlyList<TSource>      second
        )
        {
            for ( var i = 0; i < first.Count; i++ )
            {
                yield return first[ i ];
            }

            for ( var i = 0; i < second.Count; i++ )
            {
                yield return second[ i ];
            }
        }

        //================================================================================
        // DefaultIfEmpty
        //================================================================================
        /// <summary>
        /// IEnumerable&lt;TSource&gt; の要素を返します。
        /// シーケンスが空の場合は既定値を持つシングルトン コレクションを返します
        /// </summary>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>( this IReadOnlyList<TSource> source )
        {
            return source.DefaultIfEmpty( default );
        }

        /// <summary>
        /// IEnumerable&lt;TSource&gt; の要素を返します。
        /// シーケンスが空の場合は既定値を持つシングルトン コレクションを返します
        /// </summary>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>
        (
            this IReadOnlyList<TSource> source,
            TSource                     defaultValue
        )
        {
            if ( source.Count <= 0 )
            {
                yield return defaultValue;
                yield break;
            }

            for ( var i = 0; i < source.Count; i++ )
            {
                yield return source[ i ];
            }
        }

        //================================================================================
        // Prepend
        //================================================================================
        /// <summary>
        /// シーケンスの先頭に値を追加します
        /// </summary>
        public static IEnumerable<TSource> Prepend<TSource>
        (
            this IReadOnlyList<TSource> source,
            TSource                     element
        )
        {
            yield return element;

            for ( var i = 0; i < source.Count; i++ )
            {
                yield return source[ i ];
            }
        }

        //================================================================================
        // Append
        //================================================================================
        /// <summary>
        /// シーケンスの末尾に値を追加します
        /// </summary>
        public static IEnumerable<TSource> Append<TSource>
        (
            this IReadOnlyList<TSource> source,
            TSource                     element
        )
        {
            for ( var i = 0; i < source.Count; i++ )
            {
                yield return source[ i ];
            }

            yield return element;
        }
    }
}