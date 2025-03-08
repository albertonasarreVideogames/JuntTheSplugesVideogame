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
    }
}
