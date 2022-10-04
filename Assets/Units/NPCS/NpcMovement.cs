using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NpcMovement : MonoBehaviour
{    public Transform pathHolder;

    [SerializeField]private int speed = 1;
    private float waitTime = 1f;
    private Vector2 doorPosition;

    [SerializeField] int timeToWait=100;
    [SerializeField]Vector2 targetWaypoint;

    [SerializeField] Vector2[] waypoints;


    bool haveSit = false;


    void Start()
    {
        waypoints = new Vector2[pathHolder.childCount];
        for(int i =0; i<waypoints.Length; i++){
            waypoints[i] = pathHolder.GetChild(i).position;

        
        }

        StartCoroutine(walkTroughPath(waypoints));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator walkTroughPath( Vector2[] waypoints){
        transform.position = waypoints[0];
        int targetWaypointIndex = 1;
        targetWaypoint = waypoints[targetWaypointIndex];

        while(!haveSit){
            transform.position = Vector2.MoveTowards(transform.position,targetWaypoint,speed*Time.deltaTime);
            if(new Vector2(transform.position.x,transform.position.y) == targetWaypoint && targetWaypoint == waypoints.Last()){
                if(waypoints[targetWaypointIndex] == waypoints.Last()){
                    //gameObject.GetComponent<NpcInteraction>().canInteract=true;
                    haveSit=true; 
                    break;
                }
            }
            if(new Vector2(transform.position.x,transform.position.y) == targetWaypoint){
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
            }
            
            yield return null;
        }

    }
    private void OnDrawGizmos() {
        Vector2 startPosition = pathHolder.GetChild(0).position;
        Vector2 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder) { 
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        doorPosition = startPosition;
        //Gizmos.DrawLine(previousPosition, startPosition);
        Gizmos.DrawLine(previousPosition, doorPosition);
    }

    IEnumerator enterRestaurant(){

        yield return new WaitForSeconds(timeToWait);
        ExitRestaurant();
    }

    private void ExitRestaurant(){
        transform.position = Vector2.MoveTowards(transform.position,doorPosition, speed*Time.deltaTime);
        Destroy(gameObject);
    }
}
