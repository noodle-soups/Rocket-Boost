using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public float playerHP;
    public bool playerDeath = false;


    private void ClampPlayerHP()
    {
        playerHP = Mathf.Max(playerHP, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Contact");
            // push back + eye frames?
            PlayerTakesDamage(collision.gameObject);
            Debug.Log(playerHP);
        }
    }

    private void PlayerTakesDamage(GameObject enemyGameObject)
    {
        float _enemyContactDamage = enemyGameObject.GetComponent<EnemyProperties>().contactDamage;
        playerHP -= _enemyContactDamage;
        ClampPlayerHP();
    }


}