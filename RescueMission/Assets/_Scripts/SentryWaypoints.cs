using UnityEngine;
using System.Collections;

public class SentryWaypoints : MonoBehaviour {

	int nextIndex;
	int currentIndex;
	int lastIndex;
	
	public GameObject[] waypoints;
	public GameObject NextWaypoint(GameObject current){
		// default is first in the array (loops through waypoints)
		nextIndex = 0;
		// find array index of given waypoint
		currentIndex = -1;
		for(int i = 0; i < waypoints.Length; i++){
			if( current == waypoints[i] )
				currentIndex = i;
		}
		lastIndex = (waypoints.Length - 1);
		if(currentIndex > -1 && currentIndex < lastIndex)
			nextIndex = currentIndex + 1;
		return waypoints[nextIndex];
	}
}
