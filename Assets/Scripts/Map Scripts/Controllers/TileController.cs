using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {
	GridMap map;
	Column col;
	Vector2 loc;
	public void updateTile(){
		//uses a "close enough" height check

		//Display if top tile
		if (col.getHeight () - this.transform.position.y * 2 < .1) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}

		//Check for adjacent top tiles, if at least one side has a height less than this tile, display
		#region dirChecks
		//North
		int x = (int)loc.x;
		int y = (int)loc.y;
		if (y == 0) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}
		Column adjacent = (Column)(((ArrayList)(map.map [x])) [y-1]);
		if (adjacent.getHeight () - this.transform.position.y * 2 < .1) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}

		//East
		if (x+1 == map.mapSize.x) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}

		adjacent = (Column)(((ArrayList)(map.map [x+1])) [y]);
		if (adjacent.getHeight () - this.transform.position.y * 2 < .1) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}

		//South
		if (y+1 == map.mapSize.y) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}

		adjacent = (Column)(((ArrayList)(map.map [x])) [y+1]);
		if (adjacent.getHeight () - this.transform.position.y * 2 < .1) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}

		//West
		if (x == 0) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}

		adjacent = (Column)(((ArrayList)(map.map [x-1])) [y]);
		if (adjacent.getHeight () - this.transform.position.y * 2 < .1) {
			this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			return;
		}
		#endregion dirchecks

	}


	public void setMap(GridMap m){
		map = m;
	}
	public void setLoc(Vector2 l){
		loc = l;
	}
	public void setCol(Column c){
		col = c;
	}

	public void setValues(GridMap m, Vector2 l, Column c){
		map = m;
		loc = l;
		col = c;
	}

}
