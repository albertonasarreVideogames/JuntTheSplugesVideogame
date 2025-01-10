using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BlocsTest
    {
        [UnityTest]
        public IEnumerator BlocsUpShouldBlocsPlayer()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(1);

            yield return TestUtilities.RunTest("BlocsTestScenary1", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        public IEnumerator BlocsDownShouldNotBlocsPlayer()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(1);

            yield return TestUtilities.RunTest("BlocsTestScenary1", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator PlayersShouldGoUpWithBlocs()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(4);

            yield return TestUtilities.RunTest("BlocsTestScenary1", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        public IEnumerator PlayerShouldNotGoUpAtTheMomentOnKeepSwitchIsPulsed()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(4);

            yield return TestUtilities.RunTest("BlocsTestScenary2", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        public IEnumerator PlayerShouldNotGoDOWNAtTheMomentOnKeepSwitchIsNotPulsed()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(6);

            yield return TestUtilities.RunTest("BlocsTestScenary2", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator PlayerShouldNotGoUpAtTheMomentOnKeepSwitchIsPulsedAgain()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);

            yield return TestUtilities.RunTest("BlocsTestScenary2", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator DownBlocShoudNotStopYouAndMoreSwitchsComportaments()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementLeft(15);

            yield return TestUtilities.RunTest("BlocsTestScenary3", movementsManager, GameState.Victory, 10.0f);
        }
    }
}
