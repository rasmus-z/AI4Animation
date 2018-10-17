using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	private static List<HashSet<KeyCode>> Keys = new List<HashSet<KeyCode>>();
	private static int Capacity = 2;
	private static int Clients = 0;

	void OnEnable() {
		Clients += 1;
	}

	void OnDisable() {
		Clients -= 1;
	}

	public static bool anyKey {
		get{
			for(int i=0; i<Keys.Count; i++) {
				if(Keys[i].Count > 0) {
					return true;
				}
			}
			return false;
		}
	}

	void Update () {
		while(Keys.Count >= Capacity) {
			Keys.RemoveAt(0);
		}
		HashSet<KeyCode> state = new HashSet<KeyCode>();
		foreach(KeyCode k in Enum.GetValues(typeof(KeyCode))) {
			if(Input.GetKey(k)) {
				state.Add(k);
			}
			if(MoveFront){ state.Add(KeyCode.W); }
			if(MoveBack){ state.Add(KeyCode.S); }
			if(MoveLeft){ state.Add(KeyCode.A); }
			if(MoveRight){ state.Add(KeyCode.D); }
			if(TurnLeft){ state.Add(KeyCode.Q); }
			if(TurnRight){ state.Add(KeyCode.E); }
			if(Jog){ state.Add(KeyCode.LeftShift); }
		}
		Keys.Add(state);
	}

	public static bool GetKey(KeyCode k) {
		if(Clients == 0) {
			return Input.GetKey(k);
		} else {
			for(int i=0; i<Keys.Count; i++) {
				if(Keys[i].Contains(k)) {
					return true;
				}
			}
			return false;
		}
	}
	
	private bool MoveFront = false;
	private bool MoveBack = false;
	private bool MoveLeft = false;
	private bool MoveRight = false;
	private bool TurnLeft = false;
	private bool TurnRight = false;
	private bool Jog = false;

	public void MoveFrontDown(){ MoveFront = true; }
	public void MoveFrontUp(){ MoveFront = false; }
	public void MoveBackDown(){ MoveBack = true; }
	public void MoveBackUp(){ MoveBack = false; }
	public void MoveLeftDown(){ MoveLeft = true; }
	public void MoveLeftUp(){ MoveLeft = false; }
	public void MoveRightDown(){ MoveRight = true; }
	public void MoveRightUp(){ MoveRight = false; }
	public void TurnLeftDown(){ TurnLeft = true; }
	public void TurnLeftUp(){ TurnLeft = false; }
	public void TurnRightDown(){ TurnRight = true; }
	public void TurnRightUp(){ TurnRight = false; }
	public void JogDown(){ Jog = true; }
	public void JogUp(){ Jog = false; }
}
