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
            movementsManager.AddMovementRight(1);

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


            yield return TestUtilities.RunTest("World8Level2", movementsManager, GameState.Victory, 10.0f);
        }

    }
}


