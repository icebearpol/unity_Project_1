using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public MonsterController monster;   // Assign Monster parent with MonsterController
    public int maxDanger = 10;          // Maximum danger before guaranteed attack
    public int dangerLevel = 0;         // Starts at 0
    public int dangerPerWrongClick = 2; // Increase per wrong click

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    
    public void Report(bool correct)
    {
        if (!correct)
        {
            dangerLevel += dangerPerWrongClick;
            dangerLevel = Mathf.Min(dangerLevel, maxDanger); // Clamp

            Debug.Log("Wrong! Danger Level: " + dangerLevel);
            TryAttack();
        }
        else
        {
            Debug.Log("Correct! Danger Level: " + dangerLevel);
        }
    }

    private void TryAttack()
    {
        if (monster == null)
        {
            Debug.LogWarning("Monster not assigned in GameManager!");
            return;
        }

        if (dangerLevel >= 6)
        {
            // Guaranteed attack at mid danger
            monster.TriggerAttack();
        }
        else
        {
            // Random chance based on danger level
            float chance = (float)dangerLevel / maxDanger;
            if (Random.value < chance)
            {
                monster.TriggerAttack();
            }
        }
    }
}