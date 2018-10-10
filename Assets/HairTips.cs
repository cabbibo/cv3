using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class HairTips : LifeForm {



  public float size;
 
  public Hair Hair;
  public Form Base;

  public Life FlowerTransfer;

  public IndexForm FlowerTriangles;
  public Form FlowerVerts;

  public Body body;

  public float[] transformArray;

  public override void Create(){

    
    /*  
      All of this info should be visualizable!
    */

    Lifes.Add( FlowerTransfer );

    Forms.Add( FlowerVerts );
    Forms.Add( FlowerTriangles );


    FlowerTransfer._Create();
    FlowerVerts._Create( Base );
    FlowerTriangles._Create( FlowerVerts );



    FlowerTransfer.BindPrimaryForm("_VertBuffer", FlowerVerts );
    FlowerTransfer.BindForm("_HairBuffer", Hair);

    FlowerTransfer.BindAttribute( "_NumVertsPerHair" , "numVertsPerHair", Hair );
    FlowerTransfer.BindAttribute( "_Size"  , "size", this );



  }

  public override void OnGestate(){


    FlowerTriangles._OnGestate( Hair );
    FlowerVerts._OnGestate( Hair );

    body._Create( FlowerVerts , FlowerTriangles );

  }


  public override void OnBirth(){
    body.Show();
  }

  public override void WhileLiving(float v){
    FlowerTransfer.Live();
    body.WhileLiving(1);
  }

  public override void WhileDebug(){}


  public override void Activate(){
    Active = true;
    body.Show();
  }

  public override void Deactivate(){
    body.Hide();
    Active = false;
  }


}