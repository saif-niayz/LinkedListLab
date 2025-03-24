using Xunit;

namespace LinkedListLab.Tests
{
    public class LinkedListTests
    {
        string[] names = new string[]
        {
            "Joe Blow",
            "Joe Schmoe",
            "John Smith",
            "Jane Doe",
            "Bob Bobberson",
            "Sam Sammerson",
            "Dave Daverson"
        };

        [Fact]
        public void AddAllNames_AddLast_WorksCorrectly()
        {
            var list = new LinkedList();

            foreach (var name in names)
                list.AddLast(name);

            Assert.Equal(7, list.Count);
            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.GetValue(i));
        }

        [Fact]
        public void AddAllNames_AddFirst_WorksCorrectly()
        {
            var list = new LinkedList();

            foreach (var name in names)
                list.AddFirst(name);

            Assert.Equal(7, list.Count);
            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[names.Length - 1 - i], list.GetValue(i));
        }

        [Fact]
        public void RemoveFirst_RemovesCorrectNode()
        {
            var list = new LinkedList();
            foreach (var name in names)
                list.AddLast(name);

            list.RemoveFirst(); // Removes "Joe Blow"

            Assert.Equal(6, list.Count);
            Assert.Equal("Joe Schmoe", list.GetValue(0));
        }

        [Fact]
        public void RemoveLast_RemovesCorrectNode()
        {
            var list = new LinkedList();
            foreach (var name in names)
                list.AddLast(name);

            list.RemoveLast(); // Removes "Dave Daverson"

            Assert.Equal(6, list.Count);
            Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(6));
        }

        [Fact]
        public void GetValue_ReturnsCorrectValue()
        {
            var list = new LinkedList();
            foreach (var name in names)
                list.AddLast(name);

            Assert.Equal("Jane Doe", list.GetValue(3));
        }

        [Fact]
        public void GetValue_InvalidIndex_ThrowsException()
        {
            var list = new LinkedList();
            Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(0));
        }

        [Fact]
        public void RemoveFromEmptyList_DoesNotCrash()
        {
            var list = new LinkedList();
            list.RemoveFirst();
            list.RemoveLast();

            Assert.Null(list.Head);
            Assert.Equal(0, list.Count);
        }
    }
}
