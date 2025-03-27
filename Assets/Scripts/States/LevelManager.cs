using UnityEngine;
using System.IO;

public class LevelManager : MonoBehaviour
{
    private string rutaArchivo = Application.persistentDataPath + "/progreso.json";

    // Guardar los niveles completados en un archivo JSON
    private void GuardarProgreso(Progreso progreso)
    {
        string json = JsonUtility.ToJson(progreso);
        File.WriteAllText(rutaArchivo, json);
    }

    // Cargar los niveles completados desde un archivo JSON
    public Progreso CargarProgreso()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            return JsonUtility.FromJson<Progreso>(json);
        }
        return new Progreso(); // Devuelve un objeto vacío si no se encuentra el archivo
    }

    // Método para agregar un nivel completado al progreso
    public void AgregarNivelCompletado(string nivel)
    {
        Progreso progreso = CargarProgreso();
        if (!progreso.nivelesCompletados.Contains(nivel))
        {
            progreso.nivelesCompletados.Add(nivel);
            GuardarProgreso(progreso);
            Debug.Log(rutaArchivo);
        }
    }
}

