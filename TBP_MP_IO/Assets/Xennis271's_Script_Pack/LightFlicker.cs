using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    public Light Light;
    //public int Wait;
    public int Max;
    public int Num;
    public int Num2;
    public int Max2;

    // Update is called once per frame
    void Update()
    {
        Light.enabled = false;
        Num++;
        if (Num >= Max)
        {
            Num2++;
            Light.enabled = true;
            if (Num2 >= Max2)
            {
                Num = 0;
                Num2 = 0;
                Light.enabled = false;
            }
        }
    }
}
