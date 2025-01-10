using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class EnemiesTest 
    {
       
        [UnityTest]
        public IEnumerator EnemyShouldKillPlayerTouch()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(2);

            yield return TestUtilities.RunTest("EnemiesTestScenary1", movementsManager, GameState.Lose);
        }
        [UnityTest]
        public IEnumerator EnemyShoudKillPlayerThrougt()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(3);

            yield return TestUtilities.RunTest("EnemiesTestScenary1", movementsManager, GameState.Lose);
        }

        [UnityTest]
        public IEnumerator EnemiesColisionShouldKeepToguether()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(2);

            yield return TestUtilities.RunTest("EnemiesTestScenary2", movementsManager, GameState.Lose);
        }

        [UnityTest]
        public IEnumerator EnemiesColisionSamePlaceShouldSeparate()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(3);

            yield return TestUtilities.RunTest("EnemiesTestScenary3", movementsManager, GameState.Gaming, 10.0f);
        }

        [UnityTest]
        public IEnumerator AfterEnemisionCollisionSamePlaceAndPlayerContactShouldLose()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(1);

            yield return TestUtilities.RunTest("EnemiesTestScenary4", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator MoveAlotofenemies()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(10);
            movementsManager.AddMovementDown(10);
            movementsManager.AddMovementLeft(10);
            movementsManager.AddMovementRight(11);
            movementsManager.AddMovementDown(1);

            yield return TestUtilities.RunTest("EnemiesTestScenary5", movementsManager, GameState.Lose);
        }
    }
}
