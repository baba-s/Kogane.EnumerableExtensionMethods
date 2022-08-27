using System.Collections.Generic;

namespace Kogane
{
    /// <remarks>
    /// IList 型の拡張メソッド
    /// このスクリプトでは IList 型で Queue や Stack のような振る舞いを可能にする拡張メソッドを定義
    /// </remarks>
    public static partial class EnumerableExtensionMethods
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// 先頭にあるオブジェクトを削除せずに返します
        /// </summary>
        public static T Peek<T>( this IList<T> self )
        {
            return self[ 0 ];
        }

        /// <summary>
        /// Stack のように先頭にあるオブジェクトを削除し、返します
        /// </summary>
        public static T Pop<T>( this IList<T> self )
        {
            var result = self[ 0 ];
            self.RemoveAt( 0 );
            return result;
        }

        /// <summary>
        /// Stack のように末尾にオブジェクトを追加します
        /// </summary>
        public static void Push<T>( this IList<T> self, T item )
        {
            self.Insert( 0, item );
        }

        /// <summary>
        /// Queue のように先頭にあるオブジェクトを削除し、返します
        /// </summary>
        public static T Dequeue<T>( this IList<T> self )
        {
            var result = self[ 0 ];
            self.RemoveAt( 0 );
            return result;
        }

        /// <summary>
        /// Queue のように末尾にオブジェクトを追加します
        /// </summary>
        public static void Enqueue<T>( this IList<T> self, T item )
        {
            self.Add( item );
        }
    }
}