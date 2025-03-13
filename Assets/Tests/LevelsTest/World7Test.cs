using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace LevelTests
{
    public class World7Test
    {

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level1()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(9);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);

            yield return TestUtilities.RunTest("World7Level1", movementsManager, GameState.Victory, 10.0f);
        }

    }
}
