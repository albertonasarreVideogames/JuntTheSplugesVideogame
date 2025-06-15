using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections;


public static class TestUtilities
{
    private static bool persistenobjectinicializated = false;
    public static IEnumerator RunTest(string sceneName, MovementsManager movementsManager, GameState expectedState,float timeBetweenmovementsMultiplicator = 2f)
    {
        bool manualTestActivated = true;


        if (!persistenobjectinicializated) {
            yield return SceneManager.LoadSceneAsync("init Menu", LoadSceneMode.Single);
            persistenobjectinicializated = true;
            yield return new WaitForSeconds(0.1f * timeBetweenmovementsMultiplicator);
            
        }

        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        GameManager.Instance.UpdateGameState(GameState.Gaming);
        yield return new WaitForSeconds(0.1f * timeBetweenmovementsMultiplicator);

        // Realizar las acciones específicas del test
        for (int i = 0; i < movementsManager.buttonspressed.Count; i++)
        {
            if (GamingState.Instance != null)
            {
                yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.T) && GamingState.Instance.getIfPlayersStopMoving()) || (!manualTestActivated && GamingState.Instance.getIfPlayersStopMoving()));


                movementsManager.executeComand(i);
                //Debug.Log("Me muevo");
                yield return new WaitUntil(() => !Input.GetKey(KeyCode.T));
            }
            else
            {
                Debug.Log("No GamingState");
            }
        }

        // Esperar un poco más para asegurarse de que ha acabado
        yield return new WaitForSeconds(1f);

        // Verificar el estado final
        Assert.AreEqual(GameManager.Instance.State, expectedState);
        GameManager.Instance.UpdateGameState(GameState.Gaming);
    }
}