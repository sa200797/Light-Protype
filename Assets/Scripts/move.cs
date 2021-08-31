using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 right = new Vector3(0.1f, 0, 0); //Vector in the direction you want to move in.
    Vector3 left = new Vector3(-0.1f, 0, 0);
    public float moveSpeed;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {//Using update to capture the keypress.
            StartCoroutine(smooth_move_right(right, 1 * moveSpeed)); //Calling the coroutine.
        }
        if (Input.GetKey(KeyCode.A))
        {//Using update to capture the keypress.
            StartCoroutine(smooth_move_left(left, 1 * moveSpeed)); //Calling the coroutine.
        }
    }


    IEnumerator smooth_move_right(Vector3 direction, float speed)
    {
        float startime = Time.time;
        Vector3 start_pos = transform.position; //Starting position.
        Vector3 end_pos = transform.position ; //Ending position.

        while (start_pos != end_pos && ((Time.time - startime) * speed) < 1f)
        {
            float move = Mathf.Lerp(0, 10f, (Time.time - startime) * speed);

            transform.position += direction * move;

            yield return null;
        }
    }

    IEnumerator smooth_move_left(Vector3 direction, float speed)
    {
        float startime = Time.time;
        Vector3 start_pos = transform.position; //Starting position.
        Vector3 end_pos = transform.position + direction; //Ending position.

        while (start_pos != end_pos && ((Time.time - startime) * speed) < 1f)
        {
            float move = Mathf.Lerp(0, 10f, (Time.time - startime) * speed);

            transform.position += direction * move;

            yield return null;
        }
    }

}