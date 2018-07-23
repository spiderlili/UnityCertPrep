using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum(enumerations) = special datatype that has a specific subset of possible const values - allows words in place of an int or a const
//makes it easier for code + mode readable as a set of consts
//can create enum either inside/outside of the class - place inside the class if only that class needed access to it, outside if other classes also need access
public class EnumScript : MonoBehaviour {

    //typically start enums with a capital letter because declaring a type not a var
    enum Direction {North, South, East, West};

    //choosable dropdown
    public enum LevelOfDifficulty { easy = 0, medium = 2, hard = 4, nightmare = 6 }; 
    
    //need to have the same access type as enum
    public LevelOfDifficulty levelOfDifficulty = LevelOfDifficulty.easy;

    void Start()
    {
        levelOfDifficulty = LevelOfDifficulty.medium;
        Debug.Log("starting level of difficulty: " + levelOfDifficulty);
        Direction myDirection;
        myDirection = Direction.North;
    }

        //enums can be passed into and returned from functions: return type is direction
        Direction ReverseDirection(Direction dir)
        {
            if (dir == Direction.North)
                dir = Direction.South;
            else if (dir == Direction.South)
                dir = Direction.North;
            else if (dir == Direction.East)
                dir = Direction.West;
            else if (dir == Direction.West)
                dir = Direction.East;

            return dir;
        }
	}
	
