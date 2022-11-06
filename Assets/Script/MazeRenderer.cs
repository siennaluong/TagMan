using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{

    [SerializeField]
    [Range(1, 50)]
    private int width = 20;

    [SerializeField]
    [Range(1, 50)]
    private int height = 20;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    private Transform coinPrefab = null;

    public GameObject ghostPrefab;
    //public GameObject wallPrefab;\

    private int coinCounter = 0;
    public GameObject floorPrefab;



    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
        Remaining_Dots.remaining_dots = coinCounter;
        
    }

    private void Draw(WallState[,] maze)
    {
         var floor = Instantiate(floorPrefab, transform);
       

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3((-width / 2 + i) * size, 0, (-height / 2 + j) * size);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size/ 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size/2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1 && cell.HasFlag(WallState.RIGHT))
                {
                    var rightWall = Instantiate(wallPrefab, transform) as Transform;
                    rightWall.position = position + new Vector3(+size/2, 0, 0);
                    rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                    rightWall.eulerAngles = new Vector3(0, 90, 0);
                }
                

                if (j == 0 && cell.HasFlag(WallState.DOWN))
                {
                    var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                    bottomWall.position = position + new Vector3(0, 0, -size/2);
                    bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                }

                if (i==0 && j==0 || i==0 && j== width-1 || i==width-1&&j==width-1) 
                {   
                    Instantiate(ghostPrefab, position, Quaternion.identity);
                    
                }
                else {
                    coinCounter += 1;
                    var dots = Instantiate(coinPrefab, transform) as Transform;
                    dots.position = position + new Vector3(0, size/4, 0);
                    dots.localScale = new Vector3(dots.localScale.x/3, dots.localScale.y/3, dots.localScale.z/3);
                }
            }

        } 


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}