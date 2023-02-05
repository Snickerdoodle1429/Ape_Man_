using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey_Attack : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "Ape")
        Destroy(co.gameObject);
    }
}