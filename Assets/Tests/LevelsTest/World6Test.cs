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
    }
}
