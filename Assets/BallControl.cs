using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;

    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {
        trajectoryOrigin = transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBall() {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall() {

        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        float randomDirection = Random.Range(0, 2);

        // Modifikasi gaya bola supaya stabil dan sama ke semua arah
        // kekuatan gaya bisa diambil dengan mengambil nilai magnitude dari arah x dan y
        // stabilisasi gaya bisa dilakukan dengan membuat nilai magnitude gaya sekarang menjadi dengan gaya maksimum
        float gayaMaksimum = Mathf.Sqrt(xInitialForce * xInitialForce + yInitialForce * yInitialForce);
        float gayaSekarang = Mathf.Sqrt(xInitialForce * xInitialForce + yRandomInitialForce * yRandomInitialForce);
        float penguatanGaya = gayaMaksimum / gayaSekarang;

        if (randomDirection < 1.0f) {
            rigidBody2D.AddForce(new Vector2(-xInitialForce*penguatanGaya, yRandomInitialForce*penguatanGaya));
        }
        else {
            rigidBody2D.AddForce(new Vector2(xInitialForce*penguatanGaya, yRandomInitialForce*penguatanGaya));
        }
    }

    void RestartGame() {
        ResetBall();

        Invoke("PushBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin {
        get { return trajectoryOrigin; }
    }
}
