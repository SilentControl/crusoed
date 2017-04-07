using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUp : MonoBehaviour
{
    public bool nearPopUp;
    public bool popUpOpen;
    public Collider2D player;
    Text text;
    GameObject newGO;
    GameObject canvas;
    // Use this for initialization
    void Start()
    {
        nearPopUp = false;
        popUpOpen = false;
        player = null;
        newGO = new GameObject("myTextGO");
        text = newGO.AddComponent<Text>();
        text.text = "Welcome to Plain Island!";
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;
        newGO.transform.position = new Vector3(0.0f, -100.0f, 0.0f);
        canvas = GameObject.Find("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (popUpOpen == false && player != null)
            {
                if (nearPopUp == true)
                {
                    popUpOpen = true;

                    newGO.transform.SetParent(canvas.transform);
                    newGO.transform.position = new Vector3(0.0f, -100.0f, 0.0f);

                }
            }

            else
            if (popUpOpen == true)
            {
                popUpOpen = false;
                newGO.transform.parent = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearPopUp = true;
            player = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearPopUp = true;
            player = null;
        }
    }
}
