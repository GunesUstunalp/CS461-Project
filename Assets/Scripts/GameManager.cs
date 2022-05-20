using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.Timers;

public class GameManager : MonoBehaviour
{
    public Sprite wallSprite;
    public Sprite foodSprite;
    public Sprite pacmanSprite;
    public Sprite ghostSprite;

    GameObject pacman;
    GameObject ghost;
    List<Point> dfsPath;
    List<Point> bfsPath;
    List<Point> ucsPath;
    List<Point> astarPath;
    List<GameState> minimaxPath;
    List<GameState> expectimaxPath;
    GameState currState;

    bool mapPrinted = false;
    public string mapName;
    public string searchAlgo;
    Map map;

    void Start()
    {

        map = new Map(mapName);
        Search searcher = new Search();

        currState = new GameState(map);


        switch (searchAlgo)
        {
            case ("DFS"):
                dfsPath = searcher.DFS(currState);
                Debug.Log("The length of the path by DFS: " + (dfsPath.Count - 1) + " in " + mapName);
                break;
            case ("BFS"):
                bfsPath = searcher.BFS(currState);
                Debug.Log("The length of the path by BFS: " + (bfsPath.Count - 1) + " in " + mapName);
                break;
            case ("UCS"):
                ucsPath = searcher.UCS(currState);
                Debug.Log("The length of the path by UCS: " + (ucsPath.Count - 1) + " in " + mapName);
                break;
            case ("AStar"):
                astarPath = searcher.AStar(currState);
                Debug.Log("The length of the path by AStar: " + (astarPath.Count - 1) + " in " + mapName);
                break;
            case ("Minimax"):
                minimaxPath = searcher.minimax(currState);
                Debug.Log("The length of the path by Minimax: " + (minimaxPath.Count - 1) + " in " + mapName);
                break;
            case ("Expectimax"):
                expectimaxPath = searcher.expectimax(currState);
                Debug.Log("The length of the path by AStar: " + (astarPath.Count - 1) + " in " + mapName);
                break;
            case ("All"):
                dfsPath = searcher.DFS(currState);
                Debug.Log("The length of the path by DFS: " + (dfsPath.Count - 1) + " in " + mapName);

                bfsPath = searcher.BFS(currState);
                Debug.Log("The length of the path by BFS: " + (bfsPath.Count - 1) + " in " + mapName);

                //ucsPath = searcher.UCS(currState);
                //Debug.Log("The length of the path by UCS: " + (ucsPath.Count - 1) + " in " + mapName);

                //astarPath = searcher.AStar(currState);
                //Debug.Log("The length of the path by AStar: " + (astarPath.Count - 1) + " in " + mapName);
                break;

        }
        
        if(!searchAlgo.Equals("All"))
            StartCoroutine("print" + searchAlgo);
    }

    private IEnumerator printMinimax()
    {
        if (!mapPrinted)
            printMap(currState);

        while (minimaxPath.Count != 0)
        {
            currState.pacmanPosition = minimaxPath[0].pacmanPosition;
            currState.ghostPosition = minimaxPath[0].ghostPosition;
            minimaxPath.RemoveAt(0);
            printPacman(currState);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator printExpectimax()
    {
        if (!mapPrinted)
            printMap(currState);

        while (expectimaxPath.Count != 0)
        {
            currState.pacmanPosition = expectimaxPath[0].pacmanPosition;
            currState.ghostPosition = expectimaxPath[0].ghostPosition;
            expectimaxPath.RemoveAt(0);
            printPacman(currState);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator printDFS()
    {
        if (!mapPrinted)
            printMap(currState);

        while (dfsPath.Count != 0)
        {
            currState.pacmanPosition = dfsPath[0];
            dfsPath.RemoveAt(0);
            printPacman(currState);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator printBFS()
    {
        if (!mapPrinted)
            printMap(currState);

        while (bfsPath.Count != 0)
        {
            currState.pacmanPosition = bfsPath[0];
            bfsPath.RemoveAt(0);
            printPacman(currState);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator printUCS()
    {
        if (!mapPrinted)
            printMap(currState);

        while (ucsPath.Count != 0)
        {
            currState.pacmanPosition = ucsPath[0];
            ucsPath.RemoveAt(0);
            printPacman(currState);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator printAStar()
    {
        if (!mapPrinted)
            printMap(currState);

        while (astarPath.Count != 0)
        {
            currState.pacmanPosition = astarPath[0];
            astarPath.RemoveAt(0);
            printPacman(currState);
            yield return new WaitForSeconds(0.5f);
        }
    }


    public void printMap(GameState state)
    {
        for (int i = 0; i < map.width; i++)
        {
            for (int j = 0; j < map.height; j++)
            {
                Point tested = new Point(i, j);
                if (state.walls.Contains(tested))
                {
                    GameObject wall = new GameObject("Wall" + i + "," + j);
                    SpriteRenderer renderer = wall.AddComponent<SpriteRenderer>();
                    renderer.sprite = wallSprite;
                    wall.transform.position = new Vector2(i, j);
                }
                else if (state.foods.Contains(tested))
                {
                    GameObject food = new GameObject("Food" + i + "," + j);
                    SpriteRenderer renderer = food.AddComponent<SpriteRenderer>();
                    renderer.sprite = foodSprite;
                    food.transform.position = new Vector2(i, j);
                }
                else if (state.pacmanPosition == tested)
                {
                    pacman = new GameObject("Pacman");
                    SpriteRenderer renderer = pacman.AddComponent<SpriteRenderer>();
                    renderer.sprite = pacmanSprite;
                    pacman.transform.position = new Vector2(i, j);
                }
                else if (state.ghostPosition == tested)
                {
                    ghost = new GameObject("Ghost");
                    SpriteRenderer renderer = ghost.AddComponent<SpriteRenderer>();
                    renderer.sprite = ghostSprite;
                    ghost.transform.position = new Vector2(i, j);
                }
            }
        }
    }

    public void printPacman(GameState state)
    {
        pacman.transform.position = new Vector2(state.pacmanPosition.X, state.pacmanPosition.Y);

        if (state.foods.Contains(state.pacmanPosition))
        {
            state.foods.Remove(state.pacmanPosition);
            GameObject toBeRemoved = GameObject.Find("Food" + state.pacmanPosition.X + "," + state.pacmanPosition.Y);
            toBeRemoved.SetActive(false);
        }
    }



    void Update()
    {
        
    }
}
