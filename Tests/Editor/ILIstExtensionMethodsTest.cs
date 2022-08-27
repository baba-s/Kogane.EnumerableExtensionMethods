using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Kogane.Test
{
    internal sealed class IListExtensionMethodsTest
    {
        private readonly IReadOnlyList<int>  m_source     = new[] { 0, 1, 2, 3, 4, };
        private readonly IReadOnlyList<uint> m_sourceUint = new uint[] { 0, 1, 2, 3, 4, };

        [Test]
        public void ElementAt()
        {
            Assert.AreEqual( 2, m_source.ElementAt( 2 ) );
        }

        [Test]
        public void ElementAtOrDefault()
        {
            Assert.AreEqual( 2, m_source.ElementAtOrDefault( 2 ) );
            Assert.AreEqual( 0, m_source.ElementAtOrDefault( 5 ) );
            Assert.AreEqual( 5, m_source.ElementAtOrDefault( 5, 5 ) );
        }

        [Test]
        public void First()
        {
            Assert.AreEqual( 0, m_source.First() );
            Assert.AreEqual( 2, m_source.First( x => x == 2 ) );
        }

        [Test]
        public void FirstOrDefault()
        {
            Assert.AreEqual( 0, m_source.FirstOrDefault() );
            Assert.AreEqual( 5, new int[ 0 ].FirstOrDefault( 5 ) );
            Assert.AreEqual( 2, m_source.FirstOrDefault( x => x == 2 ) );
            Assert.AreEqual( 0, m_source.FirstOrDefault( x => x == 5 ) );
            Assert.AreEqual( 5, m_source.FirstOrDefault( x => x == 5, 5 ) );
        }

        [Test]
        public void Last()
        {
            Assert.AreEqual( 4, m_source.Last() );
            Assert.AreEqual( 2, m_source.Last( x => x == 2 ) );
        }

        [Test]
        public void LastOrDefault()
        {
            Assert.AreEqual( 4, m_source.LastOrDefault() );
            Assert.AreEqual( 5, new int[ 0 ].LastOrDefault( 5 ) );
            Assert.AreEqual( 2, m_source.LastOrDefault( x => x == 2 ) );
            Assert.AreEqual( 0, m_source.LastOrDefault( x => x == 5 ) );
            Assert.AreEqual( 5, m_source.LastOrDefault( x => x == 5, 5 ) );
        }

        [Test]
        public void Where()
        {
            var result1 = m_source.Where( x => x == 2 );
            Assert.IsTrue( result1.SequenceEqual( new[] { 2 } ) );
            var result2 = m_source.Where( ( x, index ) => x == 2 && index == 2 );
            Assert.IsTrue( result2.SequenceEqual( new[] { 2 } ) );
        }

        [Test]
        public void Skip()
        {
            var result1 = m_source.Skip( 2 );
            Assert.IsTrue( result1.SequenceEqual( new[] { 2, 3, 4 } ) );
        }

        [Test]
        public void SkipWhile()
        {
            var result1 = m_source.SkipWhile( x => x == 2 );
            Assert.IsTrue( result1.SequenceEqual( new[] { 0, 1, 2, 3, 4 } ) );
            var result2 = m_source.SkipWhile( x => x <= 2 );
            Assert.IsTrue( result2.SequenceEqual( new[] { 3, 4 } ) );
            var result3 = m_source.SkipWhile( ( x, index ) => x <= 2 && index <= 2 );
            Assert.IsTrue( result3.SequenceEqual( new[] { 3, 4 } ) );
        }

        [Test]
        public void Take()
        {
            var result1 = m_source.Take( 2 );
            Assert.IsTrue( result1.SequenceEqual( new[] { 0, 1 } ) );
        }

        [Test]
        public void TakeWhile()
        {
            var result1 = m_source.TakeWhile( x => x == 2 );
            Assert.IsTrue( result1.SequenceEqual( new int[] { } ) );
            var result2 = m_source.TakeWhile( x => x <= 2 );
            Assert.IsTrue( result2.SequenceEqual( new[] { 0, 1, 2 } ) );
            var result3 = m_source.TakeWhile( ( x, index ) => x <= 2 && index <= 2 );
            Assert.IsTrue( result3.SequenceEqual( new[] { 0, 1, 2 } ) );
        }

        [Test]
        public void Max()
        {
            Assert.AreEqual( 4, m_source.Max() );
            Assert.AreEqual( 4, m_source.Max( x => x ) );
            Assert.AreEqual( 4, m_sourceUint.Max() );
            Assert.AreEqual( 4, m_sourceUint.Max( x => x ) );
        }

        [Test]
        public void Min()
        {
            Assert.AreEqual( 0, m_source.Min() );
            Assert.AreEqual( 0, m_source.Min( x => x ) );
            Assert.AreEqual( 0, m_sourceUint.Min() );
            Assert.AreEqual( 0, m_sourceUint.Min( x => x ) );
        }

        [Test]
        public void Average()
        {
            Assert.AreEqual( 2, m_source.Average() );
            Assert.AreEqual( 2, m_source.Average( x => x ) );
            Assert.AreEqual( 2, m_sourceUint.Average() );
            Assert.AreEqual( 2, m_sourceUint.Average( x => x ) );
        }

        [Test]
        public void Sum()
        {
            Assert.AreEqual( 10, m_source.Sum() );
            Assert.AreEqual( 10, m_source.Sum( x => x ) );
            Assert.AreEqual( 10, m_sourceUint.Sum() );
            Assert.AreEqual( 10, m_sourceUint.Sum( x => x ) );
        }

        [Test]
        public void Count()
        {
            Assert.AreEqual( 5, m_source.Count() );
            Assert.AreEqual( 1, m_source.Count( x => x == 2 ) );
        }

        [Test]
        public void All()
        {
            Assert.IsTrue( m_source.All( x => 0 <= x ) );
            Assert.IsFalse( m_source.All( x => 1 <= x ) );

            var empty = new int[ 0 ];
            Assert.IsTrue( empty.All( x => 0 <= x ) );
        }

        [Test]
        public void Any()
        {
            Assert.IsTrue( m_source.Any() );
            Assert.IsTrue( m_source.Any( x => x == 2 ) );
            Assert.IsFalse( m_source.Any( x => x == 5 ) );

            var empty = new int[ 0 ];
            Assert.IsFalse( empty.Any() );
        }

        [Test]
        public void Contains()
        {
            Assert.IsTrue( m_source.Contains( 2 ) );
            Assert.IsFalse( m_source.Contains( 5 ) );
        }

        [Test]
        public void SequenceEqual()
        {
            Assert.IsTrue( m_source.SequenceEqual( new[] { 0, 1, 2, 3, 4 } ) );
            Assert.IsFalse( m_source.SequenceEqual( new[] { 0, 1, 2, 3 } ) );
            Assert.IsFalse( m_source.SequenceEqual( new[] { 0, 1, 2, 3, 4, 5 } ) );
        }

        [Test]
        public void Reverse()
        {
            var result1 = m_source.Reverse();
            Assert.IsTrue( result1.SequenceEqual( new[] { 4, 3, 2, 1, 0 } ) );
        }

        [Test]
        public void Select()
        {
            var result1 = m_source.Select( x => x * 2 );
            Assert.IsTrue( result1.SequenceEqual( new[] { 0, 2, 4, 6, 8 } ) );
            var result2 = m_source.Select( ( x, index ) => x + index );
            Assert.IsTrue( result2.SequenceEqual( new[] { 0, 2, 4, 6, 8 } ) );
        }

        private sealed class SelectManyData
        {
            public int[] Source { get; } = { 0, 1, 2 };
        }

        [Test]
        public void SelectMany()
        {
            var source = new[]
            {
                new SelectManyData(),
                new SelectManyData(),
            };

            var result1 = source.SelectMany( x => x.Source );
            Assert.IsTrue( result1.SequenceEqual( new[] { 0, 1, 2, 0, 1, 2 } ) );
            var result2 = source.SelectMany( ( x, index ) => x.Source );
            Assert.IsTrue( result1.SequenceEqual( new[] { 0, 1, 2, 0, 1, 2 } ) );
        }

        [Test]
        public void Concat()
        {
            var result1 = m_source.Concat( m_source );
            Assert.IsTrue( result1.SequenceEqual( new[] { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 } ) );
        }

        [Test]
        public void DefaultIfEmpty()
        {
            var result1 = m_source.DefaultIfEmpty();
            Assert.IsTrue( result1.SequenceEqual( new[] { 0, 1, 2, 3, 4 } ) );
            var result2 = new int[ 0 ].DefaultIfEmpty();
            Assert.IsTrue( result2.SequenceEqual( new[] { 0 } ) );
            var result3 = new int[ 0 ].DefaultIfEmpty( 5 );
            Assert.IsTrue( result3.SequenceEqual( new[] { 5 } ) );
        }

        [Test]
        public void Prepend()
        {
            var result1 = m_source.Prepend( -1 );
            Assert.IsTrue( result1.SequenceEqual( new[] { -1, 0, 1, 2, 3, 4 } ) );
        }

        [Test]
        public void Append()
        {
            var result1 = m_source.Append( 5 );
            Assert.IsTrue( result1.SequenceEqual( new[] { 0, 1, 2, 3, 4, 5 } ) );
        }
    }
}