using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    private float storedShadowDistance;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0);
    }

    private void OnPreRender()
    {
        storedShadowDistance = QualitySettings.shadowDistance;
        QualitySettings.shadowDistance = 0;
    }

    private void OnPostRender()
    {
        QualitySettings.shadowDistance = storedShadowDistance;
    }
}
