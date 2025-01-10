using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace LevelTests
{
    public class World1Test
    {
        [UnityTest]
        public IEnumerator Level1()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(12);
            movementsManager.AddMovementUp(5);

            yield return TestUtilities.RunTest("World1Level1", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level2()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(12);
            movementsManager.AddMovementUp(10);
            movementsManager.AddMovementLeft(5);

            yield return TestUtilities.RunTest("World1Level2", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level3()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(15);

            yield return TestUtilities.RunTest("World1Level3", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level4()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(6);
            movementsManager.AddMovementRight(14);

            yield return TestUtilities.RunTest("World1Level4", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level5()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(5);

            yield return TestUtilities.RunTest("World1Level5", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level6()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementDown(9);
            movementsManager.AddMovementUp(9);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(14);
            movementsManager.AddMovementDown(2);

            yield return TestUtilities.RunTest("World1Level6", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level7()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementUp(5);

            yield return TestUtilities.RunTest("World1Level7", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level8()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementUp(9);

            yield return TestUtilities.RunTest("World1Level8", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level9()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(14);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementUp(9);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(2);


            yield return TestUtilities.RunTest("World1Level9", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level10()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(10);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(3);


            yield return TestUtilities.RunTest("World1Level10", movementsManager, GameState.Victory, 5.0f);
        }
    }
}
