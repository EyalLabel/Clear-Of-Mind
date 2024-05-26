using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	public float life = 3;
	public float damage = 1;
	// Use this for initialization
	void Start () {
	
	}

	private void Awake()
	{
		Destroy(gameObject, life);
	}
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.forward * Time.deltaTime * 1000f;
	
	}
}
