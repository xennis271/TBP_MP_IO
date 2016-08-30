using UnityEngine;
using System.Collections;

public class Picky : MonoBehaviour {
    public bool Talky = false;
    public bool Dis = true; // kill by def
    public bool Quest = false;
    public string Message = "";
    public GameObject SendTalkTo;



	public void PickedUp() // called when the player picks you up (NOTE THIS IS JUST A REMOVE SCRIPT) {ITS ALL READY IN THE PLAYERS BP!)_
    {
        if (Quest)
        {
            SendTalkTo.SendMessage(Message);
        }
        if (Talky)
        {
            Debug.Log("Hit!");
            Talky = false;
            SendTalkTo.SendMessage("Talk");
            StartCoroutine("TalkyWait");
        }
        if(Dis)
        {
            Destroy(this.gameObject); // DIE!
        }
    }
    IEnumerator TalkyWait()
    {
        yield return new WaitForSeconds(5);
        Talky = true;
    }
}
