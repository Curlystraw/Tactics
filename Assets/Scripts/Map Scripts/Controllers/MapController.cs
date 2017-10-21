using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
	[SerializeField]
	GameObject[] TERRAIN_PREFABS = {};
	[SerializeField]
	Vector2 mapSize;
	GridMap map;
	// Use this for initialization
	void Start () {
		map = new GridMap ((int)mapSize.x, (int)mapSize.y, TERRAIN_PREFABS);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
