using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

//Class from previous CST Class
namespace Milestone.Models
{
    public class Field
    {
        int Size = 10;
        // choose some places on the field to plant mines.
        public void MakeMines(List<Space> buttons)
        {
            // place some mines on the field at random locations.
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {              
                buttons.ElementAt(rand.Next(100)).CurrentlyOccupied = true;
            } 
        }


        // helper function to determine whether or not a space is actually in bounds.  valid or not.
        public bool IsSafe(int a, int b)
        {
            if (a < 0 || a >= Size )
            {
                return false;
            }
            else if (b < 0 || b >= Size)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Space> mineCheck(List<Space> buttons)
        {
            Space[,] theGrid = new Space[10, 10];
            int k = 0;
            for (int X = 0; X < 10; X++)
            {
                for (int Y = 0; Y < 10; Y++)
                {
                    theGrid[X, Y] = buttons[k];
                    k++;
                }
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Space currentSpace = new Space(i, j);
                    if (IsSafe(currentSpace.row + 1, currentSpace.col))
                    {
                        if (theGrid[currentSpace.row + 1, currentSpace.col].CurrentlyOccupied == true)
                        {
                            theGrid[currentSpace.row, currentSpace.col].BombNear++;
                        }
                    }
                    if (IsSafe(currentSpace.row - 1, currentSpace.col))
                    {
                        if (theGrid[currentSpace.row - 1, currentSpace.col].CurrentlyOccupied == true)
                        {
                            theGrid[currentSpace.row, currentSpace.col].BombNear++;
                        }
                    }
                    if (IsSafe(currentSpace.row + 1, currentSpace.col + 1))
                    {
                        if (theGrid[currentSpace.row + 1, currentSpace.col + 1].CurrentlyOccupied == true)
                        {
                            theGrid[currentSpace.row, currentSpace.col].BombNear++;
                        }
                    }
                    if (IsSafe(currentSpace.row - 1, currentSpace.col + 1))
                    {
                        if (theGrid[currentSpace.row - 1, currentSpace.col + 1].CurrentlyOccupied == true)
                        {
                            theGrid[currentSpace.row, currentSpace.col].BombNear++;
                        }
                    }
                    if (IsSafe(currentSpace.row, currentSpace.col + 1))
                    {
                        if (theGrid[currentSpace.row, currentSpace.col + 1].CurrentlyOccupied == true)
                        {
                            theGrid[currentSpace.row, currentSpace.col].BombNear++;
                        }
                    }
                    if (IsSafe(currentSpace.row, currentSpace.col - 1))
                    {
                        if (theGrid[currentSpace.row, currentSpace.col - 1].CurrentlyOccupied == true)
                        {
                            theGrid[currentSpace.row, currentSpace.col].BombNear++;
                        }
                    }
                    if (IsSafe(currentSpace.row + 1, currentSpace.col - 1))
                    {
                        if (theGrid[currentSpace.row + 1, currentSpace.col - 1].CurrentlyOccupied == true)
                        {
                            theGrid[currentSpace.row, currentSpace.col].BombNear++;
                        }
                    }
                    if (IsSafe(currentSpace.row - 1, currentSpace.col - 1))
                    {
                        if (theGrid[currentSpace.row - 1, currentSpace.col - 1].CurrentlyOccupied == true)
                        {
                            theGrid[currentSpace.row, currentSpace.col].BombNear++;
                        }
                    }
                }
            }
            buttons = new List<Space>();
            k = 0;
            for (int X = 0; X < 10; X++)
            {
                for (int Y = 0; Y < 10; Y++)
                {
                    buttons.Add(theGrid[X,Y]);
                    k++;
                }
            }
            return buttons;
        }
        public void floodFill(int r, int c, List<Space> buttons)
        {
            Space[,] theGrid = new Space[10, 10];
            int k = 0;
            for (int X = 0; X < 10; X++)
            {
                for (int Y = 0; Y < 10; Y++)
                {
                    theGrid[X, Y] = buttons[k];
                    k++;
                }
            }
            if (IsSafe(r, c) && theGrid[r, c].BombNear.Equals(0) && theGrid[r, c].visited == false)
            {
                
                theGrid[r, c].visited = true;

                buttons = new List<Space>();
                k = 0;
                for (int X = 0; X < 10; X++)
                {
                    for (int Y = 0; Y < 10; Y++)
                    {
                        buttons[k] = theGrid[X, Y];
                        k++;
                    }
                }

                // apply the cell to the south (r + 1)
                floodFill(r + 1, c, buttons);
                // apply the cell to the north (r - 1)
                floodFill(r - 1, c, buttons);
                // apply the cell to the south (c + 1)
                floodFill(r, c + 1, buttons);
                // apply the cell to the south (c - 1)
                floodFill(r, c - 1, buttons);
                // apply the cell to the south (r + 1)
                floodFill(r + 1, c + 1, buttons);
                // apply the cell to the north (r - 1)
                floodFill(r - 1, c - 1, buttons);
                // apply the cell to the south (c + 1)
                floodFill(r - 1, c + 1, buttons);
                // apply the cell to the south (c - 1)
                floodFill(r + 1, c - 1, buttons);
            }
        }

    }
}
