using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flash : MonoBehaviour {

    public Text Text;
    //public int Wait;
    public int Max;
    public int Num;
    public int Num2;
    public int Max2;
	// Update is called once per frame
	void Update () {
        Text.enabled = true;
        Num++;
        if (Num>= Max)
        {
            Num2++;
            if(Num2 >= Max2)
            {
                Num = 0;
                Num2 = 0;
                int Num12 = Random.Range(0,10);
                if (Num12 == 1)
                {
                    Text.color = Color.black;
                }
                if (Num12 == 2)
                {
                    Text.color = Color.blue;
                }
                if (Num12 == 3)
                {
                    Text.color = Color.cyan;
                }
                if (Num12 == 4)
                {
                    Text.color = Color.green;
                }
                if (Num12 == 5)
                {
                    Text.color = Color.grey;
                }
                if (Num12 == 6)
                {
                    Text.color = Color.magenta;
                }
                if (Num12 == 7)
                {
                    Text.color = Color.blue;
                }
                if (Num12 == 8)
                {
                    Text.color = Color.white;
                }
                if (Num12 == 9)
                {
                    Text.color = Color.yellow;
                }
            }
            
            Text.enabled = false;
        }
        
    }
}
