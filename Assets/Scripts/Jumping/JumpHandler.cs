using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JumpHandler : MonoBehaviour {

    private float aceleration;
    public float jumpTime;
    public float distance;
    private float time;
    private float jumpTemp;
    private Rigidbody rigidbody;
    private Vector3 initPosition;
    private Vector3 targetPosition;
    private bool isJumping;
    public Text textDistance;
    public Text textTime;
    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        isJumping = false;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
        if (isJumping) {
            rigidbody.useGravity = true;
            return;
        }else if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump() {
        
        isJumping = true;
        initPosition = transform.position;
        targetPosition = transform.position + (Vector3.up *distance);
        jumpTemp = 0;
        time = 0;
        while (isJumping)
        {
            jumpTemp = time / jumpTime;
            
            if (jumpTemp > 1)
            {
                isJumping = false;
                jumpTemp = 1;
            }
            Vector3 currentPos = Vector3.Lerp(initPosition, targetPosition, jumpTemp);
            transform.position= currentPos;
            textDistance.text = "Distance: "+transform.position.y;
            textTime.text = "Time: " + time;
            yield return null;
            time += Time.deltaTime;
        }
        yield break;
    }


}
