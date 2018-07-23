using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameD : MonoBehaviour
{

    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    int point = 0;

    GameObject gene;
    public void GetApple()
    {
        this.point += 100;
    }
    public void GetBomb()
    {
        this.point /= 2;
    }

    // Use this for initialization
    void Start()
    {
        this.gene = GameObject.Find("itemG");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;

        if(this.time<0)
        {
            this.time = 0;
            this.gene.GetComponent<itemG>().SetP(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 5)
        {
            this.gene.GetComponent<itemG>().SetP(0.001f, -0.04f, 3);
        }
        else if (5 <= this.time && this.time < 10)
        {
            this.gene.GetComponent<itemG>().SetP(0.4f, -0.06f, 6);
        }
        else if (10 <= this.time && this.time < 20)
        {
            this.gene.GetComponent<itemG>().SetP(0.7f, -0.04f, 4);
        }
        else if (20 <= this.time && this.time < 30)
        {
            this.gene.GetComponent<itemG>().SetP(1.0f, -0.03f, 2);
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + "Point";
    }
}
