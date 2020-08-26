using NUnit.Framework;
using System.Collections.Generic;

namespace Kogane.Test
{
	internal class IReadOnlyListExtTest
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

		private readonly IReadOnlyList<Character> m_characters = new []
		{
			new Character( 1, "フシギダネ" ),
			new Character( 1, "フシギソウ" ),
			new Character( 1, "フシギバナ" ),
		};

		[Test]
		public void TryFind()
		{
			var exists = m_characters.TryFind( x => x.Id == 1, out var result );
			Assert.True( exists );
			Assert.AreEqual( "フシギダネ", result.Name );
		}

		[Test]
		public void TryFindLast()
		{
			var exists = m_characters.TryFindLast( x => x.Id == 1, out var result );
			Assert.True( exists );
			Assert.AreEqual( "フシギバナ", result.Name );
		}
	}
}