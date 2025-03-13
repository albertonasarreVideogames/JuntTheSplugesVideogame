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

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level2()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(6);

            yield return TestUtilities.RunTest("World7Level2", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level3()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(2);

            yield return TestUtilities.RunTest("World7Level3", movementsManager, GameState.Victory, 10.0f);
        }

    }
}
