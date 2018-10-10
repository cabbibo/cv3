using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSwitcher : MonoBehaviour {

  public PlaceParticlesOnMesh[] faces;

  public int activeFace;


	// Use this for initialization
	void Start () {

    SwitchFace();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void Switch(float val){
    if( val < 0){
      activeFace -= 1;
      if( activeFace < 0 ){ activeFace = faces.Length-1;}

    }else{
      activeFace += 1;
      activeFace %= faces.Length;
    }

    SwitchFace();
  }

  void SwitchFace(){
    
    for( int i = 0; i < faces.Length; i++ ){
      faces[i].Deactivate();
    }

    faces[activeFace].Activate();

  }
}
