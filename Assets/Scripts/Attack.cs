public class Attack {

    private int attack;
    private bool critical;

    public Attack(int attack, bool critical) {
        this.attack = attack;
        this.critical = critical;
    }

    public int getAttack() {
        return attack;
    }

    public bool isCritical() {
        return critical;
    }


}
