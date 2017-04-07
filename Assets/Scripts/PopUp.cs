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
	public string msg;
	public float height;
	public float weight;
    // Use this for initialization
    void Start()
    {
        nearPopUp = false;
        popUpOpen = false;
        player = null;
        newGO = new GameObject("myTextGO");

        text = newGO.AddComponent<Text>();
        text.text = msg;
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;
		text.fontSize = 20;
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
					RectTransform tr = newGO.GetComponent<RectTransform> ();
					tr.anchoredPosition = new Vector3 (0.0f, 0.0f, 0.0f);
					tr.sizeDelta = new Vector2(height, weight);
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
