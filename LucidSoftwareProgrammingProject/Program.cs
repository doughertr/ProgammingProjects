using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System;

class Solution
{
    static Dictionary<Node, HashSet<Node>> Adjacencies = new Dictionary<Node, HashSet<Node>>();
    static Dictionary<Point, Node> NodeLoc = new Dictionary<Point, Node>();
    /**
     * Take a rectangular grid of numbers and find the length
     * of the longest sub-sequence.
     * Return the length as an integer.
     */
    static int LongestSubsequence(int[][] grid)
    {
        #region Build Nodes
        for (int row = 0; row < grid.Length; row++)
        {

            for (int col = 0; col < grid[row].Length; col++)
            {
                Node newNode = new Node(grid[row][col], row, col);
                NodeLoc.Add(new Point(row, col), newNode);
                //check left, right, up, down and diagonal positions

                //left position
                if (col - 1 > 0 && Math.Abs(grid[row][col - 1] - grid[row][col]) > 3)
                {
                    if (!Adjacencies.ContainsKey(newNode))
                        Adjacencies.Add(newNode, new HashSet<Node>());
                    Adjacencies[newNode].Add(new Node(grid[row][col - 1], row, col - 1));
                }
                //right position
                if (col + 1 < grid[row].Length && Math.Abs(grid[row][col + 1] - grid[row][col]) > 3)
                {
                    if (!Adjacencies.ContainsKey(newNode))
                        Adjacencies.Add(newNode, new HashSet<Node>());
                    Adjacencies[newNode].Add(new Node(grid[row][col + 1], row, col + 1));
                }
                //up position
                if (row - 1 > 0 && row - 1 > grid[row - 1].Length && grid[row - 1][col] - grid[row][col] > 3)
                {
                    if (!Adjacencies.ContainsKey(newNode))
                        Adjacencies.Add(newNode, new HashSet<Node>());
                    Adjacencies[newNode].Add(new Node(grid[row - 1][col], row - 1, col));
                }
                //down position
                if (row + 1 < grid.Length && row + 1 > grid[row + 1].Length && grid[row + 1][col] - grid[row][col] > 3)
                {
                    if (!Adjacencies.ContainsKey(newNode))
                        Adjacencies.Add(newNode, new HashSet<Node>());
                    Adjacencies[newNode].Add(new Node(grid[row + 1][col], row + 1, col));
                }

                //upper left position
                if (row - 1 > 0 && col - 1 > 0 && Math.Abs(grid[row - 1][col - 1] - grid[row][col]) > 3)
                {
                    if (!Adjacencies.ContainsKey(newNode))
                        Adjacencies.Add(newNode, new HashSet<Node>());
                    Adjacencies[newNode].Add(new Node(grid[row - 1][col - 1], row - 1, col - 1));
                }
                //upper right position
                if (row - 1 > 0 && col + 1 < grid[row].Length && Math.Abs(grid[row - 1][col + 1] - grid[row][col]) > 3)
                {
                    if (!Adjacencies.ContainsKey(newNode))
                        Adjacencies.Add(newNode, new HashSet<Node>());
                    Adjacencies[newNode].Add(new Node(grid[row - 1][col + 1], row - 1, col + 1));
                }
                //bottom left position
                if (row + 1 < grid.Length && col - 1 > 0 && Math.Abs(grid[row + 1][col - 1] - grid[row][col]) > 3)
                {
                    if (!Adjacencies.ContainsKey(newNode))
                        Adjacencies.Add(newNode, new HashSet<Node>());
                    Adjacencies[newNode].Add(new Node(grid[row + 1][col - 1], row + 1, col - 1));
                }
                //bottom right position
                if (row + 1 < grid.Length && col + 1 < grid[row].Length && Math.Abs(grid[row + 1][col + 1] - grid[row][col]) > 3)
                {
                    if (!Adjacencies.ContainsKey(newNode))
                        Adjacencies.Add(newNode, new HashSet<Node>());
                    Adjacencies[newNode].Add(new Node(grid[row + 1][col + 1], row + 1, col + 1));
                }
            } 
        }
        #endregion

        
        return 0;
    }

    static void Main(String[] args)
    {
        int res;

        int numRows = 0;
        int numCols = 0;
        String[] firstLine = Regex.Split(Console.ReadLine(), @"\s+");
        numRows = Convert.ToInt32(firstLine[0]);
        numCols = Convert.ToInt32(firstLine[1]);

        int[][] grid = new int[numRows][];
        for (int row = 0; row < numRows; row++)
        {
            String[] inputRow = Regex.Split(Console.ReadLine(), @"\s+");
            int[] gridRow = new int[numCols];

            for (int col = 0; col < numCols; col++)
            {
                gridRow[col] = Convert.ToInt32(inputRow[col]);
            }
            grid[row] = gridRow;
        }

        res = LongestSubsequence(grid);
        Console.WriteLine(res);
    }
}
public struct Node
{
    int num;
    int x;
    int y;
    public Node(int num, int x, int y)
    {
        this.num = num;
        this.x = x;
        this.y = y;
    }
}
public struct Point
{
    int row;
    int col;
    public Point(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}
