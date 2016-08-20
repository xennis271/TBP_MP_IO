using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class NpcChecker : MonoBehaviour {
    // we need to get some info about the player...
    //public GameObject Player;
    public List<string> Collectabulls; // the names of all those who we can pickUp
    public List<string> Npcs; // Npcs....
    public GameObject Core;

   void OnControllerColliderHit(ControllerColliderHit thing)
    {
        if (Collectabulls.Contains(thing.gameObject.name))
        {
            // we can talk to it so send it a message
            // MAX IS 10.
            int curent = Core.GetComponent<Core>().Backpack.Count;
            if (curent < 10)
            {
                thing.gameObject.SendMessage("PickedUp");
                // Call up core!
                Core.SendMessage("AddToBackPack", thing.gameObject.name);
            }
            else
            {
                Debug.Log("Players Inv is too full!");
            }
        }
        else
        {
            //Debug.Log("Player Hit:" + thing.gameObject.name);
        }
        if (Npcs.Contains(thing.gameObject.name))
        {
                thing.gameObject.SendMessage("Talk");
        }
    }
}
