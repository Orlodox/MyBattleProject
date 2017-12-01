using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPosition : MonoBehaviour {

    public GameObject parent;
	
	void Update () {
        transform.position = parent.transform.position;
    }
}
