using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindState : MonoBehaviour
{
    private static bool spacePressedThisFrame = false;
    public static IEnumerator RunTest(
    string sceneName,
    MovementsManagerPlay movementsManager,
    GameState expectedState,
    float timeBetweenmovementsMultiplicator = 2f
)
    {
        //yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        yield return new WaitForSeconds(0.1f * timeBetweenmovementsMultiplicator);

        // Iterar sobre los comandos de movimiento
        for (int i = 0; i < movementsManager.buttonspressed.Count; i++)
        {
            if (GamingState.Instance != null)
            {
                Debug.Log("Esperando antes de pulsar espacio " + i);

                // Espera a que se presione la tecla de espacio (pero evita múltiples presiones rápidas)
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) && !spacePressedThisFrame && GamingState.Instance.getIfPlayersStopMoving());

                // Marcar que la tecla espacio ha sido presionada
                spacePressedThisFrame = true;

                Debug.Log("Ejecutado " + i);
                movementsManager.executeComand(i);

                // Espera hasta que se libere la tecla de espacio para evitar múltiples activaciones
                yield return new WaitUntil(() => !Input.GetKey(KeyCode.Space));

                // Marcar que la tecla espacio ha sido liberada
                spacePressedThisFrame = false;
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
        //Assert.AreEqual(GameManager.Instance.State, expectedState);
    }

}
