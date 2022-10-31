using UnityEngine;

public class HorrorCamRotation : MonoBehaviour
{
    public GameObject mainCamera;

    // Update is called once per frame
    void Update()
    {
        var target = mainCamera;
        Vector3 newRotation = new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
        this.transform.eulerAngles = newRotation;
    }
}
