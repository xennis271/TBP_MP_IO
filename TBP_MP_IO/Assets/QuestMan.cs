using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public class QuestMan : MonoBehaviour {
    public List<string> QuestNames;
    public List<string> QuestDet;
    public Dictionary<string,string> QuestData = new Dictionary<string,string>();
    public GameObject Core; // so we can send gold.
    IEnumerator Wait()
    {
            yield return new WaitForSeconds(3); // add a little bit of time for the user to read the last text!
        QuestDone("Fake");

        }
    public void Fakeq() // makes a fake quest...
    {
        MakeQuest("Fake","No real details about this fake quest.",100,"But",101);
        StartCoroutine("Wait");
    }

    public void MakeQuest(string QuestName,string QuestDetails,int GoldGiven,string ThingGiven,int AmountOfThing) // called when a quest is made
    {
        // QUEST ACCEPTED!
        QuestNames.Add(QuestName);
        QuestDet.Add(QuestDetails);
        // now we have to make some data that we can read after we have done this quest.
        // store it in the big book.
        string CleanData =  QuestDetails + "#" +GoldGiven.ToString() + "#" + ThingGiven + "#" + AmountOfThing;
        // what this means is
        // * = open the data form.
        // # = Divide
        // @ = end the data form.
        QuestData.Add(QuestName,CleanData);
    }
    public void QuestDone(string NameOfQuest)
    {
        // pull up that data
        string Data = "";
        QuestData.TryGetValue(NameOfQuest,out Data);
        // we are got data.
        // now we need to clean it
        // lets grab the gold.
        Data.Remove(0, 1);
        // now we have some number then a # we need to split
        string[] CleanDataList = Data.Split('#');
        int counter = 0;
        foreach (string Line in CleanDataList)
        {
            counter++;
            if (counter == 1)
            {
                Debug.Log("Quest Details:" + Line);
            }
            if (counter == 2)
            {
                Debug.Log("Gold to be given:"+Line);
            }
            if (counter == 3)
            {
                Debug.Log("Thing to be given:" + Line);
            }
            if (counter == 4)
            {
                Debug.Log("Amount of thing to be given:" + Line);
            }
        }
    }
}
