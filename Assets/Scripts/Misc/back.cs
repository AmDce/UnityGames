using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour
{
	 void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);	
	}
}