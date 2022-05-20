using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System;

public class StackElement
{
    public List<Point> possiblePath;
    public GameState succState;
}

public class Search
{
    private bool isStateVisited(List<GameState> visitedStates, GameState state)
    {
        foreach(GameState visited in visitedStates)
        {
            if (visited.Equals(state))
            {
                return true;
            }   
        }
        return false;
    }

    public List<Point> DFS(GameState initialState)
    {
        int expandedCount = 0;
        List<GameState> visitedStates = new List<GameState>();
        List<Point> currPath = new List<Point>();
        currPath.Add(initialState.pacmanPosition);

        GameState currState = initialState;
        visitedStates.Add(initialState);
        Stack<StackElement> stack = new Stack<StackElement>();

        while (!currState.isGoalState())
        {
            foreach (GameState succState in currState.getSuccessors())
            {
                if (!isStateVisited(visitedStates, succState))
                {
                    StackElement expanded = new StackElement();
                    expanded.possiblePath = new List<Point>(currPath);
                    expanded.possiblePath.Add(succState.pacmanPosition);
                    expanded.succState = succState;

                    //Debug.Log("Expanded to " + succState.pacmanPosition);
                    stack.Push(expanded);
                    expandedCount++;
                }
            }

            if (stack.Count == 0)
            {
                Debug.Log("No solution found in DFS!");
            }

            StackElement popped = stack.Pop();
            currState = popped.succState;
            currPath = popped.possiblePath;
            visitedStates.Add(currState);
            //Debug.Log("Popped " + currState.pacmanPosition);
        }
        //Debug.Log("Goal State: " + currState.pacmanPosition);

        Debug.Log("DFS expanded to " + expandedCount + " states");
        return currPath;
    }


    public List<Point> BFS(GameState initialState)
    {
        int expandedCount = 0;
        List<GameState> visitedStates = new List<GameState>();
        List<Point> currPath = new List<Point>();
        currPath.Add(initialState.pacmanPosition);

        GameState currState = initialState;
        visitedStates.Add(initialState);
        Queue<StackElement> queue = new Queue<StackElement>();

        while (!currState.isGoalState())
        {
            foreach (GameState succState in currState.getSuccessors())
            {
                if (!isStateVisited(visitedStates, succState))
                {
                    bool queueContains = false;
                    foreach (StackElement e in queue)
                    {
                        if (e.succState.Equals(succState))
                            queueContains = true;
                    }

                    if (!queueContains)
                    {
                        StackElement expanded = new StackElement();
                        expanded.possiblePath = new List<Point>(currPath);
                        expanded.possiblePath.Add(succState.pacmanPosition);
                        expanded.succState = succState;

                        //Debug.Log("Expanded to " + succState.pacmanPosition);
                        queue.Enqueue(expanded);
                        expandedCount++;

                    }
                }
            }

            if (queue.Count == 0)
            {
                Debug.Log("No solution found in BFS!");
                return currPath;
            }

            StackElement popped = queue.Dequeue();
            currState = popped.succState;
            currPath = popped.possiblePath;
            visitedStates.Add(currState);
            //Debug.Log("Popped " + currState.pacmanPosition);
        }
        //Debug.Log("Goal State: " + currState.pacmanPosition);

        Debug.Log("BFS expanded to " + expandedCount + " states");
        return currPath;
    }

    public List<Point> UCS(GameState initialState)
    {
        int expandedCount = 0;
        List<GameState> visitedStates = new List<GameState>();
        List<Point> currPath = new List<Point>();
        currPath.Add(initialState.pacmanPosition);

        GameState currState = initialState;
        visitedStates.Add(initialState);
        //PriorityQueue<int,StackElement> queue = new PriorityQueue<int,StackElement>(new MyComparer());
        Queue<StackElement> queue = new Queue<StackElement>();

        while (!currState.isGoalState())
        {
            foreach (GameState succState in currState.getSuccessors())
            {
                if (!isStateVisited(visitedStates, succState))
                {
                    bool queueContains = false;
                    foreach (StackElement e in queue)
                    {
                        if (e.succState.Equals(succState))
                            queueContains = true;
                    }

                    if (!queueContains)
                    {
                        StackElement expanded = new StackElement();
                        expanded.possiblePath = new List<Point>(currPath);
                        expanded.possiblePath.Add(succState.pacmanPosition);
                        expanded.succState = succState;

                        //Debug.Log("Expanded to " + succState.pacmanPosition);
                        queue.Enqueue(expanded);
                        expandedCount++;

                    }
                }
            }

            if (queue.Count == 0)
            {
                Debug.Log("No solution found in UCS!");
                return currPath;
            }

            StackElement popped = queue.Dequeue();
            currState = popped.succState;
            currPath = popped.possiblePath;
            visitedStates.Add(currState);
            //Debug.Log("Popped " + currState.pacmanPosition);
        }
        //Debug.Log("Goal State: " + currState.pacmanPosition);

        Debug.Log("UCS expanded to " + expandedCount + " states");
        return currPath;
    }

    public List<Point> AStar(GameState initialState)
    {
        int expandedCount = 0;
        List<GameState> visitedStates = new List<GameState>();
        List<Point> currPath = new List<Point>();
        currPath.Add(initialState.pacmanPosition);

        GameState currState = initialState;
        visitedStates.Add(initialState);
        PriorityQueue<int,StackElement> queue = new PriorityQueue<int,StackElement>();

        while (!currState.isGoalState())
        {
            foreach (GameState succState in currState.getSuccessors())
            {
                if (!isStateVisited(visitedStates, succState))
                {
                    /*bool queueContains = false;
                    foreach (StackElement e in queue)
                    {
                        if (e.succState.Equals(succState))
                            queueContains = true;
                    }*/

                    //if (!queueContains)
                    //{
                        StackElement expanded = new StackElement();
                        expanded.possiblePath = new List<Point>(currPath);
                        expanded.possiblePath.Add(succState.pacmanPosition);
                        expanded.succState = succState;

                        //Debug.Log("Expanded to " + succState.pacmanPosition);
                        queue.Enqueue(currPath.Count + euclideanheuristic(expanded.succState), expanded);
                        expandedCount++;

                    //}
                }
            }

            if (queue.IsEmpty)
            {
                Debug.Log("No solution found in AStar!");
                return currPath;
            }

            StackElement popped = queue.DequeueValue();
            currState = popped.succState;
            currPath = popped.possiblePath;
            visitedStates.Add(currState);
            //Debug.Log("Popped " + currState.pacmanPosition);
        }
        //Debug.Log("Goal State: " + currState.pacmanPosition);

        Debug.Log("AStar expanded to " + expandedCount + " states");
        return currPath;
    }

    public List<GameState> minimax(GameState initialState)
    {
        List<GameState> currPath = new List<GameState>();
        currPath.Add(initialState);

        GameState currState = initialState;
        while (!currState.isGoalState())
        {
            if (currState.checkIfPacmanEaten())
            {
                Debug.Log("Pacman Eaten!");
                return currPath;
            }

            Point[] positions = minimaxHelper(currState);
            currState = new GameState(initialState.walls, initialState.foods, positions[0], positions[1], initialState.mapWidth, initialState.mapHeight);
            currPath.Add(currState);
        }
        return currPath;
    }

    public Point[] minimaxHelper(GameState state)
    {
        GameState maxState = null;
        foreach (GameState succState in state.getPacmanSuccessorsAdversarial())
        {
            GameState minState = null;
            foreach (GameState leafState in succState.getGhostSuccessorAdversarial())
            {
                if (minState == null)
                {
                    minState = leafState;
                }    
                else if(evaluateState(leafState) < evaluateState(minState))
                {
                    minState = leafState;
                }
            }

            if(maxState == null)
            {
                maxState = succState;
            }
            else if(evaluateState(maxState) < evaluateState(minState))
            {
                maxState = succState;
            }

        }
        Point[] positions = new Point[2] { maxState.ghostPosition, maxState.pacmanPosition };
        return positions;
    }

    public List<GameState> expectimax(GameState initialState)
    {
        List<GameState> currPath = new List<GameState>();
        currPath.Add(initialState);

        GameState currState = initialState;
        while (!currState.isGoalState())
        {
            if (currState.checkIfPacmanEaten())
            {
                Debug.Log("Pacman Eaten!");
                return currPath;
            }

            Point[] positions = minimaxHelper(currState);
            currPath.Add(new GameState(initialState.walls, initialState.foods, positions[0], positions[1], initialState.mapWidth, initialState.mapHeight));
        }
        return currPath;
    }

    public Point[] expectimaxHelper(GameState state)
    {
        GameState maxState = null;
        foreach (GameState succState in state.getPacmanSuccessorsAdversarial())
        {
            GameState minState = null;
            foreach (GameState leafState in succState.getGhostSuccessorAdversarial())
            {
                if (minState == null)
                {
                    minState = leafState;
                }
                else if (evaluateState(leafState) < evaluateState(minState))
                {
                    minState = leafState;
                }
            }

            if (maxState == null)
            {
                maxState = succState;
            }
            else if (evaluateState(maxState) < evaluateState(minState))
            {
                maxState = succState;
            }

        }
        Point[] positions = new Point[2] { maxState.ghostPosition, maxState.pacmanPosition };
        return positions;
    }

    private int evaluateState(GameState state)
    {
        if (state.checkIfPacmanEaten())
            return -10000;

        return 2*ghostManhattanHeuristic(state) - manhattanHeuristic(state);
    }


    private int euclideanheuristic(GameState state)
    {
        int minDistance = 0;

        if (state.foods.Count > 0)
            minDistance = (int) Math.Sqrt(System.Math.Pow((state.pacmanPosition.X - state.foods[0].X), 2) + Math.Pow((state.pacmanPosition.Y - state.foods[0].Y), 2)); 

        for(int i = 1; i < state.foods.Count; i++)
        {
            int newDistance = (int)Math.Sqrt(System.Math.Pow((state.pacmanPosition.X - state.foods[i].X), 2) + Math.Pow((state.pacmanPosition.Y - state.foods[i].Y), 2));
            if (newDistance < minDistance)
                minDistance = newDistance;
        }


        return 0;
    }

    private int manhattanHeuristic(GameState state)
    {
        int minDistance = 0;

        if (state.foods.Count > 0)
            minDistance = Math.Abs(state.pacmanPosition.X - state.foods[0].X + state.pacmanPosition.Y - state.foods[0].Y);

        for (int i = 1; i < state.foods.Count; i++)
        {
            int newDistance = Math.Abs(state.pacmanPosition.X - state.foods[i].X + state.pacmanPosition.Y - state.foods[i].Y);
            if (newDistance < minDistance)
                minDistance = newDistance;
        }

        return 0;
    }

    private int ghostManhattanHeuristic(GameState state)
    {
        return Math.Abs(state.pacmanPosition.X - state.ghostPosition.X + state.pacmanPosition.Y - state.ghostPosition.Y);
    }


    void Update()
    {
        
    }
}
