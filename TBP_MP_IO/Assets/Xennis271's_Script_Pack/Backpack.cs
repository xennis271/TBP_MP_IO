using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Backpack : MonoBehaviour {
    public List<GameObject> buttons;
    public List<Text> Title;
    public List<Image> Slots;
    public List<Sprite> Icons;
    public Dictionary<string,Sprite> Book = new Dictionary<string,Sprite>();


    void Start() // this is PRE MADE {HARD CODE}
    {
        Book.Add("Gold",Icons[0]);
        Book.Add("SandClock",Icons[1]);
        Book.Add("PowerCell",Icons[2]);
        Book.Add("TeleParts", Icons[3]);
    }
    public void UpdateBackpack()
    {
        // Grabing current backpack...
        var bp = GameObject.Find("_Core").GetComponent<Core>().Backpack; // We have the bp!
        int AmountOfThings = bp.Count;
        Debug.Log(AmountOfThings + " << Things in Bp");
        int MaxThings = 20;
        int counter = -1;
        foreach (GameObject but in buttons)
        {
            but.SetActive(false);
        }
        foreach (string Thing in bp)
        {
            if (counter < MaxThings)
            {
                counter++;
                buttons[counter].SetActive(true); // turns on what we need
                Text text = Title[counter];
                text.text = Thing; // gives all
                Sprite Pic;
                Book.TryGetValue(Thing, out Pic);
                Slots[counter].sprite = Pic; // this will error if no pic is found...
            }
        }
    }
}
