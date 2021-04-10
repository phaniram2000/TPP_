using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] GameObject focalpoint_obj;
    [SerializeField] KeyCode FocalSwitch;
    [SerializeField] private float FocalDistance; 
    [Range (1f,7f)] [SerializeField] public float smooth_focal_swift;
    private bool isfocalpoitonleft = true;
    [SerializeField] private Camera Gamecamera;
    //[SerializeField] float viewing_distance;
    //[SerializeField] KeyCode intractionKey;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(FocalSwitch))
        {
            isfocalpoitonleft = !isfocalpoitonleft;
        }
        float targetx = FocalDistance * (isfocalpoitonleft ? -1 : 1);
        float smooth = Mathf.Lerp(focalpoint_obj.transform.localPosition.x, targetx, smooth_focal_swift * Time.deltaTime);
        focalpoint_obj.transform.localPosition = new Vector3(smooth, focalpoint_obj.transform.localPosition.y, focalpoint_obj.transform.localPosition.z);
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        //Debug.DrawLine(Gamecamera.transform.position, Gamecamera.transform.position + Gamecamera.transform.forward * viewing_distance, Color.green);
#endif
        //RaycastHit hit;
        //if (Input.GetKey(intractionKey))
        //{
        //    if (Physics.Raycast(Gamecamera.transform.position, gameObject.transform.forward, out hit, viewing_distance))
        //    {
        //       if(hit.transform.GetComponent<door>())
        //        {
        //            hit.transform.GetComponent<door>().intraction();
        //            Debug.Log(hit.transform.name);
        //        }
        //        Debug.Log(hit.transform.name);
        //    }
        //}
    }



}
