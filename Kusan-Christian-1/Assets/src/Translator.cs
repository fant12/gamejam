using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Translator : MonoBehaviour {
	
	public static Translator main;
	
	private const float _CREATE_RATE = 2; 
	public float SPEED_BALL = 2f;
	public float _SPEED_RECEIVER = 3f;
	private const int _RANGE = 5;
	
	protected List<GameObject> _ball;
	private GameObject _receiver;
	
	private float _end;
	private float _next;
	
	
	// Use this for initialization
	void Start () {
		
		main = this;
		_next = 0;
		
		//ball
		_ball = new List<GameObject>();
		
		//receiver
		_receiver = Instantiate(Resources.Load("Receiver")) as GameObject;
		_receiver.transform.parent = gameObject.transform;
		_receiver.transform.Translate(0f, 0f, 0f);
		
		//where balls will be destroyed (double receiver height)
		_end = 0 - _receiver.transform.localScale.y * 2;
	}
	
	// Update is called once per frame
	void Update () {
	
		//move receiver on x-axis per keyboard arrows or a, d
		if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && -_RANGE <= _receiver.transform.position.x)
			_receiver.transform.Translate(Input.GetAxis("Horizontal") * _SPEED_RECEIVER * Time.deltaTime, 0f, 0f);
		else if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && _RANGE >= _receiver.transform.position.x)
			_receiver.transform.Translate(Input.GetAxis("Horizontal") * _SPEED_RECEIVER * Time.deltaTime, 0f, 0f);
		
		//create ball in 2s rate
		if(Time.time > _next){
			_next = _CREATE_RATE + Time.time;
			_ball.Add(createBall());
		}
		
		//move all balls or delete if out of range
		for(int i = 0; _ball.Count > i; ++i)		//use for, foreach uses enums that can't be modified
			if(_end > _ball[i].transform.position.y)
				deleteBall(i);
			else
				_ball[i].transform.Translate(0f, -1f * SPEED_BALL * Time.deltaTime, 0f);
	}
	
	/**
	 * Create a ball object at random position on x-axis.
	 * @return prefab game object of ball.
	 */ 
	private GameObject createBall(){
		GameObject ball = Instantiate(Resources.Load("Ball")) as GameObject;
		ball.transform.parent = gameObject.transform;
		ball.transform.Translate(Random.Range(-_RANGE, _RANGE), 1f, 0f); //random maxrange = inclusive
		return ball;
	}
	
	/**
	 * Delete an existing ball.<br />
	 * At first destroying object then reference in list.
	 * @param index define index in list of balls.
	 */ 
	private void deleteBall(int index){
		Destroy(_ball[index]);
		_ball.RemoveAt(index);
	}
	
	/**
	 * Delete a ball.<br />
	 * At first remove reference in list then destroy object.
	 * @param go the ball game object.
	 */ 
	public void deleteBall(GameObject go){
		_ball.Remove(go);
		Destroy(go);
	}

}
