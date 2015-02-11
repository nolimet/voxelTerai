using UnityEngine;
using System.Collections;

public class DebugCounter : MonoBehaviour {

    int[] fps = new int[60];
    float avrage;
    int timer = 0;
    void Update()
    {
        int l = fps.Length-1;
        int tmp = 0;
        for (int i = l; i > 0; i--)
        {
            fps[i] = fps[i - 1];
        }
        fps[0] = Mathf.FloorToInt(1f / Time.deltaTime);

        if (timer == 0)
        {
            for (int i = 0; i < l; i++)
            {
                tmp += fps[i];
            }


            avrage = 1f * tmp / (l + 1f);
            timer = 5;
        }
        timer--;
        
        
    }

	void OnGUI()
    {
        
            GUI.Label(new Rect(20, 20, 100, 20), "FPS:" + avrage);
            
        

        
    }
}
