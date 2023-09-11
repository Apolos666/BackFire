using UnityEngine;

public class DeactiveOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        gameObject.SetActive(true);
    }
}
