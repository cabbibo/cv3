using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToRay : MonoBehaviour {


  public Vector3 RayOrigin;
  public Vector3 RayDirection;
  public float Down;
  public float JustDown;
  // Use this for initialization

  public Vector2 p; 
  public Vector2 oP; 
  public Vector2 vel;

  public int touchID = 0;

  void Start(){}
  
   // Update is called once per frame
  void FixedUpdate () {

    oP = p;

    #if UNITY_EDITOR  
      if (Input.GetMouseButton (0)) {

        if( Input.GetMouseButtonDown(0) ){
          JustDown = 1;
          touchID ++;
        }else{
          JustDown = 0;
        }
        Down = 1;
        p  =  Input.mousePosition;///Input.GetTouch(0).position;
      }else{
        Down = 0;
        oP = p;
      }
    #else
      if (Input.touchCount > 0 ){

        if( Input.GetTouch(0).phase == TouchPhase.Began ){
          JustDown = 1;
          touchID ++;
        }else{
          JustDown = 0;
        }
        
        Down = 1;
        p  =  Input.GetTouch(0).position;
      }else{
        Down = 0;
        oP = p;
      }
    #endif

      if( JustDown == 1 ){ oP = p; }
      vel = p - oP;

    RayOrigin = Camera.main.ScreenToWorldPoint( new Vector3( p.x , p.y , Camera.main.nearClipPlane ) );
    RayDirection = (Camera.main.transform.position - RayOrigin).normalized;

  }


}