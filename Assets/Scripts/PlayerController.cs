using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    public Vector2 input;

    private void Update()
    {
	  if (!isMoving)
	  {
		input.x = Input.GetAxisRaw("Horizontal");
		input.y = Input.GetAxisRaw("Vertical");

		//To eliminate diagonal movement, though we can remove this to enable diagonal movement
		if (input.x != 0)
		{
		    input.y = 0;
		}


		if (input != Vector2.zero)
		{
		    var targetPos = transform.position;
		    targetPos.x += input.x;
		    targetPos.y += input.y;

		    StartCoroutine(Move(targetPos));
		}
	  }
    }

    IEnumerator Move(Vector3 targetPos)
    {
	  isMoving = true;

	  while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
	  {
		transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
		yield return null;
	  }
	  transform.position = targetPos;

	  isMoving = false;
    }
}
