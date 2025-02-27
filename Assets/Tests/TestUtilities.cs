using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections;


public static class TestUtilities
{
    private static bool spacePressedThisFrame = false;
    public static IEnumerator RunTest(string sceneName, MovementsManager movementsManager, GameState expectedState,float timeBetweenmovementsMultiplicator = 2f)
    {
        
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        yield return new WaitForSeconds(0.1f * timeBetweenmovementsMultiplicator);

        // Realizar las acciones específicas del test
        for (int i = 0; i < movementsManager.buttonspressed.Count; i++)
        {
            if (GamingState.Instance != null)
            {
                Debug.Log("aqui esperando antes de pulsar espacio " + i);

                // Espera hasta que se presione la tecla de espacio
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                Debug.Log("executed " + i);
                movementsManager.executeComand(i);

                // Esperar a que se libere la tecla de espacio para evitar múltiples activaciones
                yield return new WaitUntil(() => !Input.GetKey(KeyCode.Space));
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