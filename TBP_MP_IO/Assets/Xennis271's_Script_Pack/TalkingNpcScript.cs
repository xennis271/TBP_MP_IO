using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;
// Welcome to the talking engin this script makes all NPCs talk to the player in a way that is one sided... all paths lead to the same thing.



public class TalkingNpcScript : MonoBehaviour { // this thing is picky and a bich from time to time...

    // Normaly this would be called when ever the player wanted to talk to someone..
    // how this works is that the 0 elment is the 1st thing called and then when ever you say somthing the next thing is called
    public Text Output;
    public Text But1;
    public Text But2;
    public Text But3;
    public Text Title;
    public GameObject But1GO;
    public GameObject But2GO;
    public GameObject But3GO;
    public GameObject TalkingGO;
    public GameObject NormalCam;
    public GameObject TalkingCam;
    public GameObject TalkingMessageTemp;
    public GameObject QuestionTemp;
    public GameObject CalmTemp;
    public GameObject Player;
    public GameObject Core;
    public bool Quest = false;
    public string CheckIfThisQuestIsDone;
    public int IDofAction;
    public bool QuestGiven = false;
    public string NameOfQuest = "";
    public string DesOfQuest = "";
    public int AmountOfGold = 0;
    public bool CanBeDoneOver = false;
    public bool Done = false;
    bool ran = false;
    /* Fake part 100% NOT in game!
    somthing var? idk questMan
    bool quest = false; // normaly you will not be making quest here...
    latter in the code
    if quest is true do this stuff
    send a message to questMan along the lines of
    MakeQuest(Title,Des,Type Of Quest,Amount needed for compleation, Things given out) or somthing like that!
    */


    public int Stage = 0; // normaly 0 becuse we are not picking up a old chat...
    public int ExitStage; // this is the stage the player will be send to after exiting talk
    public int EndingStage; // set in editor!
    //public string Set = "None loading";
    public List<string> NormalDie;
    public List<string> GoodDie;
    public List<string> BadDie;



    public List<string> SetA;
    public List<string> SetB;
    public List<string> SetC;



    public void Exit() // closing all the things that this script used... its a lot...
    {
        Player.SetActive(true);
        TalkingGO.SetActive(false);
        TalkingCam.SetActive(false);
        NormalCam.SetActive(true);
        TalkingMessageTemp.SetActive(false);
        QuestionTemp.SetActive(false);
        CalmTemp.SetActive(false);
        But1GO.SetActive(false);
        But2GO.SetActive(false);
        But3GO.SetActive(false);
        But1GO.GetComponent<Button>().onClick.RemoveAllListeners();
        But2GO.GetComponent<Button>().onClick.RemoveAllListeners();
        But3GO.GetComponent<Button>().onClick.RemoveAllListeners();
        Stage = ExitStage;
        Debug.Log("Exiting stage was set to..." + Stage);
        if (Quest && QuestGiven != true)
        {
            QuestGiven = true;
            // give the quest...
            Core.GetComponent<Quest>().MakeQuest(NameOfQuest,DesOfQuest,AmountOfGold,CanBeDoneOver,Done); // Lots of vars there.
        }
        if (Core.GetComponent<Quest>().DoneQuest.Contains(CheckIfThisQuestIsDone))
        {
            // we need to do somthing...
            if (IDofAction == 1) // kill the player....
            {
                Player.SetActive(false); // makes the player stay?
                SceneManager.LoadScene(1);
            }
        }
    }
    public void Boot() // grabing all the things that this script needs to be online its a lot
    {
        Debug.Log("Booting stage on boot is..." + Stage);
        Player.SetActive(false); // Kill player!
        TalkingGO.SetActive(true);
        NormalCam.SetActive(false);
        TalkingCam.SetActive(true);
        TalkingMessageTemp.SetActive(true);
        QuestionTemp.SetActive(true);
        CalmTemp.SetActive(true);
        But1GO.SetActive(true);
        But2GO.SetActive(true);
        But3GO.SetActive(true);
        if (ran != true) // runs on boot.
        {
            But1GO.GetComponent<Button>().onClick.RemoveAllListeners();
            But2GO.GetComponent<Button>().onClick.RemoveAllListeners();
            But3GO.GetComponent<Button>().onClick.RemoveAllListeners();
            ran = true;
        }
        // Binding to my commands!
        But1GO.GetComponent<Button>().onClick.AddListener(GoodBut);
        But2GO.GetComponent<Button>().onClick.AddListener(NutBut);
        But3GO.GetComponent<Button>().onClick.AddListener(BadBut);
    }
    public void GoodBut()
    {
        this.gameObject.SendMessage("Good");
    }
    public void BadBut()
    {
        this.gameObject.SendMessage("Bad");
    }
    public void NutBut()
    {
        this.gameObject.SendMessage("Talk");
    }


    public void Good() // called when a good thing is picked
    {
       // Boot();
        // Set text...
        if (Stage != EndingStage)
        {
            Output.text = GoodDie[Stage];
            But1.text = SetA[Stage];
            But2.text = SetB[Stage];
            But3.text = SetC[Stage];
            Stage++;
        }
        else
        {
            // exit
            Exit();
        }
    }
    public void Bad() // called when a good thing is picked
    {
        // Set text...
      //  Boot();
        if (Stage != EndingStage)
        {
            Output.text = BadDie[Stage];
            But1.text = SetA[Stage];
            But2.text = SetB[Stage];
            But3.text = SetC[Stage];
            Stage++;
        }
        else
        {
            // exit
            Exit();
        }
    }
    void Talk() { // called when a nut thing is picked
        Boot();
        Title.text = ""; // maby add later.
        if (Stage != EndingStage)
        {
            Output.text = NormalDie[Stage];
            But1.text = SetA[Stage];
            But2.text = SetB[Stage];
            But3.text = SetC[Stage];
            Stage++;
        }
        else
        {
            // exit
            Exit();
        }
    }
}
