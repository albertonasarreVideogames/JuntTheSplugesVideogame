using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace LevelTests
{
    public class World5Test
    {

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level1()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementRight(11);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementLeft(22);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(10);
            movementsManager.AddMovementLeft(20);

            yield return TestUtilities.RunTest("World5Level1", movementsManager, GameState.Victory, 10.0f);
        }
        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level2()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(5);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(6); 
            movementsManager.AddMovementUp(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementUp(9);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(9);
            movementsManager.AddMovementLeft(1);

            yield return TestUtilities.RunTest("World5Level2", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level3()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(6);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(10);
            movementsManager.AddMovementRight(3);

            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(3);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(7);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(7);

            movementsManager.AddMovementUp(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(10);
            movementsManager.AddMovementRight(2);

            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(7);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(5);

            movementsManager.AddMovementDown(10);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementDown(2);

            yield return TestUtilities.RunTest("World5Level3", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level4()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(2);

            movementsManager.AddMovementRight(8);
            
            movementsManager.AddMovementLeft(16);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementLeft(1);

            yield return TestUtilities.RunTest("World5Level4", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(1500000)]
        public IEnumerator Level5()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);

            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(7);


            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(8);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(13);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(3);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);

            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(14);
            movementsManager.AddMovementUp(7);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(11);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(25);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementDown(5);

            yield return TestUtilities.RunTest("World5Level5", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(1500000)]
        public IEnumerator Level6()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(10);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(7);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(7);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);



            yield return TestUtilities.RunTest("World5Level6", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(1500000)]
        public IEnumerator Level7()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(1);

            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(4);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(4);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(3);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(10);
            movementsManager.AddMovementLeft(9);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(11);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(12);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(13);  ///////////// WHAT HAPEND I NEED ONE MORE MOVEMNT . mAYBE THERE ARE TWO SPLUNGES TOGHUTHER?
            movementsManager.AddMovementDown(4);  ///////////// WHAT HAPEND
            movementsManager.AddMovementLeft(12);  ///////////// WHAT HAPEND

            yield return TestUtilities.RunTest("World5Level7", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level8()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementUp(4);

            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementDown(7);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementUp(12);
            movementsManager.AddMovementRight(20);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(20);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(20);

            yield return TestUtilities.RunTest("World5Level8", movementsManager, GameState.Victory, 10.0f);
        }
        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level9()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementRight(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(15);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(3);

            movementsManager.AddMovementLeft(9);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(20);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(9);

            yield return TestUtilities.RunTest("World5Level9", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level10()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(17);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(23);
            movementsManager.AddMovementUp(9);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(14);
            movementsManager.AddMovementUp(11);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);

            yield return TestUtilities.RunTest("World5Level10", movementsManager, GameState.Victory, 10.0f);
        }
    }
    }
