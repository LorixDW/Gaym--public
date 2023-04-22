using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController playerC;

    public Vector3 pickPosition;
	public Vector3 pickRotation;
    Transform rightHand;

	void Start()
    {
        playerC = gameObject.GetComponent<PlayerController>();
        playerC.isAlive = true;
        rightHand = transform.Find("mixamorig:RightForeArm");
    }

    // Update is called once per frame
    void Update()
    {
        
		
	}
}
