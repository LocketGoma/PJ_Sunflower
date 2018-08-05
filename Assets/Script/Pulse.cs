using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulse : MonoBehaviour {
    Text TextPanel;
    int Fadeswitch;
    // Use this for initialization
    void Start () {
        TextPanel = gameObject.GetComponent<Text>();
        Fadeswitch = 1;
     //   Debug.Log("text");
     //   Debug.Log("A:" + TextPanel.color.a);

        StartCoroutine("Fade");
       // if (Fadeswitch == 1) StartCoroutine("FadeOut");
       // if (Fadeswitch == 0) StartCoroutine("FadeIn");
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
        Fadeswitch ^= 1;
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
        Fadeswitch ^= 1;
        StopCoroutine("FadeIn");
        yield return 0;
    }

    IEnumerator Fade()
    {
        float i = 200f;
        
        while (true)
        {
            if (Fadeswitch == 0)
            {
                i += 10f;
                if (i > 200)
                    Fadeswitch ^= 1;
            }
            if (Fadeswitch == 1)
            {
                i -= 10f;
                if (i < 100)
                    Fadeswitch ^= 1;
            }
            TextPanel.color = new Vector4(TextPanel.color.r, TextPanel.color.g, TextPanel.color.b, i / 255);
            yield return new WaitForSeconds(0.2f);
        }
        

        // yield return 0;
    }

}
