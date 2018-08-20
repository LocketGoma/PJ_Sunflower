using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulse : MonoBehaviour {
    Text TextPanel;
    int FadeSwitch;
    // Use this for initialization
    void Start () {
        TextPanel = gameObject.GetComponent<Text>();
        FadeSwitch = 1;
     //   Debug.Log("text");
     //   Debug.Log("A:" + TextPanel.color.a);

        StartCoroutine("Fade");
       // if (FadeSwitch == 1) StartCoroutine("FadeOut");
       // if (FadeSwitch == 0) StartCoroutine("FadeIn");
    }
	
	// Update is called once per frame


    IEnumerator FadeOut()
    {        
        float i = 200f;
        while (i>100f)
        {
            i -= 5f;
            TextPanel.color = new Vector4(TextPanel.color.r, TextPanel.color.g, TextPanel.color.b, i/255);
        //    Debug.Log("FadeOut A:" + TextPanel.color.a);
            yield return new WaitForSeconds(0.5f);
        }

        StopCoroutine("FadeOut");
        FadeSwitch ^= 1;
        yield return 0;

    }
    IEnumerator FadeIn()
    {
        float i = 100f;
        while (i<200f)
        {
            i += 5f;
            TextPanel.color = new Vector4(TextPanel.color.r, TextPanel.color.g, TextPanel.color.b, i / 255);
         //   Debug.Log("FadeIn A:" + TextPanel.color.a);
            yield return new WaitForSeconds(0.5f);
        }
        FadeSwitch ^= 1;
        StopCoroutine("FadeIn");
        yield return 0;
    }

    IEnumerator Fade()
    {
        float i = 200f;
        
        while (true)
        {
            if (FadeSwitch == 0)
            {
                i += 10f;
                if (i > 200)
                    FadeSwitch ^= 1;
            }
            if (FadeSwitch == 1)
            {
                i -= 10f;
                if (i < 100)
                    FadeSwitch ^= 1;
            }
            TextPanel.color = new Vector4(TextPanel.color.r, TextPanel.color.g, TextPanel.color.b, i / 255);
            yield return new WaitForSeconds(0.2f);
        }
        

        // yield return 0;
    }

}
