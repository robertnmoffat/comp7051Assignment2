using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {
    public GameObject wall;
    public GameObject floor;
    public int width=10, height=10;

    int[,] map;//0=nothing, 1=wall, 2=floor

    // Use this for initialization
    void Start () {
        Random.InitState((int)System.DateTime.Now.Ticks);

        map = new int[width,height];

        initializeMap();

        generateMaze(1,1,1);

        generateWalls();

        map[1, 0] = 2;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (map[x, y] == 1)
                    Instantiate(wall, new Vector3(x, 0, y), transform.rotation);
                else if (map[x, y] == 2)
                    Instantiate(floor, new Vector3(x, 0, y), transform.rotation);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void initializeMap() {
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                if (x == 0 || x == width - 1 || y == 0 || y == height-1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        }
        //map[0, 1] = 0;
    }

    public void generateMaze(int xpos, int ypos, int prevDir) {
        //0=nothing, 1=wall, 2=floor

        if (!isValidPosition(xpos,ypos,prevDir)) return;

        map[xpos, ypos] = 2;

        
        int startDir = Random.Range(0, 3);
        int currentDir = startDir;
        int turnDir = Random.Range(0,1);

        for (int i=0; i<4; i++) {
            switch (currentDir) {
                case 0:
                    generateMaze(xpos,ypos+1,1);                    
                    break;
                case 1:
                    generateMaze(xpos, ypos - 1,0);
                    break;
                case 2:
                    generateMaze(xpos+1, ypos,3);                    
                    break;
                case 3:
                    generateMaze(xpos - 1, ypos,2);
                    break;
            }

            switch (turnDir)
            {
                case 0:
                    currentDir++;
                    if (currentDir > 3) currentDir = 0;
                    break;
                case 1:
                    currentDir--;
                    if (currentDir < 0) currentDir = 3;
                    break;
            }
        }        

        if (currentDir == startDir) return;//if its checked all directions, finish
    }

    //Check if it is a valid position to add a path square
    public bool isValidPosition(int xpos, int ypos, int prevDir) {
        if (!isInRange(xpos,ypos)) return false;//check if position is in range of the map array.

        if (map[xpos, ypos] == 1) return false;

        for (int dir=0; dir<4; dir++) {//check every direction to see if it is going to touch an already made path
            if (dir == prevDir) continue;//the direction the path came from is exempt
            switch (dir) {
                case 0:
                    if (map[xpos, ypos+1] == 2) return false;
                    break;
                case 1:
                    if (map[xpos, ypos -1] == 2) return false;
                    break;
                case 2:
                    if (map[xpos+1, ypos] == 2) return false;
                    break;
                case 3:
                    if (map[xpos - 1, ypos] == 2) return false;
                    break;
            }
        }

        return true;
    }

    //Check if map position is in range of the array
    public bool isInRange(int xpos, int ypos) {
        if (xpos == 0 || ypos == 0) return false;

        if (xpos == width - 1 || ypos == height - 1) return false;

        return true;
    }

    //fill in leftover space with walls (really inefficient but w/e)
    public void generateWalls() {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (map[x, y] == 0) map[x, y] = 1;
            }
        }
    }
}
