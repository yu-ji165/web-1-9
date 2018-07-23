using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemG : MonoBehaviour
{

    public GameObject appleP;
    public GameObject bombP;
    float spin = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.05f;

    public void SetP(float spin,float speed,int ratio)
    {
        this.spin = spin;
        this.speed = speed;
        this.ratio = ratio;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta >= this.spin)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= this.ratio)
            {
                item = Instantiate(bombP) as GameObject;
            }
            else
            {
                item = Instantiate(appleP) as GameObject;
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<itemC>().dropSpeed = this.speed;
        }
    }
}
