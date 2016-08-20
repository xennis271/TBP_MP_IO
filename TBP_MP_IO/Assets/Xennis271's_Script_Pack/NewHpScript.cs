using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class NewHpScript : MonoBehaviour
{
    public float Hp = 1;
    public float HpRate = 0.01f;
    public float MaxHp = 100;
    public Text HpText;


    // Use this for initialization
    void Start()
    {
        // Loading Hp
        HpText.text = Hp.ToString();
       // Debug.Log("Hp Online!");
    }

    // Update is called once per frame
    void Update()
    {
        Hp += HpRate;
        if (Hp > MaxHp)
        {
            Hp += -1.00f; // to keep healing online
        }
        HpText.text = "Your Hp:" +Mathf.Round(Hp).ToString();
    }
}
