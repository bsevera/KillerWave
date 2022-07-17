using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    SOActorModel actorModel;
    GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayer()
    {
        //CREATE PLAYER
        actorModel = Object.Instantiate(Resources.Load("Script/ScriptableObject/Player_Default")) as SOActorModel;
        playerShip = GameObject.Instantiate(actorModel.actor) as GameObject;
        playerShip.GetComponent<Player>().ActorStats(actorModel);

        //SET PLAYER UP
        //--faces the player the right way
        playerShip.transform.rotation = Quaternion.Euler(0, 180, 0);

        //--sets the scale of the player ship to 60 on all axes
        playerShip.transform.localScale = new Vector3(60, 60, 60);

        //--renames the object once it's cloned
        playerShip.name = "Player";

        //--puts the object under the player container
        playerShip.transform.SetParent(this.transform);

        //--positions the player in the center of the screen, equivalent to x = 0, y = 0 ,z = 0
        playerShip.transform.position = Vector3.zero;
    }
}
