using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemiesAndBlocsTest
    {
        [UnityTest]
        public IEnumerator EnemiesShouldGoupOnBlocs()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(15);

            yield return TestUtilities.RunTest("EnemiesAndBlocsScenary1", movementsManager, GameState.Gaming);
        }

        [UnityTest]
        public IEnumerator EnemiesShouldNotColideUpsideBlocs()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(20);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(1);

            yield return TestUtilities.RunTest("EnemiesAndBlocsScenary1", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator EnemiesShoulSeparateInTheSamePlaceProperlyUpBlocs()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);

            yield return TestUtilities.RunTest("EnemiesAndBlocsScenary2", movementsManager, GameState.Gaming, 10.0f);
        }

        [UnityTest]
        public IEnumerator EnemiesShoulSeparateInTheSamePlaceProperlyUpBlocsWithKeepSwitch()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);

            yield return TestUtilities.RunTest("EnemiesAndBlocsScenary3", movementsManager, GameState.Gaming, 10.0f);
        }

        [UnityTest]
        public IEnumerator EnemiesShoulSeparateInTheSamePlacebUTLEAVEoNEdOWNProperlyUpBlocs()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementUp(2);

            yield return TestUtilities.RunTest("EnemiesAndBlocsScenary4", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator EnemiesShoulSeparateInTheSamePlacebUTLEAVEoNEdOWNProperlyUpBlocsWithKeepSwitch()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementUp(2);

            yield return TestUtilities.RunTest("EnemiesAndBlocsScenary5", movementsManager, GameState.Lose, 10.0f);
        }

        [UnityTest]
        public IEnumerator EnemiesShouldKeepUpAfterSepareWithsameplaecolide()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(10);
            movementsManager.AddMovementUp(3);

            yield return TestUtilities.RunTest("EnemiesAndBlocsScenary6", movementsManager, GameState.Victory, 10.0f);
        }
    }
}

