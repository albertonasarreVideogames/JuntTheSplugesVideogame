using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace LevelTests
{
    public class World2Test
    {
        [UnityTest]
        public IEnumerator Level1()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(14);

            yield return TestUtilities.RunTest("World2Level1", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level2()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(7);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(19);

            yield return TestUtilities.RunTest("World2Level2", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level3()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(10);
            movementsManager.AddMovementLeft(1);

            yield return TestUtilities.RunTest("World2Level3", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level4()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(10);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(10);
            movementsManager.AddMovementLeft(2);

            yield return TestUtilities.RunTest("World2Level4", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        [Timeout(60000)]
        public IEnumerator Level5()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(10);

            movementsManager.AddMovementUp(6);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(2);

            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(6);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(2);

            yield return TestUtilities.RunTest("World2Level5", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level6()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(14);
            movementsManager.AddMovementDown(4);

            yield return TestUtilities.RunTest("World2Level6", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        public IEnumerator Level7()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(4);

            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementDown(10);


            yield return TestUtilities.RunTest("World2Level7", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        [Timeout(60000)]
        public IEnumerator Level8()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(4);

            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(5);

            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(12);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(3);

            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(10);


            yield return TestUtilities.RunTest("World2Level8", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        [Timeout(60000)]
        public IEnumerator Level9()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(10);

            movementsManager.AddMovementDown(7);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(3);


            yield return TestUtilities.RunTest("World2Level9", movementsManager, GameState.Victory, 5.0f);
        }

        [UnityTest]
        [Timeout(60000)]
        public IEnumerator Level10()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);

            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(9);

            movementsManager.AddMovementDown(7);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(16);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(10);




            yield return TestUtilities.RunTest("World2Level10", movementsManager, GameState.Victory, 5.0f);
        }
    }
}
