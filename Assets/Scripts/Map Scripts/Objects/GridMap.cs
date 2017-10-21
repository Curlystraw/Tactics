using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap {
	
	public ArrayList map = new ArrayList();
	public Vector2 mapSize;
	public GridMap(int x, int y, GameObject[] TERRAIN_MAP){
		mapSize = new Vector2 (x, y);
		for (int i = 0; i < x; i++) {
			ArrayList col = new ArrayList();
			for (int j = 0; j < y; j++) {
				Column tileCol = new Column (i, j, this);
				ArrayList tiles = new ArrayList ();
				int height = Random.Range (1, 4)+4;
				for (int t = 0; t < height; t++) {
					GameObject tile = GameObject.Instantiate ((GameObject)TERRAIN_MAP [(int)TerrainUtils.TERRAINS.DIRT]);
					tile.GetComponent<TileController> ().setValues (this, new Vector2 (i, j), tileCol);
					tiles.Add (tile);

				}
				GameObject grass = GameObject.Instantiate ((GameObject)TERRAIN_MAP [(int)TerrainUtils.TERRAINS.GRASS]);
				grass.GetComponent<TileController> ().setValues (this, new Vector2 (i, j), tileCol);
				tiles.Add (grass);
				tileCol.makeColumn (tiles);
				col.Add (tileCol);
			}
			map.Add (col);
		}

		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				Column tileCol = getColumn (i, j);
				tileCol.updateColumn ();
			}
		}

	}

	public Column getColumn(int x, int y){
		return (Column)((ArrayList)(map [x])) [y];
	}

	public void updateGrid(){
		for(int x = 0; x < mapSize.x; x++){
			for (int y = 0; y < mapSize.y; y++) {
				Column c = (Column)(((ArrayList)map[x])[y]);
				c.updateColumn ();
			}
		}
	}
}
