using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class  Gameplay : MonoBehaviour
{
    bool holdingBall;
    public float returnTimer;

    public Camera mainCam;
    public Text scoreText;
    public int score;

    public Text multiplierLabel;

    int multiplier;

    public GameObject arm;

    public bool canThrow;

    public float power;

    float throwTimer;

    public AudioSource goal;

    public Text throwLabel;

    bool justScored;

 
    public static Gameplay instance = null; 

    // Start is called before the first frame update
    void Start()
    {
        canThrow = false;
        score = 0;
        holdingBall = true;
        this.transform.position = mainCam.transform.position;
        instance = this;
        throwTimer = 2;
  
    }

    // Update is called once per frame
    void Update()
    {


       
        if (holdingBall == false)
        {
           returnTimer -= Time.deltaTime;

        }


        if (!canThrow)
        {
            throwLabel.text = "Hold arm up for 3 seconds to initiate throw";
            throwLabel.color = Color.red;
        }

        if (holdingBall)
        {

            if (arm.transform.rotation.eulerAngles.x >= 270 && arm.transform.rotation.eulerAngles.x <= 300)
            {

                

                throwTimer -= Time.deltaTime;


                if (throwTimer <= 0)
                {
                    canThrow = true;
                   
                }




            }


        }



        if (holdingBall && canThrow)
        {

            throwLabel.text = "You can throw!";
            throwLabel.color = Color.green;

            if (arm.transform.rotation.eulerAngles.x >= 0 && arm.transform.rotation.eulerAngles.x <= 30)
            {
                power = UICode.instance.powerSlider.value * 400;
                canThrow = false;
                throwTimer = 2;
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().AddForce(mainCam.transform.forward * power);
                holdingBall = false;
                UICode.instance.pause = true;


            }



        }


        if (returnTimer <= 0 && holdingBall == false)
        {

            //check if the player scored for multiplier chain
            if(justScored == true)
            {
                multiplier++;
            }
            if(justScored == false)
            {
                multiplier = 1;
            }

            multiplierLabel.text = multiplier.ToString();

            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.transform.position = mainCam.transform.position;
            this.GetComponent<Rigidbody>().useGravity = false;
            returnTimer = 3;
            holdingBall = true;
            UICode.instance.pause = false;
            justScored = false;


        }

    }




    public void OnTriggerExit(Collider collision)
    {


        if (collision.gameObject.name == "Score")
        {
            justScored = true;
            score = score + (1 * multiplier);
            scoreText.text = score.ToString();
            goal.Play();
         



        }



    }



}
