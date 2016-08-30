using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Quest : MonoBehaviour { // i handle new quest and old quest not only that but i also handle QuestBook rec.
    public Dictionary<string, string> QuestLog = new Dictionary<string, string>();
    [Header("LOCAL ACCESS ONLY!")]
    public List<string> QuestTitleLog; // LOCAL ACCESS ONLY!
    public List<string> QuestDetails; // LOCAL ACCESS ONLY!
    [Header("The Buttons have to be upside down...")]
    public List<GameObject> QuestButtons;
    public List<Text> QuestTitleTextBoxesPre;
    public GameObject QuestDetailsGO;
    public Text TitleOfQuestDetails;
    public Text DesOfQuestDetails;
    [Header("This is for the quest gui bar (its ok if its offline!)")]
    public Text TitleOfBar;
    public Slider ProgressOnBar;
    [Header("This is a ever changing var dont call it for a list..")]
    public string CurentQuest;
    public bool OnQuest = false; // asumed
    public GameObject CurentButt;
    [Header("The most called thing...")]
    public List<string> DoneQuest; // this is all the quest that the player has done...



    // Method calls!
    public void MakeFakeQuest()
    {
        MakeQuest("Fake","None",1,true,false); // makes a fake quest...
        QuestTitleLog.Add("Fake"); // adds Fake Quest to my log.
    }
    public void FinQuest(string NameOfQuest)
    {
        string output = QuestDone(NameOfQuest);
        Debug.Log(output);
        QuestTitleLog.Remove(NameOfQuest);
        DoneQuest.Add(NameOfQuest);
    }
	public void MakeQuest(string NameOfQuest,string DesOfQuest,int GoldGivenFromQuest,bool CanDoOver, bool Done) // lots of data so i can pull from it later!
    {
        // add this to the log...
        QuestLog.Add(NameOfQuest, NameOfQuest+ "#" + DesOfQuest + "#" + GoldGivenFromQuest + "#" + CanDoOver +"#"+Done); // can only be one for right now...
        QuestTitleLog.Add(NameOfQuest);
        QuestDetails.Add(DesOfQuest);
        OnQuest = true;
        CurentQuest = NameOfQuest; // now we have the name set...
        //Debug.Log("Debug:" + CurentQuest);
        TitleOfBar.text = NameOfQuest;
        ProgressOnBar.value = 0; // sets the progress to 0
        CurentButt.SetActive(false);
    }
    public string QuestDone(string NameOfQuest)
    {
        string Data = "";
        QuestLog.TryGetValue(NameOfQuest, out Data);
        string[] CleanData = Data.Split('#');
        int counter = 0;
        string NewNameOfQuest = "";
        string DesOfQuest = "";
        string AmountOfGold = "";
        foreach (string Line in CleanData)
        {
            // whats this thing?
            counter++;
            //Debug.Log("Your on line :" + counter);
            if (counter == 1) // its the name
            {
                NewNameOfQuest = Line;
                //Debug.Log("Saved Name:" + Line);
            }
            if (counter == 2) // its the Des of the quest
            {
                DesOfQuest = Line;
                QuestDetails.Remove(DesOfQuest);
            }
            if (counter == 3) // its the amount of gold given...
            {
                //Debug.Log("Saved Amount of gold:" + Line);
                AmountOfGold = Line;
                int counterCounter = 0;
                int num = 0;
                int.TryParse(Line, out num);
                counterCounter = num;
                while (counterCounter >0) // keep this up tell we have given all the gold...
                {
                    if (GameObject.Find("_Core").GetComponent<Core>().Backpack.Count < 20) // 20 is max...
                    {
                        GameObject.Find("_Core").GetComponent<Core>().Backpack.Add("Gold");
                    }
                    counterCounter--; // we have given the gold...
                }
            }
            bool CanDoOver = false;
            if (counter == 4) // its the bool that says if we can do it over..
            {
                bool temp;
                bool.TryParse(Line, out temp);
                CanDoOver = temp;
            }
            if (counter == 5) // this is the thing saying if we are done with the quest..
            {
                //QuestLog.Remove(NameOfQuest);
                return "Quest:" + NameOfQuest + " is done you have done this task:[" + DesOfQuest + "] and have gotten payed this much for it Gp:" + AmountOfGold + "false/true on doing it over" + false;

            }
            if (CanDoOver) // @ this point its true
            {
                QuestLog.Remove(NameOfQuest);
                QuestLog.Add(NewNameOfQuest, NewNameOfQuest + "#" + DesOfQuest + "#" + AmountOfGold + "#" + CanDoOver + "#" + "false"); // set the done state to false!
            }
            else
            {
                QuestLog.Remove(NameOfQuest);
            }
        }
        return "ERROR!";
    }
    public void UpdateQuestBook() // i update the UI upon req
    {
        // how many slots do i have? 2 (for now. no limit script is put into place but you cant get more...)
        int slots = QuestTitleTextBoxesPre.Count;
        // how many slots do i need?
        //int UsedSlots = QuestLog.Count;
        int counterEx = 1;
        int ButtonsOff = 0;
        foreach (GameObject Button in QuestButtons)
        {
            ButtonsOff++;
            Button.SetActive(false); // we will reactvate soon!
        }
        Debug.Log("Buttons Turned Off:" + ButtonsOff);
        Debug.Log("CounterEx:" + counterEx + "QuestLog.Count" + QuestLog.Count);
        while (counterEx <= QuestLog.Count)
        {
            QuestButtons[counterEx].SetActive(true);
            counterEx++;
        }
        // we need all quest that we have soo we look to the list for names
        int counter = 0;
        int helped = 0;
        // ok we need to re think this right now we are looking for every quest...
        foreach (string Quest in QuestTitleLog)
        {
            while(counter != slots-1) // to account for 0.
            {
                var box = QuestTitleTextBoxesPre[counter]; // BUT THESE ARE BOXS! WHY ARE WE DOING THIS IN A QUEST LOOP?
                counter++;
                box.text = Quest;
                helped++;
            }
            
                // we have some boxes that are not empty
                foreach (Text Box in QuestTitleTextBoxesPre)
                {
                    if (Box.text == "Loading") // this has no data.
                    {
                        Box.text = "No Quest.";
                    }
                }
            
        }
    }
    public void ButtonOneClicked() // quest one was clicked...
    {
        QuestDetailsGO.SetActive(true);
        DesOfQuestDetails.text = QuestDetails[0]; // one is the button.
        TitleOfQuestDetails.text = QuestTitleLog[0]; // one is the button.
    }
    public void ButtonTwoClicked() // quest one was clicked...
    {
        QuestDetailsGO.SetActive(true);
        DesOfQuestDetails.text = QuestDetails[1]; // one is the button.
        TitleOfQuestDetails.text = QuestTitleLog[1]; // one is the button.
    }
    // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //
    // at this point we have all the buttons working all but geting it to set the current task... SO
    // to do this we need to pull data from that box... we can get the title of the quest and thats all we realy need that and...
    // we need to add somthing that alows things to edit the bar with out editing the gui quest bar ie if i kill somthing
    // that somthing needs to send me a message NOT send a message to the gui bar! (becuse that bar dies somtimes...)
    public void SetCurrentQuest() // we dont need to know who asked we just check to see if we have data...
    {
        if (OnQuest == false)
        {
            OnQuest = true;
            CurentQuest = TitleOfQuestDetails.text; // now we have the name set...
            //Debug.Log("Debug:" + CurentQuest);
            TitleOfBar.text = CurentQuest;
            ProgressOnBar.value = 0; // sets the progress to 0
        }else
        {
            Debug.Log("You have a quest!");
        }
    }
    public void AddOneToQuest()
    {
        ProgressOnBar.value += 1; // adds
    }
    public void SubOneToQuest()
    {
        ProgressOnBar.value += 1; // adds
    }
    public void Update() // check the quest...
    {
        if (OnQuest)
        {
            if (ProgressOnBar.value >= ProgressOnBar.maxValue)
            {
                ProgressOnBar.value = ProgressOnBar.maxValue;
                TitleOfBar.text = "Woo you have compleated Your Quest!";
                CurentButt.SetActive(true);
                OnQuest = false;
                FinQuest(CurentQuest);
            }
        }
    }
}
