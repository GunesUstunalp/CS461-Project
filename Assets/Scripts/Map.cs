using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public List<List<char>> map;
    public int width;
    public int height;

    public Map(string mapName)
    {
        if (mapName.Equals("smallMap"))
        {
            map = new List<List<char>>() {
                new List<char>() { 'w', 'w', 'w', 'w', 'w' },
                new List<char>() { 'w', 'e', 'e', 'p', 'w' },
                new List<char>() { 'w', 'e', 'e', 'w', 'w' },
                new List<char>() { 'w', 'e', 'e', 'f', 'w' },
                new List<char>() { 'w', 'w', 'w', 'w', 'w' },
            };
            width = 5;
            height = 5;
        }
        else if (mapName.Equals("mediumMap"))
        {
            map = new List<List<char>>()
            {
                new List<char>() { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
                new List<char>() { 'w', 'p', 'e', 'e', 'f', 'e', 'e', 'w', 'f', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'w', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'w', 'w', 'w', 'w', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'f', 'e', 'e', 'e', 'w', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'w', 'w', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'f', 'w' },
                new List<char>() { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' }
            };
            width = 10;
            height = 10;
        }
        else if (mapName.Equals("largeMap"))
        {
            map = new List<List<char>>()
            {
                new List<char>() { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
                new List<char>() { 'w', 'p', 'e', 'e', 'f', 'e', 'e', 'w', 'f', 'e', 'e', 'w', 'f', 'w', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'w', 'w', 'w', 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'f', 'e', 'e', 'e', 'w', 'e', 'w', 'w', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'w', 'w', 'w', 'e', 'w', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w', 'e', 'e', 'w', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'f', 'w', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'w', 'w', 'w', 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'f', 'e', 'e', 'e', 'w', 'e', 'w', 'w', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'w', 'w', 'w', 'e', 'w', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w', 'e', 'e', 'w', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'f', 'w', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' }
            };
            width = 15;
            height = 15;
        }
        else if (mapName.Equals("hardMap"))
        {
            map = new List<List<char>>()
            {
                new List<char>() { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
                new List<char>() { 'w', 'p', 'e', 'e', 'f', 'e', 'e', 'w', 'f', 'w' },
                new List<char>() { 'w', 'e', 'w', 'e', 'e', 'e', 'w', 'w', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'w', 'w', 'w', 'w', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'w', 'f', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'w', 'e', 'w', 'w', 'w', 'e', 'w', 'w' },
                new List<char>() { 'w', 'e', 'w', 'w', 'f', 'w', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'w', 'e', 'w', 'f', 'w' },
                new List<char>() { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' }
            };
            width = 10;
            height = 10;
        }
        else if (mapName.Equals("ghostMediumMap"))
        {
            map = new List<List<char>>()
            {
                new List<char>() { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
                new List<char>() { 'w', 'p', 'e', 'e', 'f', 'e', 'e', 'w', 'f', 'w' },
                new List<char>() { 'w', 'e', 'w', 'e', 'e', 'e', 'w', 'w', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'g', 'w', 'w', 'w', 'w', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'w', 'f', 'e', 'e', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'w', 'e', 'w', 'w', 'w', 'e', 'w', 'w' },
                new List<char>() { 'w', 'e', 'w', 'w', 'f', 'w', 'e', 'e', 'e', 'w' },
                new List<char>() { 'w', 'e', 'e', 'e', 'e', 'w', 'e', 'w', 'f', 'w' },
                new List<char>() { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' }
            };
            width = 10;
            height = 10;
        }
        else if (mapName.Equals("ghostSmallMap"))
        {
            map = new List<List<char>>() {
                new List<char>() { 'w', 'w', 'w', 'w', 'w' },
                new List<char>() { 'w', 'e', 'e', 'p', 'w' },
                new List<char>() { 'w', 'e', 'e', 'w', 'w' },
                new List<char>() { 'w', 'g', 'e', 'f', 'w' },
                new List<char>() { 'w', 'w', 'w', 'w', 'w' },
            };
            width = 5;
            height = 5;
        }
    }
}
