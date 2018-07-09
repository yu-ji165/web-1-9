using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasC : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource and;
    GameObject director;
    // Use this for initialization
    void Start()
    {
        this.director = GameObject.Find("GameD");
        this.and = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            this.director.GetComponent<GameD>().GetApple();
            this.and.PlayOneShot(this.appleSE);
        }
        else
        {
            this.director.GetComponent<GameD>().GetBomb();
            this.and.PlayOneShot(this.bombSE);
        }
        //Debug.Log("キャッチ！");
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }

    }
}
