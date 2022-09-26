using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHold : MonoBehaviour
{
    private playerInteraction interaction;
    private playerMovement playerMovement;
    [SerializeField]private bool isHolding=false;
    [SerializeField]private Transform grabPoint;
    [SerializeField]private GameObject holdedObject;
    void Start()
    {
        playerMovement=GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.getPosition()!= Vector2.zero){
             if(playerMovement.getPosition().x < 0){
                grabPoint.transform.localRotation= new Quaternion(0,0,180,0);
                grabPoint.transform.localPosition = new Vector2(-0.3f,0);

            }
            else if(playerMovement.getPosition().x>0){
                grabPoint.transform.localScale = new Vector2(1,1);
                grabPoint.transform.localRotation= new Quaternion(0,0,0,0);
                grabPoint.transform.localPosition = new Vector2(0.3f,0);
            }
        }

        if(isHolding){
            holdedObject.transform.position = grabPoint.position;
        }
    }
    public void Hold(GameObject go){
        holdedObject=go;
        isHolding=true;
    }
    public void unHold(){
        isHolding=false;
        holdedObject=null;
    }

    public GameObject GetHoldObject(){
        return holdedObject;
    }
    public bool getIsHolding(){
        return isHolding;
    }
    public Vector2 getGrabPoint(){
        return grabPoint.position;
    }
}
