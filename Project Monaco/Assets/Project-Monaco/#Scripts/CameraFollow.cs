using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour 
{
    public Transform followTarget;

    public float smoothing = 5f;

    Vector3 offset;
	Vector3 origin;
	Vector3 backup;

    void Start()
    {
		offset = transform.position - followTarget.position;
		origin = this.transform.position;
		backup=new Vector3(origin.x,origin.y,origin.z* -100f);
    }

	void Update()
	{
		if (followTarget != null)
		{
			Vector3 targetCameraPosition = followTarget.position + offset;
			transform.position = Vector3.Lerp (transform.position, targetCameraPosition, smoothing * Time.deltaTime);
		}
	}
}
