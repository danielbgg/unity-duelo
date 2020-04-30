using UnityEngine;

public class alterarPosicao : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            GameObject aux = GameObject.Find("Player1");
            aux.transform.localScale = new Vector3(aux.transform.localScale.x + 0.1f, aux.transform.localScale.y + 0.1f, aux.transform.localScale.z + 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            GameObject aux = GameObject.Find("Player1");
            aux.transform.localScale = new Vector3(aux.transform.localScale.x - 0.1f, aux.transform.localScale.y - 0.1f, aux.transform.localScale.z - 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.F1)) {
            GameObject.Find("Player1").transform.Rotate(new Vector3(0f, -45.0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.F2)) {
            GameObject.Find("Player1").transform.Rotate(new Vector3(0f, 45.0f, 0f));
        }
        if (Input.GetKey(KeyCode.W)) {
            GameObject.Find("Player1").transform.Translate(new Vector3(0f, 0f, 0.1f));
        }
        if (Input.GetKey(KeyCode.S)) {
            GameObject.Find("Player1").transform.Translate(new Vector3(0f, 0f, -0.1f));
        }
        if (Input.GetKey(KeyCode.A)) {
            GameObject.Find("Player1").transform.Translate(new Vector3(-0.1f, 0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.D)) {
            GameObject.Find("Player1").transform.Translate(new Vector3(0.1f, 0f, 0.0f));
        }
    }
}
