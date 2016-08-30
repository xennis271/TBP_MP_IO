using UnityEngine;
using System.Collections;

public class Curse_Lock : MonoBehaviour {
    public GameObject Player;
    bool tab = false;
    public GameObject QuestGui;
    IEnumerator Waitt()
    {
        yield return new WaitForSeconds(1); // add a little bit of time for the user to read the last text!
        tab = true;
    }
    IEnumerator Waitf()
    {
        yield return new WaitForSeconds(1); // add a little bit of time for the user to read the last text!
        tab = false;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
	void Update () {
        if (tab == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Cursor.lockState = CursorLockMode.None;
                // Player wants to access his curse
                Player.SetActive(false);
                QuestGui.SetActive(false);
                Cursor.visible = true;
                // wait tell you set that tab to true
                StartCoroutine("Waitt");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                tab = true;
                QuestGui.SetActive(true);
                // Player wants to hide his curse
                Player.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.None;
                StartCoroutine("Waitf");
            }
        }
	}
}
