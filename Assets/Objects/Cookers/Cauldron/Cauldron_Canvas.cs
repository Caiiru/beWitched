using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Canvas : MonoBehaviour
{
    [SerializeField]private bool isNearby = false; 
    private GameObject behindBox;
    [SerializeField]private BoxCollider2D collider2D;
    void Start()
    {
        behindBox = transform.GetChild(0).transform.gameObject;
        behindBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateCanvas()
    {
        if (!isNearby)
        {
            isNearby = true;
            behindBox.SetActive(true);
            LeanTween.scale(behindBox, new Vector3(2.909375f, 0.8564063f, 1), 0.3f);

        }
    }
    public IEnumerator desactivateCanvas()
    {
        if (isNearby)
        {
            isNearby = false;
            LeanTween.scale(behindBox, new Vector3(0.45f, 0.2f, 1), 0.25f);
            yield return new WaitForSeconds(0.3f);
            behindBox.SetActive(false);

        }
    }
    
}
