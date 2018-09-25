using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceModel : MonoBehaviour {

  public GameObject model;
  public GameObject sphere1;
  public GameObject sphere2;
  public GameObject sphereRepresent1;
  public GameObject sphereRepresent2;
  public Vector3 p1;
  public Vector3 p2;

  public int sphereID;
	// Use this for initialization
	void Start () {
		  EventManager.OnGripDown += PlaceSphere;
	}

  void PlaceSphere( GameObject t ){
    if( sphereID == 0 ){
      sphereID = 1;
      p1 = t.transform.position;
      sphereRepresent1.transform.position = p1;
    }else{
      sphereID = 0;
      p2 = t.transform.position;
      sphereRepresent2.transform.position = p2;
      ScaleModel();
    }


  }

  void ScaleModel(){

    Vector3 t = p1 - sphere1.transform.position;
    Quaternion r = new Quaternion();
    r.SetFromToRotation( (sphere1.transform.localPosition-sphere2.transform.localPosition).normalized , (p1-p2).normalized );
    float s  = (p1-p2).magnitude / (sphere1.transform.localPosition-sphere2.transform.localPosition).magnitude ;

    Matrix4x4 m = Matrix4x4.identity;
//    m.SetRotation( r );






    Matrix4x4 newM = m * model.transform.localToWorldMatrix;
    model.transform.position = p1 - (r*sphere1.transform.localPosition )*s;// * scale; ///newM.MultiplyPoint( new Vector3(0,0,0));
    model.transform.rotation = r;
    //model.transform.rotation = newM.rotation;
    model.transform.localScale = new Vector3(s,s,s);// newM.lossyScale;

  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
