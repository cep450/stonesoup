using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTile : Tile
{

    [SerializeField] GameObject slimeTilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void init()
    {
        //start coroutine that makes the slime "bounce in" 
        //using the code i did for juicy conway lol 
        StartCoroutine(bounce(1,1));

        base.init();
    }

    public override void takeDamage(Tile tileDamagingUs, int damageAmount, DamageType damageType) {
		
        //if it's explosive damage, take damage.
        if(damageType == DamageType.Explosive) {
            base.takeDamage(tileDamagingUs, damageAmount, damageType);
            return;
        }

        //otherwise, we spawn new tiles 

        //bounce to indicate taking damage 
        StartCoroutine(bounce(1,1));

        //spread to other tiles when we take damage 

        //generate an x and y to generate at
        //this tries a small number of times so it won't always generate especially if there's a lot of slime around.
        //which i kind of like 
        int x = 0;
        int y = 0;
        bool found = false;
        for(int i = 0; i < 10; i++) {
            x = Random.Range(-1, 2); //TODO add local x y
            y = Random.Range(-1, 2); //TODO add local x y 

            //TODO check if something's there and set found to true if there's no slime 

        }

        //if we found a non-slime x and y, generate there 
        if(found) {
            Tile.spawnTile(slimeTilePrefab, this.transform.parent, x, y);
        }
        
	}

    /*
    // This is the function used to spawn tiles. 
	// YOU SHOULDN'T BE SPAWNING TILES WITH ANY OTHER FUNCTION.
	// This function ensures that tiles are properly contained (and parented) to a room
	public static Tile spawnTile(GameObject tilePrefab, Transform parentOfTile, int gridX, int gridY) {
		// Enforce constraints on where we spawn tiles.
		if (gridX < 0 || gridX >= LevelGenerator.ROOM_WIDTH || gridY < 0 || gridY >= LevelGenerator.ROOM_HEIGHT) {
			throw new UnityException(string.Format("Attempted to spawn tile outside room boundaries. Tile: {0}, Grid X: {1}, Grid Y: {1}", tilePrefab, gridX, gridY));
		}

		GameObject tileObj = Instantiate(tilePrefab) as GameObject;
		tileObj.transform.parent = parentOfTile;
		Tile tile = tileObj.GetComponent<Tile>();
		Vector2 tilePos = toWorldCoord(gridX, gridY);
		tile.localX = tilePos.x;
		tile.localY = tilePos.y;
		tile.init();
		return tile;
	}
    */

    IEnumerator bounce(float bounceTime, float bounceMag) {
        float timeTracker = 0;
        while(timeTracker < bounceTime) {
            transform.localScale = Vector3.one * elastic(timeTracker) * bounceMag;
            timeTracker += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.one * bounceMag;
    }

    //from easings.net- elastic 
    float elastic(float t) {
        return Mathf.Pow(2f, -10f * t) * Mathf.Sin(((10f * t) - 0.75f) * ((2f * Mathf.PI) / 3f)) + 1f;
    }
}
