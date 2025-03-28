using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace LevelTests
{
    public class World4Test
    {
        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level1()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementLeft(1); 
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(6);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(9);


            yield return TestUtilities.RunTest("World4Level1", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level2()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(12);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(20);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(4);

            yield return TestUtilities.RunTest("World4Level2", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level3()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(4);

            movementsManager.AddMovementRight(10);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementUp(4);

            yield return TestUtilities.RunTest("World4Level3", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level4()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(9);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(14);
            movementsManager.AddMovementLeft(15);

            yield return TestUtilities.RunTest("World4Level4", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(150000)]
        public IEnumerator Level5()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(6);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(1);

            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(20);
            movementsManager.AddMovementUp(12);

            yield return TestUtilities.RunTest("World4Level5", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(150000)]
        public IEnumerator Level8()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(14);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(10);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(20);

            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(10);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(7);

            yield return TestUtilities.RunTest("World4Level8", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(120000)]
        public IEnumerator Level7()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(18);
            movementsManager.AddMovementUp(14);

            yield return TestUtilities.RunTest("World4Level7", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(120000)]
        public IEnumerator Level6()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(12);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementRight(23);
            movementsManager.AddMovementDown(13);

            yield return TestUtilities.RunTest("World4Level6", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(120000)]
        public IEnumerator Level9()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementRight(10);
            movementsManager.AddMovementUp(2);


            yield return TestUtilities.RunTest("World4Level9", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(280000)]
        public IEnumerator Level10()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(5);

            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(20);

            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementLeft(4);

            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementUp(3);

            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(15);


            yield return TestUtilities.RunTest("World4Level10", movementsManager, GameState.Victory, 10.0f);
        }


    }
}
