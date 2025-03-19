using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace LevelTests
{
    public class World8Test
    {
        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level1()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(11);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(8);

            movementsManager.AddMovementRight(7);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMovementLeft(22);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(11);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(11);

            yield return TestUtilities.RunTest("World8Level1", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level2()
        {
            MovementsManager movementsManager = new MovementsManager();
            //movementsManager.AddMovementDown(2);
            //movementsManager.AddMovementLeft(2);
            //movementsManager.AddMChangePlayer(1);
            //movementsManager.AddMovementUp(4);

            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(4);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);

            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(6);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1); //

            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(8);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementLeft(6);


            yield return TestUtilities.RunTest("World8Level2", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level3()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(8);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(1);

            movementsManager.AddMovementLeft(9);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(7);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(4);

            movementsManager.AddMovementLeft(12);
            movementsManager.AddMovementRight(11);
            movementsManager.AddMovementUp(2);


            yield return TestUtilities.RunTest("World8Level3", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level4()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementDown(4);
            movementsManager.AddMovementLeft(21);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(22);
            movementsManager.AddMovementUp(2);

            yield return TestUtilities.RunTest("World8Level4", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level5()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementUp(1);

            // mirar como el de la izquierda esta subido a los bloques aqui, se podria hacer un vibel de ter que construir un puente, o buscarse la vida para ir a l otro lado
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(6);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(3);

            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(4);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(7);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(11);
            movementsManager.AddMovementLeft(14);
            movementsManager.AddMovementRight(9);
            movementsManager.AddMovementUp(5);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(2);
            movementsManager.AddMovementLeft(19);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementRight(19);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(6);
            movementsManager.AddMovementUp(6);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(5);


            yield return TestUtilities.RunTest("World8Level5", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level6()
        {
            MovementsManager movementsManager = new MovementsManager();          
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(1);

            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementUp(1);

            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(2);

            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);

            movementsManager.AddMovementLeft(19);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementUp(11);


            yield return TestUtilities.RunTest("World8Level6", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level7()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(3);
            movementsManager.AddMovementRight(4);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(5);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(5);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementUp(5);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(6);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(8);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(5);
            movementsManager.AddMovementDown(4);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(5);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementRight(23);
            movementsManager.AddMovementUp(3);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(10);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(9);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(21);


            yield return TestUtilities.RunTest("World8Level7", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level8()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMovementUp(2);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementRight(3);
            movementsManager.AddMovementUp(3);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(7);
            movementsManager.AddMovementLeft(3);

            movementsManager.AddMovementUp(11);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementDown(8);
            movementsManager.AddMovementRight(22);


            yield return TestUtilities.RunTest("World8Level8", movementsManager, GameState.Victory, 10.0f);
        }

        [UnityTest]
        [Timeout(900000)]
        public IEnumerator Level9()
        {
            MovementsManager movementsManager = new MovementsManager();
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(10);
            movementsManager.AddMovementLeft(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementUp(1);
            movementsManager.AddMovementDown(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(2);
            movementsManager.AddMovementLeft(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(4);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementDown(1);
            movementsManager.AddMovementLeft(4);
            movementsManager.AddMovementUp(1);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMovementLeft(6);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementLeft(14);
            movementsManager.AddMovementUp(4);
            movementsManager.AddMovementLeft(2);

            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementLeft(2);
            movementsManager.AddMChangePlayer(1);
            movementsManager.AddMovementRight(1);
            movementsManager.AddMovementUp(11);
            movementsManager.AddMovementLeft(3);
            movementsManager.AddMovementDown(6);


            yield return TestUtilities.RunTest("World8Level9", movementsManager, GameState.Victory, 10.0f);
        }

    }
}


