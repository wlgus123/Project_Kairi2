using UnityEngine;

public class FindBangUI : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        transform.localPosition = new Vector2(-0.5f, -0.5f);
    }
    public void VisibleUI()
    {
        gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        gameObject.SetActive(false);
    }
}
