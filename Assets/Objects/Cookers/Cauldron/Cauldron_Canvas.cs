using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron_Canvas : MonoBehaviour
{
    [SerializeField]private bool isNearby = false; 
    private GameObject behindBox;
    [SerializeField]private new BoxCollider2D collider2D;
    public GameObject[] circles;
    public Slider slider; 
    private float progressTime = 0f;
    public bool isActive = false;
    void Start()
    {
        behindBox = transform.GetChild(0).transform.gameObject;
        behindBox.SetActive(false);
        slider = transform.GetChild(1).transform.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive){
            slider.value+=progressTime * Time.deltaTime;
        }
        if(isNearby &&!isActive){
            isNearbyActivate();
        }
        
    }
    private void IncreamentSlider(float num){
        progressTime += num;
    }

    public void activateCanvas()
    {
        isActive=true;
    }
    public void isNearbyActivate(){
        behindBox.SetActive(true);
        LeanTween.scale(behindBox, new Vector3(2.909375f, 0.8564063f, 1), 0.3f);
    }
    public IEnumerator desactivateCanvas()
    {
        if(!isActive){
            LeanTween.scale(behindBox, new Vector3(0.45f, 0.2f, 1), 0.25f);
            yield return new WaitForSeconds(0.3f);
            behindBox.SetActive(false);
        }
    }

    public void setSprite(GameObject[] ingredients){
        var loop = 0;
        isActive = true;
        slider.maxValue=0;
        foreach (var i in ingredients){
            if(i!=null){
                circles[loop].GetComponent<SpriteRenderer>().sprite = i.GetComponent<SpriteRenderer>().sprite;
                slider.maxValue+=i.GetComponent<IngredientData>().getCookTime();
                loop++;
            }
        }
    }
    public void setNearbyBool(bool b){
        if(isNearby && b==false && isActive==false){
            StartCoroutine(desactivateCanvas());
        }
        isNearby=b;
    }

    public void setSlide(int currentTime, int maxtime){
        slider.value = currentTime;
        slider.maxValue=maxtime;
    }
    
}
