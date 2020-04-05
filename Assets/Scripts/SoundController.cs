using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public GameObject cameraTarget;
    public NavigationController NavCon;
    public Transform Target;
    public Text text;
    private bool goStraight = false;
    private bool fiveFeetLeft = false;
    private bool tenFeetLeft = false;
    private bool turnLeft = false;
    private bool goStraight2 = false;
    private bool destinationLeft = false;
    private bool turnLeftStraight = false;
    private bool turnRightFive = false;
    private bool turnRight = false;
    private bool goStraight3 = false;
    private bool destinationTen = false;
    private bool destinationRight = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        Target = NavCon.target;

        if (Vector3.Distance(cameraTarget.transform.position, NavCon.target.position) < 1f)
        {
            text.text = "Reached Destination!";
            FindObjectOfType<AudioManager>().Play("reached");

        }
        //if (cameraTarget.transform.position.z >= 7.5f && cameraTarget.transform.position.z <= 7.9f
        //    && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
        //{
        //    if (!goStraight)
        //    {
        //        Debug.Log("Go Straight Reached!");
        //        FindObjectOfType<AudioManager>().Play("GoStraight");
        //        goStraight = true;
        //    }
        //}

        //if (cameraTarget.transform.position.z >= 11.5f && cameraTarget.transform.position.z <= 12.0f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
        //{
        //    if (!tenFeetLeft)
        //    {
        //        FindObjectOfType<AudioManager>().Play("TenFeetLeft");
        //        tenFeetLeft = true;
        //    }
        //}

        //if (cameraTarget.transform.position.z >= 14.2f && cameraTarget.transform.position.z <= 14.8f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
        //{
        //    if (!fiveFeetLeft)
        //    {
        //        FindObjectOfType<AudioManager>().Play("FiveFeetLeft");
        //        fiveFeetLeft = true;
        //    }
        //}

        //if (cameraTarget.transform.position.z >= 16.5f && cameraTarget.transform.position.z <= 17.1f && cameraTarget.transform.position.x >= 9.5f && cameraTarget.transform.position.x <= 11.5f)
        //{
        //    if (!turnLeft)
        //    {
        //        FindObjectOfType<AudioManager>().Play("TurnLeftNow");
        //        turnLeft = true;
        //    }
        //}

        //if (cameraTarget.transform.position.x >= 8.5f && cameraTarget.transform.position.x <= 9.0f && cameraTarget.transform.position.z >= 15.0f && cameraTarget.transform.position.z <= 18.0f)
        //{
        //    if (!goStraight2)
        //    {
        //        FindObjectOfType<AudioManager>().Play("GoStraight");
        //        goStraight2 = true;
        //    }
        //}

        //if (cameraTarget.transform.position.x >= 5.0f && cameraTarget.transform.position.x <= 5.5f && cameraTarget.transform.position.z >= 15.0f && cameraTarget.transform.position.z <= 18.0f)
        //{
        //    if (!destinationLeft)
        //    {
        //        FindObjectOfType<AudioManager>().Play("DestinationOnTheLeft");
        //        destinationLeft = true;
        //    }
        //}
    }
}
