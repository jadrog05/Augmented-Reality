using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject smoke;
    public GameObject shootButton;
    public Text ScoreNum;
    private int score;
    private int currentQuestion;


    void start()
    {
        score = 0;
        currentQuestion = 1;
        ScoreNum.text = score.ToString();
        
    }


    public void shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {   
            if ((hit.transform.name == "balloon1(Clone)") || (hit.transform.name == "balloon2(Clone)") || (hit.transform.name == "balloon3(Clone)"))
            {
                Debug.Log(currentQuestion);
                checkAnswer(hit.transform.name);
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                shootButton.SetActive(false);
            }
        }
    }

    public void checkAnswer(string balloon)
    {
        if ((currentQuestion == 0) && (balloon == "balloon3(Clone)"))
        {
            score = score + 1;
        }
        else if ((currentQuestion == 1) && (balloon == "balloon1(Clone)"))
        {
            score = score + 1;
        }
        else if ((currentQuestion == 2) && (balloon == "balloon2(Clone)"))
        {
            score = score + 1;
        }

        currentQuestion++;
        ScoreNum.text = score.ToString();
    }



    private void Update()
    {

    }


}
