using UnityEngine;

public class CamControler : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;

    [SerializeField]
    private Transform target;

    private void Awake()
    {
        target = FindObjectOfType<Character>().transform;
        if (target == null) return;
        Vector3 position = target.position; position.z = -10.0f; position.y = 0.0f; position.x += 7.0f;
        transform.position = position;
    }

    private void Update()
    {
        if (target == null) return;
        Vector3 position = target.position; position.z = -10.0f; position.y = 0.0f; position.x += 5.0f;

        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
