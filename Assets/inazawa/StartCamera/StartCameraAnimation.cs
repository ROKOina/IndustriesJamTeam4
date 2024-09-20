using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraAnimation : MonoBehaviour
{
    static public bool isStart = false;
    public float scrollSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (isStart) return;
		if (!GetComponent<PlayStert>().GoCameraAnim) return;

		Vector3 pos = transform.position;
		pos.x += scrollSpeed * Time.deltaTime;
		if (pos.x > 0)
		{
			pos.x = 0;
			isStart = true;
		}
		transform.position = pos;
	}
}
