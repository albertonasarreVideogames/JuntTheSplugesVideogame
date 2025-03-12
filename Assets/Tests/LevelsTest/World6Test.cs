using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace LevelTests
{
    public class World6Test
    {

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level1()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(14);
            movementsManager.AddMovementUp(11);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementRight(23);


            yield return TestUtilities.RunTest("World6Level1", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(90000)]
        public IEnumerator Level2()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(2);

            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(2);

            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(22);


            yield return TestUtilities.RunTest("World6Level2", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level3()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(7);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMChangePlayer(1);

            // aqui se enseña como cambiar la posicion relativa del player negro respecto a los otros es util
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementLeft(20);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(10);
            movementsManager.AddMovementRight(2);



            yield return TestUtilities.RunTest("World6Level3", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level4()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(12);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(10);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(18);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(12);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(19);
            movementsManager.AddMovementUp(11);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(16);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementLeft(5);

            yield return TestUtilities.RunTest("World6Level4", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level5()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(21);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(21);
            movementsManager.AddMovementUp(11);
            movementsManager.AddMovementLeft(23);

            yield return TestUtilities.RunTest("World6Level5", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level6()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(7);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(7);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(12);


            yield return TestUtilities.RunTest("World6Level6", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level7()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(7);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(8);

            yield return TestUtilities.RunTest("World6Level7", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level8()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(6);

            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementRight(5);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(10);
            movementsManager.AddMovementLeft(8);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementLeft(9);




            yield return TestUtilities.RunTest("World6Level8", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level9()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);//
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementRight(1);//

            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementLeft(3);

            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(4);

            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(19);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementUp(9);
            movementsManager.AddMovementRight(13);

            yield return TestUtilities.RunTest("World6Level9", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level10()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(4);

            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(2);

            movementsManager.AddMovementUp(6);


            yield return TestUtilities.RunTest("World6Level10", movementsManager, GameState.Victory, 10.0f);
        }
    }
}
