using Globals;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
	[SerializeField] private Transform groundCheckObj;
	public float checkRadius = 0.1f;
	private LayerMask groundMask;
	private LayerMask oneWayPlatformMask;

	public bool isGrounded = true;
	public bool isGroundedOneway = false;

	public float distance;
	public float angle;

	private void Awake()
    {
		groundMask = LayerMask.GetMask(LayerName.ground);
		oneWayPlatformMask = LayerMask.GetMask(LayerName.oneWayPlatform);
	}

	public void CheckGround()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheckObj.position, checkRadius, groundMask);
		isGroundedOneway = Physics2D.OverlapCircle(groundCheckObj.position, checkRadius, oneWayPlatformMask);
	}

	public void CheckSlope()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheckObj.position, Vector2.down, distance, groundMask);

		angle = Vector2.Angle(hit.normal, Vector2.up);

		Debug.DrawLine(hit.point, hit.point + hit.normal, Color.blue);
    }

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(groundCheckObj.position, checkRadius);
	}
}