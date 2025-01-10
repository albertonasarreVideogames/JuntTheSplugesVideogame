using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class AllColorsTest
    {
        [UnityTest]
        public IEnumerator PinchosdownShouldNotKill()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementDown(5);

            yield return TestUtilities.RunTest("AllcolorsScenarytest1", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator PinchosdownShouldNotKillAfterPressSwitch()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(5);

            yield return TestUtilities.RunTest("AllcolorsScenarytest1", movementsManager, GameState.Gaming, 10.0f);
        }

        [UnityTest]
        public IEnumerator BlocsdownShouldNotStop()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(5);

            yield return TestUtilities.RunTest("AllcolorsScenarytest1", movementsManager, GameState.Lose);
        }

        [UnityTest]
        public IEnumerator BlocsdownAfterpulseShouldNStop()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(5);

            yield return TestUtilities.RunTest("AllcolorsScenarytest1", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator visualTestKeepSwitch()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(5);

            yield return TestUtilities.RunTest("AllcolorsScenarytest1", movementsManager, GameState.Gaming, 5.0f);
        }

        [UnityTest]
        public IEnumerator BlocsShouldElevatePlayer()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementDown(5);

            yield return TestUtilities.RunTest("AllcolorsScenarytest1", movementsManager, GameState.Gaming, 10.0f);
        }

        [UnityTest]
        public IEnumerator BlocsShouldDoWnPlayer()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementDown(1);


            yield return TestUtilities.RunTest("AllcolorsScenarytest1", movementsManager, GameState.Lose);
        }
    }
}
