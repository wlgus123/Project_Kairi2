using Globals;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
	private Transform _player;
	private EnemyDataManager _dataMng;
	private EnemyStats _enemyData;

	private void Start()
	{
		_dataMng = GetComponent<EnemyDataManager>();
		_player = GameManager.Instance.playerObj.transform;
		_enemyData = _dataMng._enemyStats;
	}

	// 플레이어가 시야에 있는지
	public bool IsPlayerInRange()
	{
		LayerMask mask = ~LayerMask.GetMask("Enemy");
		Vector2 forwardDir = (_player.position - transform.position).normalized;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, forwardDir, _enemyData.SightRange, mask);
		Debug.Log($"Check Player in Range (hit: {hit})");
		Debug.DrawRay(transform.position, forwardDir, Color.red);

		Vector2 dir = (_player.position - transform.position).normalized;
		float dx = _player.position.x - transform.position.x;
		float forward = -Mathf.Sign(transform.localScale.x);
		bool isFacing = dx * forward > 0f;

		print($"hit: {hit.transform.tag}\n" +
			$"dir: {dir}\n" +
			$"dx: {dx}\n" +
			$"forward: {forward}\n" +
			$"isFacing: {isFacing}");

		return isFacing && hit.transform.CompareTag(TagName.player);
	}
}
