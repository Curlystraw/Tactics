using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TerrainUtils {
	public enum TERRAINS {
		DIRT,
		GRASS,
		WATER
	};

	public static int[] TERRAIN_COST = {
		1,
		1,
		3
	};

}
