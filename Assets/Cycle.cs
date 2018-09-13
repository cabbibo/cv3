using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cycle : MonoBehaviour{

  [ HideInInspector ] public bool created;
  [ HideInInspector ] public bool gestated;
  [ HideInInspector ] public bool birthed;
  [ HideInInspector ] public bool awaked;
  [ HideInInspector ] public bool died;
  [ HideInInspector ] public bool destroyed;

  //public delegate void CreateEvents(Cycle c);
  //public event CE CreateEvents;

// initialization
  // setting up and getting structs / counts etc.
  public virtual void Create(){}

  public virtual void OnGestate(){}
  public virtual void WhileGestating(float v){}
  public virtual void OnGestated(){}

  public virtual void OnBirth(){}
  public virtual void WhileBirthing(float v){}
  public virtual void OnBirthed(){}

  public virtual void OnAlive(){}
  public virtual void WhileAlive(float v){}
  public virtual void OnAlived(){}

  public virtual void OnDeath(){}
  public virtual void WhileDying(float v){}
  public virtual void OnDead(){}

  public virtual void Destory(){}


}
