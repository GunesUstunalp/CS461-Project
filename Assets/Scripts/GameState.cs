using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using System;

public class GameState
{
    public List<Point> walls = new List<Point>();
    public List<Point> foods = new List<Point>();
    public Point ghostPosition;
    public Point pacmanPosition;

    public int mapWidth, mapHeight;

    public GameState(List<Point> walls, List<Point> foods, Point ghostPosition, Point pacmanPosition, int mapWidth, int mapHeight)
    {
        this.walls = walls;
        this.foods = foods;
        this.pacmanPosition = pacmanPosition;
        this.mapHeight = mapHeight;
        this.mapWidth = mapWidth;
        this.ghostPosition = ghostPosition;
    }

    public GameState(Map mapO)
    {
        walls = new List<Point>();
        foods = new List<Point>();
        pacmanPosition = new Point();
        ghostPosition = new Point();

        for(int i = 0; i < mapO.map.Count; i++)
        {
            for(int j = 0; j < mapO.map[i].Count; j++)
            {
                if (mapO.map[i][j] == 'w')
                {
                    walls.Add(new Point(i, j));
                    //Debug.Log("Wall at (" + i + ", " + j + ")");
                }    
                else if (mapO.map[i][j] == 'f')
                {
                    foods.Add(new Point(i, j));
                    //Debug.Log("Food at (" + i + ", " + j + ")");
                }    
                else if( mapO.map[i][j] == 'p')
                {
                    pacmanPosition.X = i;
                    pacmanPosition.Y = j;
                    //Debug.Log("Pacman at " + pacmanPosition);
                }   
                else if( mapO.map[i][j] == 'g')
                {
                    ghostPosition.X = i;
                    ghostPosition.Y = j;
                }
            }
        }
        mapHeight = mapO.height;
        mapWidth = mapO.width;
    }


    public GameState() 
    {
        walls = new List<Point>();
        foods = new List<Point>();
        pacmanPosition = new Point();
        ghostPosition = new Point();
    }

    public List<Point> getNeighborsOfPoint(Point p)
    {
        List<Point> neighbors = new List<Point>();

        neighbors.Add(new Point(p.X, p.Y + 1));
        neighbors.Add(new Point(p.X, p.Y - 1));
        neighbors.Add(new Point(p.X + 1, p.Y));
        neighbors.Add(new Point(p.X - 1, p.Y));

        foreach (Point wall in walls)
        {
            if (neighbors.Contains(wall))
            {
                neighbors.Remove(wall);
            }
        }

        return neighbors;
    }

    public List<GameState> getSuccessors()
    {
        List<GameState> successors = new List<GameState>();

        List<Point> neighborsPacman = getNeighborsOfPoint(pacmanPosition);
        for(int i = 0; i < neighborsPacman.Count; i++)
        {
            List<Point> newFood = new List<Point>(foods);
            if (newFood.Contains(neighborsPacman[i]))
                newFood.Remove(neighborsPacman[i]);

            GameState successor = new GameState(walls, newFood, ghostPosition, neighborsPacman[i], mapWidth, mapHeight);
            successors.Add(successor);
        }

        return successors;
    }


    public List<GameState> getPacmanSuccessorsAdversarial()
    {
        List<GameState> successors = new List<GameState>();

        List<Point> neighborsPacman = getNeighborsOfPoint(pacmanPosition);
        for (int i = 0; i < neighborsPacman.Count; i++)
        {
            List<Point> newFood = new List<Point>(foods);
            if (newFood.Contains(neighborsPacman[i]))
                newFood.Remove(neighborsPacman[i]);

            if (ghostPosition != neighborsPacman[i])
            {
                GameState successor = new GameState(walls, newFood, ghostPosition, neighborsPacman[i], mapWidth, mapHeight);
                successors.Add(successor);
            }        
        }

        return successors;
    }

    public List<GameState> getGhostSuccessorAdversarial()
    {
        List<GameState> successors = new List<GameState>();

        List<Point> neighborsGhost = getNeighborsOfPoint(ghostPosition);
        for (int j = 0; j < neighborsGhost.Count; j++)
        {
                GameState successor = new GameState(walls, foods, neighborsGhost[j], pacmanPosition, mapWidth, mapHeight);
                successors.Add(successor);
        }

        return successors;
    }

    public void checkIfFoodEaten()
    {
        if (foods.Contains(pacmanPosition))
        {
            foods.Remove(pacmanPosition);
        }
    }

    public bool checkIfPacmanEaten()
    {
        if (ghostPosition.Equals(pacmanPosition))
            return true;

        return false;        
    }


    public bool isGoalState()
    {
        if (foods.Count < 1)
        {
            return true;
        }
        return false;
    }

    public bool Equals(GameState other)
    {
        if (pacmanPosition != other.pacmanPosition)
            return false;

        if (foods.Count != other.foods.Count)
            return false;

        for(int i = 0; i < foods.Count; i++)
        {
            if (foods[i] != other.foods[i])
                return false;
        }

        if (ghostPosition != other.ghostPosition)
            return false;

        return true;
    }


    public void printMapString() //For Debug
    {
        string map = "";
        for(int i = 0; i < mapWidth; i++)
        {
            for(int j = 0; j < mapHeight; j++)
            {
                Point tested = new Point(i, j);
                if (walls.Contains(tested))
                {
                    map += 'w';
                }
                else if (foods.Contains(tested))
                {
                    map += 'f';
                }
                else if (pacmanPosition == tested)
                {
                    map += 'p';
                }
                else if (ghostPosition == tested)
                    map += 'g';
                else
                    map += 'e';
            }
            map += "\n";
        }

        Debug.Log(map);
    }
}
