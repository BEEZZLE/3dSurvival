using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f;  

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
           
             if (collision.relativeVelocity.y <= 0f)
            

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Y 속도 초기화
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
