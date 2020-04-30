using UnityEngine;

public class alterarCor : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            print("Método GetKeyDown(C)");
            GameObject obj = GameObject.Find("Main Camera");
            obj.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
            obj.GetComponent<Camera>().backgroundColor = Color.black;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            print("Método GetKeyDown(D)");
            GameObject p1 = GameObject.Find("Player1");
            p1.GetComponent<MeshRenderer>().material = Resources.Load("Materials/blue", typeof(Material)) as Material;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            print("Método GetKeyDown(E)");
            GameObject p2 = GameObject.Find("Player2");
            p2.GetComponent<MeshRenderer>().material = Resources.Load("Materials/red", typeof(Material)) as Material;
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            print("Método GetKeyDown(P)");
            GameObject p1 = GameObject.Find("Piso");
            p1.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("Images/steel", typeof(Texture)) as Texture;
        }

    }
}
