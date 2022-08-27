using System;
using System.Collections.Generic;
using System.Linq;

namespace Kogane
{
    /// <remarks>
    /// IEnumerable 型の拡張メソッド
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
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.First( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近い値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int Nearest<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.First( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearest
        //================================================================================
        /// <summary>
        /// 目的の値に最も近い値を持つ要素を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static TSource FindNearest<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.First( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近い値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestOrDefault
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.FirstOrDefault( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近い値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近い値を持つ要素を返します。見つからなかった場合は null を返します
        /// </summary>
        public static TSource FindNearestOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestMoreThan
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int NearestMoreThan
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.Where( x => target < x ).ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.First( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int NearestMoreThan<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => target < selector( x ) ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.First( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestMoreThan
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static TSource FindNearestMoreThan<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => target < selector( x ) ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.First( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestMoreThanOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestMoreThanOrDefault
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.Where( x => target < x ).ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.FirstOrDefault( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestMoreThanOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => target < selector( x ) ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestMoreThanOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します。見つからなかった場合は null を返します
        /// </summary>
        public static TSource FindNearestMoreThanOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => target < selector( x ) ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestOrLess
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int NearestOrLess
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.Where( x => x <= target ).ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.First( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int NearestOrLess<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => selector( x ) <= target ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.First( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestOrLess
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static TSource FindNearestOrLess<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => selector( x ) <= target ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.First( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestOrLessOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestOrLessOrDefault
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.Where( x => x <= target ).ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.FirstOrDefault( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestOrLessOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => selector( x ) <= target ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestOrLessOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static TSource FindNearestOrLessOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => selector( x ) <= target ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestOrMore
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int NearestOrMore
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.Where( x => target <= x ).ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.First( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int NearestOrMore<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => target <= selector( x ) ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.First( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestOrMore
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static TSource FindNearestOrMore<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => target <= selector( x ) ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.First( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestOrMoreOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestOrMoreOrDefault
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.Where( x => target <= x ).ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.FirstOrDefault( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestOrMoreOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => target <= selector( x ) ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestOrMoreOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static TSource FindNearestOrMoreOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => target <= selector( x ) ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestMoreLess
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int NearestMoreLess
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.Where( x => x < target ).ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.First( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static int NearestMoreLess<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => selector( x ) < target ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.First( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestMoreLess
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します。見つからなかった場合は例外を投げます
        /// </summary>
        public static TSource FindNearestMoreLess<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => selector( x ) < target ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.First( x => Math.Abs( selector( x ) - target ) == min );
        }

        //================================================================================
        // NearestMoreLessOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestMoreLessOrDefault
        (
            this IEnumerable<int> self,
            int                   target
        )
        {
            var list = self.Where( x => x < target ).ToArray();
            var min  = list.Min( x => Math.Abs( x - target ) );
            return list.FirstOrDefault( x => Math.Abs( x - target ) == min );
        }

        /// <summary>
        /// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は null を返します
        /// </summary>
        public static int NearestMoreLessOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => selector( x ) < target ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return selector( list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min ) );
        }

        //================================================================================
        // FindNearestMoreLessOrDefault
        //================================================================================
        /// <summary>
        /// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します。見つからなかった場合は null を返します
        /// </summary>
        public static TSource FindNearestMoreLessOrDefault<TSource>
        (
            this IEnumerable<TSource> self,
            int                       target,
            Func<TSource, int>        selector
        )
        {
            var list = self.Where( x => selector( x ) < target ).ToArray();
            var min  = list.Min( x => Math.Abs( selector( x ) - target ) );
            return list.FirstOrDefault( x => Math.Abs( selector( x ) - target ) == min );
        }
    }
}