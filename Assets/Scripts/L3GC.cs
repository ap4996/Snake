using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L3GC : MonoBehaviour {

    public int mSize;
    public int cSize;
    public int xBound;
    public int yBound;
    public int score;
    public Text sValue;
    public GameObject foodPrefab;
    public GameObject cFood;
    public GameObject snakePrefab;
    public Snake head;
    public Snake tail;
    public int NESW;
    public Vector2 nextPos;
    public float deltaTimer;
    public Swipe swipeControl;
    int noOfWins;
    private void OnEnable()
    {
        Snake.hit += Hit;
    }

    // Use this for initialization
    void Start()
    {
        sValue.text = score.ToString();
        InvokeRepeating("TimerInvoke", 0, deltaTimer);
        //FoodFunction();

    }

    private void OnDisable()
    {
        Snake.hit -= Hit;
    }

    // Update is called once per frame
    void Update()
    {

        DirectionsK();
        DirectionsS();

    }

    void TimerInvoke()
    {
        Movement();
        //StartCoroutine(CheckVisible());
        if (cSize == mSize)
        {
            TailFunction();
        }
        else
        {
            ++cSize;
        }
    }

    void Movement()
    {
        GameObject temp;
        nextPos = head.transform.position;
        switch (NESW)
        {
            case 0:
                nextPos = new Vector2(nextPos.x, nextPos.y + 1);
                break;
            case 1:
                nextPos = new Vector2(nextPos.x + 1, nextPos.y);
                break;
            case 2:
                nextPos = new Vector2(nextPos.x, nextPos.y - 1);
                break;
            case 3:
                nextPos = new Vector2(nextPos.x - 1, nextPos.y);
                break;
        }
        temp = (GameObject)Instantiate(snakePrefab, nextPos, transform.rotation);
        head.Setnext(temp.GetComponent<Snake>());
        head = temp.GetComponent<Snake>();
        return;
    }

    void DirectionsK()
    {
        if (NESW != 0 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            NESW = 2;
        }
        if (NESW != 1 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            NESW = 3;
        }
        if (NESW != 2 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            NESW = 0;
        }
        if (NESW != 3 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            NESW = 1;
        }
    }

    void DirectionsS()
    {
        if (NESW != 0 && swipeControl.SwipeDown)
        {
            NESW = 2;
        }
        if (NESW != 1 && swipeControl.SwipeLeft)
        {
            NESW = 3;
        }
        if (NESW != 2 && swipeControl.SwipeUp)
        {
            NESW = 0;
        }
        if (NESW != 3 && swipeControl.SwipeRight)
        {
            NESW = 1;
        }
    }

    public void DirectionsM(int dir)
    {
        if (NESW != 0 && dir == 2)
        {
            NESW = dir;
        }
        if (NESW != 1 && dir == 3)
        {
            NESW = dir;
        }
        if (NESW != 2 && dir == 0)
        {
            NESW = dir;
        }
        if (NESW != 3 && dir == 1)
        {
            NESW = dir;
        }
    }

    void TailFunction()
    {
        Snake tempSnake = tail;
        tail = tail.Getnext();
        tempSnake.RemoveTail();
    }

    void FoodFunction()
    {
        int xPos = Random.Range(-xBound, xBound);
        int yPos = Random.Range(-6, 13);
        //int yPos = Random.Range(-yBound, yBound);

        cFood = (GameObject)Instantiate(foodPrefab, new Vector2(xPos, yPos), transform.rotation);
        StartCoroutine(CheckRender(cFood));
    }

    IEnumerator CheckRender(GameObject IN)
    {
        yield return new WaitForEndOfFrame();
        if (IN.GetComponent<Renderer>().isVisible == false)
        {
            if (IN.tag == "Food")
            {
                Destroy(IN);
                FoodFunction();
            }
        }
    }

    void Hit(string WhatWasSent)
    {
        if (WhatWasSent == "Food")
        {
            /*if (deltaTimer >= 0.1f)
            {
                deltaTimer -= 0.04f;
                CancelInvoke("TimerInvoke");
                InvokeRepeating("TimerInvoke", 0, deltaTimer);
            }*/
            FoodFunction();
            ++mSize;
            ++score;
            sValue.text = score.ToString();
            noOfWins = PlayerPrefs.GetInt("Wins");
            /*int temp = PlayerPrefs.GetInt("HighScore");
            if (score > temp)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }*/
            if (score == 10)
            {
                noOfWins = noOfWins + 1;
                Winner();
            }
        }
        if (WhatWasSent == "Snake" || head.transform.position.y >= 15 || head.transform.position.y <= -9 || head.transform.position.x >= 11 || head.transform.position.x <= -11)
        {
            CancelInvoke("TimerInvoke");
            Exit();
        }
        if (WhatWasSent == "Border")
        {
            CancelInvoke("TimerInvoke");
            Exit();
        }
    }

    public void Winner()
    {
        PlayerPrefs.SetInt("Wins", noOfWins);
        SceneManager.LoadScene("Winner");
    }

    public void Exit()
    {
        //PlayerPrefs.SetInt("LastScore", score);
        SceneManager.LoadScene("GameOver");
    }

    public void QuitScene()
    {
        //PlayerPrefs.SetInt("LastScore", score);
        SceneManager.LoadScene("MainMenu");
    }

    /*void HWrap()
    {
        if (NESW == 1)
        {
            head.transform.position = new Vector2(-(head.transform.position.x - 1), head.transform.position.y);
        }
        else if (NESW == 3)
        {
            head.transform.position = new Vector2(-(head.transform.position.x + 1), head.transform.position.y);
        }
    }

    void VWrap()
    {
        if (NESW == 0)
        {
            head.transform.position = new Vector2(head.transform.position.x, -8);
            head.transform.position = new Vector2(head.transform.position.x, head.transform.position.y + 1);
        }
        else if (NESW == 2)
        {
            head.transform.position = new Vector2(head.transform.position.x, 16);
            head.transform.position = new Vector2(head.transform.position.x, head.transform.position.y - 1);
        }
    }

    IEnumerator CheckVisible()
    {
        yield return new WaitForEndOfFrame();
        if (head.GetComponent<Renderer>().isVisible == false)
        {
            HWrap();
        }
        if (head.transform.position.y > 14 || head.transform.position.y < -6)
        {
            VWrap();
        }
    }*/
}
