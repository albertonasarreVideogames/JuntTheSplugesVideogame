using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections;


public static class TestUtilities
{
    public static IEnumerator RunTest(string sceneName, MovementsManager movementsManager, GameState expectedState,float timeBetweenmovementsMultiplicator = 2f)
    {
        
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        yield return new WaitForSeconds(0.1f * timeBetweenmovementsMultiplicator);

        // Realizar las acciones específicas del test
        for (int i = 0; i < movementsManager.buttonspressed.Count; i++)
        {
            if (GamingState.Instance != null)
            {
                //yield return new WaitForSeconds(0.1f*timeBetweenmovementsMultiplicator);
                while (!GamingState.Instance.getIfPlayersStopMoving())
                {
                    // Aquí se puede agregar un pequeño retraso para evitar que la corutina consuma demasiados recursos
                    yield return null; // Espera hasta el siguiente frame
                }
                movementsManager.executeComand(i);
                //Debug.Log("Me muevo");
            }
            else
            {
                Debug.Log("No GamingState");
            }
        }

        // Destruir los objetos persistentes
        GameObject[] persistentObjects = GameObject.FindGameObjectsWithTag("Persistent");
        foreach (GameObject obj in persistentObjects)
        {
            UnityEngine.Object.Destroy(obj);
        }

        // Esperar un poco más para asegurarse de que ha acabado
        yield return new WaitForSeconds(1f);

        // Verificar el estado final
        Assert.AreEqual(GameManager.Instance.State, expectedState);
    }
}