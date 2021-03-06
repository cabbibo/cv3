﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



[System.Serializable]
public class Vector2Event : UnityEvent<Vector2>{}

[System.Serializable]
public class Vector3Event : UnityEvent<Vector3>{}

[System.Serializable]
public class FloatEvent : UnityEvent<float>{}

public class TouchToRay : MonoBehaviour {

  public Vector2Event OnSwipe;
  public FloatEvent OnSwipeHorizontal;
  public UnityEvent OnSwipeLeft;
  public UnityEvent OnSwipeRight;
  

  public Vector3 RayOrigin;
  public Vector3 RayDirection;
  public float Down;
  public float oDown;
  public float JustDown;
  public float JustUp;
  public Vector2 startPos;
  public Vector2 endPos;

  public float startTime;
  public float endTime;
  // Use this for initialization

  public Vector2 p; 
  public Vector2 oP; 
  public Vector2 vel;

  public int touchID = 0;

  void Start(){}
  
   // Update is called once per frame
  void FixedUpdate () {

    oP = p;
    oDown = Down;

    #if UNITY_EDITOR  
      if (Input.GetMouseButton (0)) {
        Down = 1;
        p  =  Input.mousePosition;///Input.GetTouch(0).position;
      }else{
        Down = 0;
        oP = p;
      }
    #else
      if (Input.touchCount > 0 ){
        Down = 1;
        p  =  Input.GetTouch(0).position;
      }else{
        Down = 0;
        oP = p;
      }
    #endif

      if( Down == 1 && oDown == 0 ){
          JustDown = 1;
          touchID ++;
          startTime = Time.time;
          startPos = p;
      }

      if( Down == 1 && oDown == 1 ){
        JustDown = 0;
      }


      if( Down == 0 && oDown == 1 ){
        JustUp = 1;
        endTime = Time.time;
        endPos = p;
        OnUp();
      }      

      if( Down == 0 && oDown == 0 ){
        JustDown = 0;
      }

      if( JustDown == 1 ){ oP = p; }
      vel = p - oP;

    RayOrigin = Camera.main.ScreenToWorldPoint( new Vector3( p.x , p.y , Camera.main.nearClipPlane ) );
    RayDirection = (Camera.main.transform.position - RayOrigin).normalized;






  }

  void OnUp(){
    float difT = endTime - startTime;
    Vector2 difP = endPos - startPos;


    float ratio = .01f * difP.magnitude / difT;

    if( ratio > 3 ){
      
      OnSwipe.Invoke( difP );  
     if( Mathf.Abs(difP.x) > Mathf.Abs(difP.y) ){
        OnSwipeHorizontal.Invoke(difP.x);
        if( difP.x < 0 ){
          OnSwipeLeft.Invoke();
        }else{
          OnSwipeRight.Invoke();
        }
     } 
    }


   //print( difT );
   //print( difP );
   //print( ratio );
  }


}