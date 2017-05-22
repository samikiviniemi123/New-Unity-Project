using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour 
{
	public float lifeTime;
	private float lifeTimeCounter;

	void Start () 
	{
		lifeTimeCounter = lifeTime;
	}

	void Update () 
	{
		lifeTimeCounter -= Time.deltaTime;

		if (lifeTimeCounter <= 0) 
		{
			Destroy (gameObject);
		}
	}
}