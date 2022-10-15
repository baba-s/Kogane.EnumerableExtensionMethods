using System.Collections.Generic;
using NUnit.Framework;

namespace Kogane.Test
{
    internal sealed class ListExtensionMethodsTest
    {
        private class Character
        {
            public int    Id   { get; }
            public string Name { get; }

            public Character( int id, string name )
            {
                Id   = id;
                Name = name;
            }
        }

        private readonly List<Character> m_characters = new()
        {
            new( 1, "フシギダネ" ),
            new( 1, "フシギソウ" ),
            new( 1, "フシギバナ" ),
        };

        [Test]
        public void TryFind()
        {
            var exists = m_characters.TryFind( x => x.Id == 1, out var result );
            Assert.IsTrue( exists );
            Assert.AreEqual( "フシギダネ", result.Name );

            var exists2 = m_characters.TryFind( x => x.Id == 2, out var result2 );
            Assert.IsFalse( exists2 );
            Assert.IsNull( result2 );
        }

        [Test]
        public void TryFindLast()
        {
            var exists = m_characters.TryFindLast( x => x.Id == 1, out var result );
            Assert.IsTrue( exists );
            Assert.AreEqual( "フシギバナ", result.Name );

            var exists2 = m_characters.TryFindLast( x => x.Id == 2, out var result2 );
            Assert.IsFalse( exists2 );
            Assert.IsNull( result2 );
        }
    }
}