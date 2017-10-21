using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column {
	GridMap map;
	ArrayList tiles = new ArrayList();
	Vector2 loc;

	public Column(int i, int j, GridMap g){
		loc = new Vector2 (i, j);
		map = g;
	}
	public Column(ArrayList pieces, int i, int j){

	}

	public void push(GameObject tile){
		tiles.Add(tile);
	}

	public void destroyTile(int height){
		tiles.RemoveAt (height);
	}

	public void makeColumn(ArrayList pieces){
		tiles = pieces;
		alignColumn ();
	}

	public void updateColumn(){
		for (int i = 0; i < tiles.Count; i++) {
			GameObject tile = (GameObject)tiles [i];
			tile.GetComponent<TileController> ().updateTile ();
		}
	}

	public void alignColumn(){
		for (int i = 0; i < tiles.Count; i++) {
			GameObject tile = (GameObject)tiles [i];
			tile.transform.SetPositionAndRotation (new Vector3 (loc [0],(i*.5f), loc [1]),Quaternion.identity);
		}
	}


	//Getters and setters
	public int getHeight(){
		return tiles.Count-1;
	}
}
