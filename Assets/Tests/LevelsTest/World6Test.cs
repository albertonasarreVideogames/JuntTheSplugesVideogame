using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace LevelTests
{
    public class World6Test
    {

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level1()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(14);
            movementsManager.AddMovementUp(11);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementRight(23);


            yield return TestUtilities.RunTest("World6Level1", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level2()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(2);

            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(2);

            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(22);


            yield return TestUtilities.RunTest("World6Level2", movementsManager, GameState.Victory, 10.0f);
        }
    }
}
