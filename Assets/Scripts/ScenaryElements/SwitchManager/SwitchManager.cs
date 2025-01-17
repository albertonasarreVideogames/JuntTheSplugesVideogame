using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SwitchManager
{
    private static readonly string[] layers = { "OrangeSwitch", "BlueSwitch", "PinkSwitch", "GreenSwitch", "OrangeSwitchPulse", "BlueSwitchPulse", "PinkSwitchPulse", "GreenSwitchPulse" };

    private static readonly Dictionary<string, List<Animator>> switches = new Dictionary<string, List<Animator>>();

    public static void Initialize()
    {
        switches.Clear();
        Switch[] allSwitches = Object.FindObjectsOfType<Switch>();

        foreach (var switchObj in allSwitches)
        {
            string layerName = LayerMask.LayerToName(switchObj.gameObject.layer);

            // Solo procesamos las capas que están en el array
            if (System.Array.Exists(layers, layer => layer == layerName))
            {
                if (!switches.ContainsKey(layerName))
                {
                    switches[layerName] = new List<Animator>();
                }

                Animator animator = switchObj.GetComponent<Animator>();
                if (animator != null)
                {
                    switches[layerName].Add(animator);
                }
            }
        }
    }

    //private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
      //  Initialize();
    //}

        // Método para activar una animación en un switch específico
        public static void TriggerAnimation(string layerName, string triggerName,bool anyPlayerContact)
    {
        if (switches.ContainsKey(layerName))
        {
            foreach (Animator animator in switches[layerName])
            {
                AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
                if (currentState.IsName("NotPulsed") && anyPlayerContact)
                {
                    animator.SetBool(triggerName, true);               
                }
                if (currentState.IsName("Pulsed") && !anyPlayerContact)
                {
                    animator.SetBool(triggerName, false);
                }

            }
        }
        else
        {
            //Debug.LogWarning($"No se encontraron switches en la capa {layerName}.");
        }
    }
}

