using UnityEngine;

public class Hit : MonoBehaviour {

    float timerBullet;

    void Update() {
        timerBullet += Time.deltaTime;
        if (timerBullet > 2.0f) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        print(collision.gameObject.name);
        Battle b = GameObject.Find("Controle").GetComponent<Battle>();
        if (collision.gameObject.name == "Player 1") {
            b.HitDoPlayer2();
        }
        if (collision.gameObject.name == "Player 2") {
            b.HitDoPlayer1();
        }
    }

}
