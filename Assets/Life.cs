using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Life : Cycle {

  [HideInInspector] public string primaryName;
  [HideInInspector] public Form primaryForm;
  public ComputeShader shader;
  public string kernelName;
  [HideInInspector] public int kernel;
  [HideInInspector] public float executionTime;

  public Dictionary<string, Form> boundForms;
  public Dictionary<string, int> boundInts;

  protected bool allBuffersSet;
  protected int numGroups;
  protected uint numThreads;


  public delegate void SetValues(ComputeShader shader, int kernel);
  public event SetValues OnSetValues;

  public override void Create(){
     boundForms = new Dictionary<string, Form>();
     boundInts = new Dictionary<string, int>();
     FindKernel();
     GetNumThreads();
     OnCreate();
  }

  public virtual void OnCreate(){}


  public virtual void FindKernel(){
    kernel = shader.FindKernel( kernelName );
  }

  public virtual void GetNumThreads(){
    uint y; uint z;
    shader.GetKernelThreadGroupSizes(kernel, out numThreads , out y, out z);
  }

  public virtual void GetNumGroups(){
    numGroups = (primaryForm.count+((int)numThreads-1))/(int)numThreads;
  }
 
  public void BindForm( string name , Form form ){
    boundForms.Add( name ,form );
  }

   public void BindInt( string name , int form ){
    boundInts.Add( name ,form );
  }

  public void BindPrimaryForm(string name , Form form){
    primaryForm = form;
    primaryName = name;
  }




  public void Live(){

    if( OnSetValues != null ){ OnSetValues(shader,kernel); }
   
    GetNumGroups();
    SetShaderValues();

    // set this true every frame, 
    // and allow each buffer to make 
    // untrue as needed
    allBuffersSet = true;

    shader.SetFloat("_Time", Time.time);
    shader.SetFloat("_Delta", Time.deltaTime);


    foreach(KeyValuePair<string,Form> form in boundForms){
      SetBuffer(form.Key , form.Value);
    }

    foreach(KeyValuePair<string,int> form in boundInts){
      shader.SetInt(form.Key , form.Value);
    }

    SetBuffer( primaryName , primaryForm );

    // if its still true than we can dispatch
    if ( allBuffersSet ){
      if( debug ) print( "name : " + kernelName + " Num groups : " + numGroups );
      shader.Dispatch( kernel,numGroups ,1,1);
    }

  }

  public virtual void SetShaderValues(){

  }

  private void SetBuffer(string name , Form form){
      if( form._buffer != null ){
        shader.SetBuffer( kernel , name , form._buffer);
        shader.SetInt(name+"_COUNT" , form.count );
      }else{
        allBuffersSet = false;
        print("YOUR BUFFER : " + name +  " IS NULL!");
      }
  }

}

