using UnityEngine;

public class Player {

    string name;
    int currentLife;
    int maxLife;
    int mentalPower;
    public GameObject obj3d;

    public string Name    // the Name property
    {
        get { return name; }
        set { name = value; }
    }


    public Player(string name, int currentLife, int mentalPower) {
        this.name = name;
        this.currentLife = currentLife;
        this.maxLife = currentLife;
        this.mentalPower = mentalPower;
    }

    public int getCurrentLife() {
        return currentLife;
    }

    public int getMaxLife() {
        return maxLife;
    }

    public string getLife() {
        return currentLife + "/" + maxLife;
    }

    public Attack Attack() {
        int aux = mentalPower / 2;
        int damage = mentalPower + Random.Range(-aux, aux);
        int critical = Random.Range(0, 100);
        bool isCritical = false;
        if (critical < 5) {
            damage *= 2;
            isCritical = true;
        }
        return new Attack(damage, isCritical);
    }

    public bool UpdateLife(int damage) {
        currentLife -= damage;
        if (currentLife <= 0) {
            Object.Destroy(obj3d);
            return false;
        } else {
            return true;
        }
    }

}
