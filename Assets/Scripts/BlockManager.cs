using System.Collections;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public Transform[] blocks; // Mảng chứa các block cần di chuyển
    public float moveDistance ; // Khoảng cách di chuyển
    public float moveDelay; // Thời gian chờ giữa các lần di chuyển

    private void Start()
    {
        StartCoroutine(MoveBlocksWithDelay());
    }

    private IEnumerator MoveBlocksWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);

            foreach (Transform block in blocks)
            {
                Vector3 targetPosition = block.position - Vector3.up * moveDistance;
                Vector3 originalPosition = block.position;
                float elapsedTime = 0.0f;
                float duration = 1.0f; // Thời gian di chuyển

                while (elapsedTime < duration)
                {
                    block.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                block.position = targetPosition; 
            }
        }
    }
    
}