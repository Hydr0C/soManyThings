using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class carButton : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GraphicRaycaster gRaycaster;

    private PointerEventData pData;

    //event to change acceleration
    public delegate void ChangeAccel(float accel);
    public static ChangeAccel changeAccelEvent;

    private Image buttonSprite;

    //how goo acel be
    [SerializeField] private float accelRate;

    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent<Image>(out buttonSprite))
        {
            Debug.Log("Need iamge");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MouseInteraction();
        }    

    }

    private void MouseInteraction()
    {
        //init new pdata event
        pData = new PointerEventData(eventSystem);

        //assign new mouse pos to pdata
        pData.position = Input.mousePosition;

        //init a list of racast results
        List<RaycastResult> results = new List<RaycastResult>();

        //do a raycast
        gRaycaster.Raycast(pData, results);

        foreach(RaycastResult result in results)
        {
            //perform graphics rasycast from pointer pos
            if(result.gameObject.tag =="FowardButt")
            {
                //if it accel button, increase accel
                changeAccelEvent(accelRate);
                buttonSprite.color = Color.yellow;
            }
            else if (result.gameObject.tag =="ReverseButt")
            {
                //if decel, decrease accel
                changeAccelEvent(-accelRate);
                buttonSprite.color = Color.red;
            }
            else
            {
                buttonSprite.color = Color.black;
            }
        }
        
    }
}
