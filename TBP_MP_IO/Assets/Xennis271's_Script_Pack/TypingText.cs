using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TypingText : MonoBehaviour
{
    public int Stage = 0; // normaly set to 0
    public List<string> MessageBox;
    string Message; // Dont set
    public Text TextBox;
    public GameObject TextGo;
    public float Speed;
    public bool Ui = false;
    public GameObject Backpack;
    public GameObject QuestUI;

    // Use this for initialization
    void Start()
    {
        TextBox.text = "";
        StartCoroutine("AutoType");
    }

    // Update is called once per frame
    IEnumerator AutoType()
    {
        while (Stage < MessageBox.Count)
        {
            Message = MessageBox[Stage];
            Stage++;
            foreach (char letter in Message.ToCharArray())
            {
                TextBox.text += letter;
                yield return new WaitForSeconds(Speed);
            }
            // clear the box...
            yield return new WaitForSeconds(3); // add a little bit of time for the user to read the last text!
            TextBox.text = "";
            
        }
        if (Ui)
        {
            // turn on all of his ui...
            Backpack.SetActive(true);
            QuestUI.SetActive(true);
        }
        TextGo.SetActive(false);
    }
}
