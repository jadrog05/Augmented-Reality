using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnManagerScript : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public Transform[] spawnPoints;
    public GameObject[] balloons;
    public GameObject[] Questions;
    public GameObject selectPlaneText;
    public GameObject planeSelectedText;
    public GameObject gameOverText;
    public GameObject shootButton;
    public bool planeSelected = false;



    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();

    private void Start()
    {
        selectPlaneText.SetActive(true);
    }

    void Update()
    {
        if (Input.touchCount > 0 && planeSelected == false)
        {

            // use var not Touch touch = Input.GetTouch(0);
            var touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    Debug.Log("Touch Detected");
                    //Rraycast Planes
                    //Instantiate(balloons[1], spawnPoints[1].position, Quaternion.identity);
                    Debug.Log(touch.position);
                    if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                    {
                        Debug.Log("Success");
                        var pose = arRaycastHits[0].pose;
                        moveSpawns(pose.position);
                        selectPlaneText.SetActive(false);
                        planeSelectedText.SetActive(true);
                        planeSelected = true;
                        return;
                    }
                }
            }
        }
    }

    public void moveSpawns(Vector3 spawnPosition)
    {
        Vector3 position = spawnPosition;
        position[2] = position[2] - 0.5f;
        Vector3 leftSpawn = position;
        position[2] = position[2] + 1f;
        Vector3 rightSpawn = position;

        Debug.Log(spawnPoints[0].position);
        spawnPoints[0].position = leftSpawn;
        Debug.Log(spawnPoints[0].position);
        spawnPoints[1].position = spawnPosition;
        spawnPoints[2].position = rightSpawn;

        StartCoroutine(nextQuestion(0));
    }


    public IEnumerator startSpawn()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(balloons[i], spawnPoints[i].position, Quaternion.identity);
        }
    }



    public IEnumerator nextQuestion(int currentQuestion)
    {
        yield return new WaitForSeconds(3);
        planeSelectedText.SetActive(false);

        for (int j = 0; j < Questions.Length; j++)
        {
            shootButton.SetActive(true);
            if (Questions.Length > currentQuestion)
            {
                currentQuestion = currentQuestion + 1;

                for (int i = 0; i < Questions.Length; i++)
                {

                    Questions[i].SetActive(false);
                }
                Questions[currentQuestion - 1].SetActive(true);
                StartCoroutine(startSpawn());
            }
            yield return new WaitForSeconds(20);
        }

        gameOver();

    }

    public void gameOver()
    {
        Questions[Questions.Length - 1].SetActive(false);
        gameOverText.SetActive(true);
    }

}
