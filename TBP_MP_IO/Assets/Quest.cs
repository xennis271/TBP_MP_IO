using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quest : MonoBehaviour { // i just do the ui not the real quest.
    public Dictionary<string, string> QuestLog = new Dictionary<string, string>(); 
    public void MakeFakeQuest()
    {
        MakeQuest("Fake","None",1,true,false); // makes a fake quest...
    }
    public void FinQuest(string NameOfQuest)
    {
        string output = QuestDone(NameOfQuest);
        Debug.Log(output);
    }
	public void MakeQuest(string NameOfQuest,string DesOfQuest,int GoldGivenFromQuest,bool CanDoOver, bool Done) // lots of data so i can pull from it later!
    {
        // add this to the log...
        QuestLog.Add(NameOfQuest, NameOfQuest+ "#" + DesOfQuest + "#" + GoldGivenFromQuest + "#" + CanDoOver +"#"+Done); // can only be one for right now...
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
                //Debug.Log("Saved Des:" + Line);
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
}
