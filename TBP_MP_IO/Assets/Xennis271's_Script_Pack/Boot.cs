using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class Boot : MonoBehaviour { // man this is old cool code but still old.
    public void Wait(int Time)
    {
        System.Threading.Thread.Sleep(Time * 1000);
    }
    public string DontEdit = "This is just for the Dev to know this is using the Calm Template!";

    public string NameOfGame;
    public int VOfGame;

    public string NameOfPlayer = "Error";
    public string Class = "None";
    public int Hp = 90;
    public int MaxHp = 100;
    public int Rep = 0;
    public bool JoinedEvilBotCo; // MUST BE PICKED!
    public List<string> Backpack = new List<string>();

    public GameObject Core;
    public GameObject MessageTemplateClam;
    public GameObject MessageTemplateUrgent;
    public GameObject MessageTemplateNews;
    public GameObject MessageTemplate;
    public Text MessageTemplateTitle; // this change depending on template
    public Text MessageTemplateMessage; // /\

    public GameObject QuestionTemplate;
    public GameObject Q1; // good
    public GameObject Q2; // meh
    public GameObject Q3; // bad
    public Button BQ1;
    public Button BQ2;
    public Button BQ3;
    public Text DQ1;
    public Text DQ2;
    public Text DQ3;

    // lets talk to the player
    void Start () {

        // BOOTING PICKING TEMPLATE NOW
        MessageTemplate.SetActive(true); // Note this is JUST the Background you must PICK a template STILL
        MessageTemplateClam.SetActive(true); // this is whare you pick what template you want/need
        MessageTemplateUrgent.SetActive(false);
        MessageTemplateNews.SetActive(false);


        
        MessageTemplateMessage.text = "Loading V:" + VOfGame;
        MessageTemplateTitle.text = "Wellcome to " + NameOfGame;
        // lets get some info...
        
        
        MessageTemplateMessage.text = "Sorry for the Rude wake up you have been out for some time commander...";
        // lets get some input
        QuestionTemplate.SetActive(true);
        
        
        Q1.SetActive(true); // allowing good coments
        Q2.SetActive(true); // allowing meh coments
        Q3.SetActive(true); // allowing bad coments
        DQ1.text = "Not to be rude but who are you?[+1 Rep]";
        DQ2.text = "Who are you";
        DQ3.text = "What the Fuxk are you![-1 Rep]";
        // now we wait for the user to call the right method
        BQ1.onClick.RemoveAllListeners();
        BQ1.onClick.AddListener(PlayerMakingGood);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(PlayerMakingMeh);
        BQ3.onClick.RemoveAllListeners();
        BQ3.onClick.AddListener(PlayerMakingBad);
    }
    public void PlayerMakingBad() // takes one rep away
    {
        Rep = Rep - 1;
        QuestionTemplate.SetActive(false);
        MessageTemplate.SetActive(true);
        MessageTemplateMessage.text = "Your still the same i see...";
        MessageTemplateTitle.text = "Bitch mode i see...";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(false); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(false); //bad coments
        BQ1.onClick.RemoveAllListeners();
        //BQ1.onClick.AddListener(PlayerMakingGood);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(PlayerMakingName);
        BQ3.onClick.RemoveAllListeners();
        //BQ3.onClick.AddListener(PlayerMakingGoodV2YesAndNo);
        DQ2.text = "What Ever!";
    }
    public void PlayerMakingMeh()
    {
        QuestionTemplate.SetActive(false);
        MessageTemplate.SetActive(true);
        MessageTemplateMessage.text = "I am Anna a robot that is your \"Helper\" or at least thats what they call it... anyway the point is Wait why are you not yelling at me i mean its just odd you normaly are screming at this point...";
        MessageTemplateTitle.text = "Calm?";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(true); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(true); //bad coments
        BQ1.onClick.RemoveAllListeners();
        BQ1.onClick.AddListener(PlayerMakingGood);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(PlayerMakingName);
        BQ3.onClick.RemoveAllListeners();
        BQ3.onClick.AddListener(PlayerMakingBad);
        DQ1.text = "Odd Well in anycase i am sorry for the problems i may have made. [+1 rep]";
        DQ2.text = "...";
        DQ3.text = "Well i can see why SHUT UP! [-1 rep]";
    }
    public void PlayerMakingGood() // Gives +1rep
    {
        Rep = Rep + 1;
        QuestionTemplate.SetActive(false);
        MessageTemplate.SetActive(true);
        MessageTemplateMessage.text = "Your Being NICE TO ME?!this is ODD vary odd did you hit your head or somthing ? ";
        MessageTemplateTitle.text = "WHAT?!";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(false); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(true); //bad coments
        //
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(PlayerMakingGoodV2Yes);
        BQ3.onClick.RemoveAllListeners();
        BQ3.onClick.AddListener(PlayerMakingGoodV2No);
        //DQ1.text = "";
        DQ2.text = "Yes.";
        DQ3.text = "No.";
    }
    public void PlayerMakingGoodV2Yes()
    {
        QuestionTemplate.SetActive(false);
        // playing it off now
        MessageTemplateMessage.text = "Well i will can help... ... ... ...Well after trying i dont think i can do much good its best if you go see a doc bot";
        MessageTemplateTitle.text = "Thinking.";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(false); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(false); //bad coments
        BQ1.onClick.RemoveAllListeners();
        //BQ1.onClick.AddListener(PlayerMakingGood);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(PlayerMakingName);
        BQ3.onClick.RemoveAllListeners();
        //BQ3.onClick.AddListener(PlayerMakingGoodV2YesAndNo);
        DQ2.text = "...";
    }
    public void PlayerMakingGoodV2No()
    {
        QuestionTemplate.SetActive(false);
        // playing it off now
        MessageTemplateMessage.text = "Realy this is odd i have never seen you act like this!";
        MessageTemplateTitle.text = "Odd.";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(false); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(false); //bad coments
        BQ1.onClick.RemoveAllListeners();
        //BQ1.onClick.AddListener(PlayerMakingGood);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(PlayerMakingName);
        BQ3.onClick.RemoveAllListeners();
        //BQ3.onClick.AddListener(PlayerMakingGoodV2YesAndNo);
        DQ2.text = "...";
    }
    public void PlayerMakingName()
    {
        QuestionTemplate.SetActive(false);
        // playing it off now
        MessageTemplateMessage.text = "So Bob what do you want to do?";
        MessageTemplateTitle.text = "Name.";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(true); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(true); //bad coments
        BQ1.onClick.RemoveAllListeners();
        BQ1.onClick.AddListener(NiceBob);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(StartGameWithTheNameBob);
        BQ3.onClick.RemoveAllListeners();
        BQ3.onClick.AddListener(MeanBob);
        DQ1.text = "Sorry who's bob? [+1 rep]";
        DQ2.text = "... [you pick the name bob]";
        DQ3.text = "Bitch! My name is NOT bob! [50% chance to have the name bob also -1rep]";

    }
    public void MeanBob()
    {
        QuestionTemplate.SetActive(false);
        // playing it off now
        MessageTemplateMessage.text = "Well i was hopeing that we could be nice but i guess i will just have to jump to the facts your... Dead!";
        MessageTemplateTitle.text = "BITCH SAY WHAT?!";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(false); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(false); //bad coments
        BQ1.onClick.RemoveAllListeners();
        //BQ1.onClick.AddListener(StartGame);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(WHAT);
        BQ3.onClick.RemoveAllListeners();
        //BQ3.onClick.AddListener(StartGame);
       // DQ1.text = "Sorry who's bob? [+1 rep]";
        DQ2.text = "YOU BITCH! {your going to lose 1 rep}";
       // DQ3.text = "Bitch! My name is NOT bob! [50% chance to have the name bob also -1rep]";
    }
    public void NiceBob()
    {
        QuestionTemplate.SetActive(false);
        // playing it off now
        MessageTemplateMessage.text = "Well you see you sort of well died...";
        MessageTemplateTitle.text = "[X.X]  DEAD?!";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(true); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(false); //bad coments
        BQ1.onClick.RemoveAllListeners();
        BQ1.onClick.AddListener(WHAT);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(StartGameWithTheNameBob);
        BQ3.onClick.RemoveAllListeners();
       // BQ3.onClick.AddListener(WHAT);
        DQ1.text = "I did?! how?!";
        DQ2.text = "...";
        //DQ3.text = "Bitch! My name is NOT bob! [50% chance to have the name bob also -1rep]";
    }
    public void StartGameWithTheNameBob()
    {
        // not realy creative are we?
        NameOfPlayer = "Bob";
        QuestionTemplate.SetActive(false);
        // playing it off now
        MessageTemplateMessage.text = "Well... Not talking is better than yelling i guess. Anyway I have bad news... You Well you died...";
        MessageTemplateTitle.text = "Dead?!";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(true); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(false); //bad coments
        BQ1.onClick.RemoveAllListeners();
        BQ1.onClick.AddListener(WHAT);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(NoTalking);
        BQ3.onClick.RemoveAllListeners();
        //BQ3.onClick.AddListener(StartGame);
        DQ1.text = "WAIT WHAT!";
        DQ2.text = "...";
        DQ3.text = "";

    }
    public void WHAT() // to be made Nice/Mean land here.... odd ;d
    {
        QuestionTemplate.SetActive(false);
        // playing it off now
        MessageTemplateMessage.text = "Yep you died... By my hand... See me and you we are sort of at war.";
        MessageTemplateTitle.text = "WAR?!";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(true); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(true); //bad coments
        BQ1.onClick.RemoveAllListeners();
        BQ1.onClick.AddListener(Join);
        BQ2.onClick.RemoveAllListeners();
        BQ2.onClick.AddListener(NoTalking);
        BQ3.onClick.RemoveAllListeners();
        BQ3.onClick.AddListener(Escape);
        DQ1.text = "What! i dont know why but i forgive you. [Try to join the EVIL robot team] {-100 rep}";
        DQ2.text = "...";
        DQ3.text = "Try to run {50% chance} [+5 rep]";
    }
    public void NoTalking() // you dont say anything... so you join the Escaping Path...
    {
        QuestionTemplate.SetActive(false);
        // playing it off now
        MessageTemplateMessage.text = "*&^$%%& HACK DONE*&*&^& Hi its me Dennis the dev of this program... look man you cant just say nothing here... Here just to play with you i am going to put you in the same room as that evil computer lets see how long you last now!";
        MessageTemplateTitle.text = "Dev.";
        QuestionTemplate.SetActive(true);
        Q1.SetActive(true); //good coments
        Q2.SetActive(true); //meh coments
        Q3.SetActive(true); //bad coments
        BQ1.onClick.RemoveAllListeners();
        BQ1.onClick.AddListener(Escape);
        BQ2.onClick.RemoveAllListeners();
       // BQ2.onClick.AddListener(StartGameWithTheNameBob);
        BQ3.onClick.RemoveAllListeners();
       // BQ3.onClick.AddListener(StartGame);
        DQ1.text = "RUN!";
       // DQ2.text = "... [you pick the name bob]";
       // DQ3.text = "Bitch! My name is NOT bob! [50% chance to have the name bob also -1rep]";
    }
    public void Escape()
    {
        JoinedEvilBotCo = false;
        // time to start the game...
        // GIVING DATA
        Core.SendMessage("GetDataNameOfPlayer",NameOfPlayer);
        Core.SendMessage("GetDataClass", Class);
        Core.SendMessage("GetDataHp",Hp);
        Core.SendMessage("GetDataMaxHp",MaxHp);
        Core.SendMessage("GetDataRep", Rep);
        Core.SendMessage("GetDataJoinedEvilBotCo", JoinedEvilBotCo);
        Core.SendMessage("GetDataBackpack",Backpack);
        MessageTemplate.SetActive(false); // Note this is JUST the Background you must PICK a template STILL
        MessageTemplateClam.SetActive(false); // this is whare you pick what template you want/need
        MessageTemplateUrgent.SetActive(false);
        MessageTemplateNews.SetActive(false);
        QuestionTemplate.SetActive(false);
        Core.SendMessage("StartGameEscaped");
        // we also need to give a quest...
        var Quest = GameObject.Find("_Core").GetComponent<Quest>();
        Quest.MakeQuest("Fix Teleporter","Go around the room and pick up the parts.",1,false,false); // ALL OF THE DATA!
    }
    public void Join()
    {
        JoinedEvilBotCo = true;
        // time to start the game...
        Core.SendMessage("GetDataNameOfPlayer", NameOfPlayer);
        Core.SendMessage("GetDataClass", Class);
        Core.SendMessage("GetDataHp", Hp);
        Core.SendMessage("GetDataMaxHp", MaxHp);
        Core.SendMessage("GetDataRep", Rep);
        Core.SendMessage("GetDataJoinedEvilBotCo", JoinedEvilBotCo);
        Core.SendMessage("GetDataBackpack", Backpack);
        MessageTemplate.SetActive(false); // Note this is JUST the Background you must PICK a template STILL
        MessageTemplateClam.SetActive(false); // this is whare you pick what template you want/need
        MessageTemplateUrgent.SetActive(false);
        MessageTemplateNews.SetActive(false);
        QuestionTemplate.SetActive(false);
        Core.SendMessage("StartGameJoined");
        // we also need to give a quest...
        var Quest = GameObject.Find("_Core").GetComponent<Quest>();
        Quest.MakeQuest("Fix Teleporter", "Go around the room and pick up the parts.", 1, false, false); // ALL OF THE DATA!
    }
}
