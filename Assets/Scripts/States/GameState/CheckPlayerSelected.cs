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

            if (MapLoader.Instance.NumberKindPlayers == 2) { splunje3.SetActive(false); }
            if (MapLoader.Instance.NumberKindPlayers == 3) { splunje3.SetActive(true); }
        }
    }

}
