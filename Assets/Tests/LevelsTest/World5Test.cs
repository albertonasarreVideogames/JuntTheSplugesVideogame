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
    }
    }
