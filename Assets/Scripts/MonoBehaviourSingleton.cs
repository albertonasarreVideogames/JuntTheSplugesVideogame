using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase actúa como un singleton MonoBehaviour
public class MonoBehaviourSingleton : MonoBehaviour
{
    private static MonoBehaviourSingleton instance;
    public static MonoBehaviourSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                // Crea un GameObject para alojar este script si no existe uno
                GameObject go = new GameObject("MonoBehaviourSingleton");
                instance = go.AddComponent<MonoBehaviourSingleton>();
            }
            return instance;
        }
    }

    // Asegúrate de que este GameObject no se destruya al cargar una nueva escena
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
