using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour {

    #region
    public float zMax;
    public float zMin;
    public float yMax;
    public float yMin;
    public float speed;
    private Vector3 pos1;
    private Vector3 pos2;
    #endregion

    void Start () {
        pos1 = new Vector3(0, yMax, zMax);
        pos2 = new Vector3(0, yMin, zMin);
    }
	

	void Update () {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
