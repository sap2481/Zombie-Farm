using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //==== FIELDS ====
    [SerializeField] ZombieManager zombieManager;
    GameObject wall;
    SpriteRenderer wallSprite;

    
    //==== START ====
    void Start()
    {
        wall = GameObject.FindGameObjectWithTag("Wall");
        wallSprite = wall.GetComponent<SpriteRenderer>();
    }

    //==== UPDATE ====
    void Update()
    {
        //Loop through zombies
        for (int i = 0; i < zombieManager.Zombies.Count; i++)
        {
            //Detect Collisions with Wall
            if (AABBCollision(zombieManager.Zombies[i].GetComponent<SpriteRenderer>(), wallSprite))
            {
                zombieManager.DestroyZombie(zombieManager.Zombies[i]);
                zombieManager.Zombies.RemoveAt(i);
            }

            //Detect Collisions with Bullets
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            for (int j = 0; j < bullets.Length; j++)
            {
                if (AABBCollision(zombieManager.Zombies[i].GetComponent<SpriteRenderer>(), bullets[j].GetComponent<SpriteRenderer>()))
                {
                    Destroy(bullets[j].gameObject);
                    zombieManager.Zombies[i].Health--;
                    if (zombieManager.Zombies[i].Health <= 0)
                    {
                        zombieManager.DestroyZombie(zombieManager.Zombies[i]);
                        zombieManager.Zombies.RemoveAt(i);
                    }
                }
            }
        }
    }

    //==== METHODS ====
    public bool AABBCollision(SpriteRenderer obj1, SpriteRenderer obj2)
    {
        if ((obj1.bounds.min.x < obj2.bounds.max.x &&
            obj1.bounds.max.x > obj2.bounds.min.x) &&
            (obj1.bounds.min.y < obj2.bounds.max.y &&
            obj1.bounds.max.y > obj2.bounds.min.y))
        {
            return true;
        }

        return false;
    }
}
