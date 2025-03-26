using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerSelected
{

    public CheckPlayerSelected()
    {
        
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.changePlayerTypeToMove();
            GamingState.PlayerMovementsStored.AddMChangePlayer(1);

            GameObject SplungesTypesPanel = MapLoader.Instance.SplungesTypesPanel;

            Transform splunges = SplungesTypesPanel.transform.GetChild(0); // Obtiene "Splunges"
            GameObject splunje1 = splunges.GetChild(0).gameObject; 
            GameObject splunje2 = splunges.GetChild(1).gameObject; 
            GameObject splunje3 = splunges.GetChild(2).gameObject;

            Canvas canvasHija = splunje1.transform.GetChild(0).gameObject.GetComponent<Canvas>();
            canvasHija.overrideSorting = true;

            splunje1.transform.GetChild(0).gameObject.SetActive(Player.currentAllowedType == Player.PlayerType.Type1);
            splunje2.transform.GetChild(0).gameObject.SetActive(Player.currentAllowedType == Player.PlayerType.Type2);
            splunje3.transform.GetChild(0).gameObject.SetActive(Player.currentAllowedType == Player.PlayerType.Type3);

            canvasHija.overrideSorting = true;


        }
    }

}
