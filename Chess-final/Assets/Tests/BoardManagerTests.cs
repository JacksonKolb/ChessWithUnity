using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

namespace Tests
{
    public class BoardManagerTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void StartShouldSpawnAllPieces()
        {
            BoardManager boardManager = new BoardManager();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator BoardManagerTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
