using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class Core : MonoBehaviour {
    public string NameOfPlayer = "Error";
    public string Class = "None";
    public int Hp = 90;
    public int MaxHp = 100;
    public int Rep = 0;
    public bool JoinedEvilBotCo; // MUST BE PICKED!
    public List<string> Backpack = new List<string>();


    public GameObject OldCam;
    public GameObject Player;
    public GameObject Tot;
    public GameObject UI;
    public GameObject Bar;

    public void GetDataNameOfPlayer(string NameOfPlayerOld)
    {
        NameOfPlayer = NameOfPlayerOld;
    }
    public void GetDataClass(string ClassOld)
    {
        Class = ClassOld;
    }
    public void GetDataHp(int HpOld)
    {
        Hp = HpOld;
    }
    public void GetDataMaxHp(int MaxHpOld)
    {
        MaxHp = MaxHpOld;
    }
    public void GetDataRep(int RepOld)
    {
        Rep = RepOld;
    }
    public void GetDataJoinedEvilBotCo(bool JoinedEvilBotCoOld)
    {
        JoinedEvilBotCo = JoinedEvilBotCoOld;
    }
    public void GetDataBackpack(List<string> BackpackOld)
    {
        Backpack = BackpackOld;
    }
    public void StartGameEscaped()
    {
        // LINK START!
        //Debug.Log("This is as far as i have programed!");
        OldCam.SetActive(false);
        Player.SetActive(true);
        UI.SetActive(true);
        Tot.SetActive(true);
        Bar.SetActive(true);
    }
    public void StartGameJoined()
    {
        // LINK START!
        OldCam.SetActive(false);
        Player.SetActive(true);
        UI.SetActive(true);
        Tot.SetActive(true);
        Bar.SetActive(true);
        //Debug.Log("This is as far as i have programed!");
    }
    public void AddToBackPack(string thing)
    {
        Backpack.Add(thing);
    }
    public int HowBigIsBackPack()
    {
        return Backpack.Count;
    }
}
