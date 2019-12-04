using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICode : MonoBehaviour
{


    public Slider powerSlider;
    public Image sliderBg;
    public Image sliderBg2;

    [SerializeField]
    private Color maxColor;

    [SerializeField]
    private Color minColor;


    float timeFactor = 5f;
    float timeRemaining;

    float timeRemainingReverse;

    bool reverse;

    public bool pause;

    public static UICode instance = null;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeFactor;
        timeRemainingReverse = timeFactor;
        reverse = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {


        if (!pause)
        {
            powerSlider.value = timeRemaining / timeFactor;


            //Bottom to top
            if (reverse)
            {

                //1-0
                if (timeRemaining <= 0)
                {
                    timeRemaining = 0;
                    reverse = !reverse;
                }
                else if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;

                }



            }
            //Top to bottom
            else
            {


                timeRemaining += Time.deltaTime;


                if (timeRemaining >= timeFactor)
                {

                    reverse = !reverse;
                }


            }


        }


        sliderBg.color = Color.Lerp(minColor, maxColor, powerSlider.value);
        sliderBg2.color = sliderBg.color;


    }
}
