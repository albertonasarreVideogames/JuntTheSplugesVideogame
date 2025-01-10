using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BasicPlayerFeaturesTest
    {

        [UnityTest]
        public IEnumerator PlayerToguetherShouldWin()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(5);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary1", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator ThreeDiferentPlayersTogutherShoulWin()
        {

            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(5);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(9);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(13);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary2", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator PlayerOneInLavaShouldLose()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(2);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary3", movementsManager, GameState.Lose);
        }

        [UnityTest]
        public IEnumerator PlayerTwoInLavaShouldLose()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(2);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary3", movementsManager, GameState.Lose);
        }

        [UnityTest]
        public IEnumerator PlayerThreeInLavaShouldLose()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(2);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary3", movementsManager, GameState.Lose);
        }

        [UnityTest]
        public IEnumerator MainPlayerShouldNotDie()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(3);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary4", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator MainPlayerShouldNotDieMovingPlayerTwo()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(3);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary4", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator MainPlayerShoultDie()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(1);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary4", movementsManager, GameState.Lose);
        }

        [UnityTest]
        public IEnumerator MainPlayerShoultDieItself()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(4);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);

            yield return TestUtilities.RunTest("BasicPlayerFeaturesTestScenary5", movementsManager, GameState.Lose, 5.0f);
        }
    }
}
