using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Form : MonoBehaviour {


  public int count;
  //public bool debug;

  [HideInInspector] public bool intBuffer;

  [HideInInspector] public int structSize;
  [HideInInspector] public ComputeBuffer _buffer;

//  [HideInInspector] public string name;
  [HideInInspector] public string description;
  [HideInInspector] public float timeToCreate;
  [HideInInspector] public int totalMemory;  
  
  [HideInInspector] public bool created;

  public void Create(Form parent){
    SetStructSize( parent );
    SetCount( parent );
    SetBufferType();
  }

  public void OnGestate(Form parent){
    
      _buffer = MakeBuffer();

      created = true;

      Embody(parent);

  }

  public virtual void Embody( Form parent ){}
  public virtual void SetCount( Form parent ){}
  public virtual void SetStructSize( Form parent ){}
  public virtual void SetBufferType(){}

  public void Final(){

    ReleaseBuffer();
    created = false;

  }

  // Only going to be doing this if they are unlocked
  // and are shown.
  public void _DebugShow(){ DebugShow(); }

  public virtual void DebugShow(){}


  public T[] GetData<T>(){
    T[] array = new T[count];
    _buffer.GetData(array);
    return array;
  }

  public void SetData( float[] values ){ _buffer.SetData( values );}
  public void SetData( int[] values ){ _buffer.SetData( values );}

  public ComputeBuffer MakeBuffer(){

    if( intBuffer == true ){
      return new ComputeBuffer( count, sizeof(int) * structSize );
    }else{
      return new ComputeBuffer( count, sizeof(float) * structSize );
    }
  }


  public void ReleaseBuffer(){
   if(_buffer != null){ _buffer.Release(); }
  }

}