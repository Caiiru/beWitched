using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[RequireComponent(typeof(playerMovement))]
[RequireComponent(typeof(playerInputs))]
public class playerInteraction : MonoBehaviour
{
    private float interactRange = 1f;
    [SerializeField] GameObject detectedGameObject;
    public LayerMask interactLayerMask;

    Vector2 directionBuffer;
    playerMovement playerMovement;
    playerInputs playerInputs;
    public bool canInteract;
    public Transform grabPoint;
    public bool isHolding;

    public List<GameObject> checkedObjects = new List<GameObject>();
    public List<GameObject> sortedList = new List<GameObject>();
    
    void Start()
    {
        playerMovement = GetComponent<playerMovement>();
        playerInputs = GetComponent<playerInputs>();
        canInteract=true;
        isHolding= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.getPosition() != Vector2.zero){
            directionBuffer = playerMovement.getPosition();
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

        if(playerInputs.interactInput())
            checkFront();

    }
    void checkFront(){
        checkedObjects.Clear();
        var hit = Physics2D.RaycastAll(transform.position,directionBuffer, interactRange, interactLayerMask);
        foreach(var item in (hit)){
            if(item.transform.GetComponent<BaseItem>() != null){
                detectedGameObject = item.transform.gameObject;
                checkedObjects.Add(detectedGameObject);
                //item.transform.GetComponent<BaseItem>().Interact(this.gameObject);
            }
        }
        sortedList = checkedObjects.OrderBy(o => o.GetComponent<ItensPriority>().InteractPriority).ToList();
        foreach(var item in ( sortedList)){
                item.transform.GetComponent<BaseItem>().Interact(this.gameObject);
        }

    }


     private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + directionBuffer * interactRange);
    }

    public GameObject getDetectedObject(){
        return detectedGameObject;
    }
    public GameObject returnFirstFood(){
        foreach(var item in (sortedList)){
            if(item.GetComponent<Ingredient>()){
                return item;
            }
        }
        return null;
    }
}
