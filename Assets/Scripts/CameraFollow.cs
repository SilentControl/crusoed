using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    private Camera cam;
    public float moveSpeed;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        moveSpeed = 5f;
	}

    public static float RoundToNearestPixel(float unityUnits, Camera viewingCamera)
    {
        float valueInPixels = (Screen.height / (viewingCamera.orthographicSize * 2)) * unityUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float adjustedUnityUnits = valueInPixels / (Screen.height / (viewingCamera.orthographicSize * 2));
        return adjustedUnityUnits;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
         cam.orthographicSize = (Screen.height / 32f) / 2f;

        // if (target)
        // {
            //Vector3 interp = Vector3.Lerp(transform.position, new Vector3(RoundToNearestPixel(target.position.x, cam), RoundToNearestPixel(target.position.y, cam)), moveSpeed);
            //Vector3 interp = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);// + new Vector3(0, 0, -550);
            // Vector2 test = Vector2.MoveTowards(transform.position, target.position, 0.1f);
            // transform.position = new Vector3(test.x, test.y, -10f);
             //interp.z = -10;
            // this.transform.position = interp;
         //}
    
        if (target)
        {
            Vector3 roundPos = new Vector3(RoundToNearestPixel(target.position.x, cam), RoundToNearestPixel(target.position.y, cam), -10f);
            transform.position = roundPos;
        }
    }
}
