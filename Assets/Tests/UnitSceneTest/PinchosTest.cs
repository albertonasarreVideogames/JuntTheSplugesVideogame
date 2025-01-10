using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PinchosTest
    {
        [UnityTest]
        public IEnumerator BeforePulseSwitchPinchosShouldKill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);

            yield return TestUtilities.RunTest("PinchosTestScenary1", movementsManager, GameState.Lose);
        }

        [UnityTest]
        public IEnumerator AfterpresPulseSwitchPinchosShouldNotKill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(4);

            yield return TestUtilities.RunTest("PinchosTestScenary1", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator AfterpresPulseSwitchPinchosShoulKill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementLeft(2);

            yield return TestUtilities.RunTest("PinchosTestScenary1", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator AfterKeepPulseSwitchPinchosShouldNotKill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(2);

            yield return TestUtilities.RunTest("PinchosTestScenary2", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator AfterLeaveKeepSwitchPinchosShoulKill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(3);

            yield return TestUtilities.RunTest("PinchosTestScenary2", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator AfterLeaveKeepSwitchPinchosShoulNotKillWithLongWalk()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(8);

            yield return TestUtilities.RunTest("PinchosTestScenary3", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator AfterLeaveKeepSwitchPinchosShoulKillWithLongWalk()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementLeft(1);

            yield return TestUtilities.RunTest("PinchosTestScenary3", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator DownPinchosSouldNotkill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(3);

            yield return TestUtilities.RunTest("PinchosTestScenary3", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator DownPinchosAfterChangeAndManteinSouldNotkill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(10);

            yield return TestUtilities.RunTest("PinchosTestScenary3", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator DownPinchosAfterChangeAndManteinAndNotManteinAgainSouldkill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(11);

            yield return TestUtilities.RunTest("PinchosTestScenary3", movementsManager, GameState.Lose, 10.0f);
        }
    }
}
