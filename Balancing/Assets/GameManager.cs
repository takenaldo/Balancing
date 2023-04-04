using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public Text txtScore;
    public GameObject prefabParent;
    public GameObject BallPrefab;

    public GameObject DialogGameOver;
    public Text TxtDialogGameOverScore;
    [SerializeField] private float timerSpeed = 1f;
    private float lastTimeStamp;

    private int lastSpawnedat = -1;
    public int balls = 1;
    public int failedBalls = 0;

    public GameObject stick;

/*
    for circling game
 
 */
    public bool trialMoving = true;
    public int c_score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (isGameOver())
        {
            Debug.Log("Game Over");
            showGameOverDialog();
            removeUnnecessaryObjects();
        }
        else if (Time.time - lastTimeStamp >= timerSpeed)
        {
            lastTimeStamp = Time.time;
            score++;
            txtScore.text = score+"";
            if (score % 5 == 0 )
            {
                InstantiateWithParent(BallPrefab, prefabParent);
                balls++;
            }
        }
*/    
    }

    private void removeUnnecessaryObjects()
    {
        Destroy(stick);   
    }

    private void showGameOverDialog()
    {
        if(DialogGameOver.active == false)
        {
            DialogGameOver.SetActive(true);
            TxtDialogGameOverScore.text = "Score:"+score;
        }
    }

    public bool isGameOver()
    {
        return balls == failedBalls;
    }

    public void  SpawnBall()
    {
        Instantiate(BallPrefab);
    }

    public GameObject InstantiateWithParent(GameObject prefab, GameObject parent)
    {
        GameObject newGameObject = Instantiate(prefab, prefab.transform.position, Quaternion.identity) as GameObject;
        newGameObject.transform.SetParent(parent.transform, false);

        Rect rc = new Rect(
            getRandomXPosition(),
            newGameObject.GetComponent<RectTransform>().rect.y,
            newGameObject.GetComponent<RectTransform>().rect.width,
            newGameObject.GetComponent<RectTransform>().rect.height
            );

        //        newGameObject.GetComponent<RectTransform>().rect = rc;
        //newGameObject.transform.position = new Vector3(getRandomXPosition(), newGameObject.transform.position.y, newGameObject.transform.position.z);


        System.Random rr = new System.Random();
        float pos = (float)((float)rr.Next(-10, 10)) / 10f;
        Debug.Log("pos : "+pos);

        newGameObject.transform.position = new Vector3(newGameObject.transform.position.x + pos, newGameObject.transform.position.y, newGameObject.transform.position.z);


        return newGameObject;
    }

    private int getRandomXPosition()
    {
        float width = stick.GetComponent<RectTransform>().rect.width;
        System.Random rnd = new System.Random();
        int val = ((int)(width / 2) - 50) * -1;
        int randomXPos = rnd.Next(val, Math.Abs(val));
        Debug.Log("Random @ : " + randomXPos);
        return randomXPos;
    }
}
