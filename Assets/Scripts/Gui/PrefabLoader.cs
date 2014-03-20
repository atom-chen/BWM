﻿using UnityEngine;
using System.Collections;

public class PrefabLoader : MonoBehaviour
{
	public GameObject[] prefabs;

	void Start()
	{
		foreach (var pf in prefabs)
		{
			var go = GameObject.Instantiate(pf) as GameObject;
			go.transform.parent = this.transform;
			go.transform.localScale = Vector3.one;
			go.transform.position = Vector3.zero;
		}
	}
}