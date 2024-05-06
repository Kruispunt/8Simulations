using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectieReal
{

    public int autolampen = 21;
    //makes the direction
    public Vector3 start;
    public Vector3 end;

    public Directies directies = new Directies();

    //geen getallen achter de komma
    public DutchDirection getDutchDirection(int num, int typeNum)
    {
        DutchDirection direction = bigSwitchCaseUniversalDutch(num - typeNum);
        return direction;
    }


        //geen getallen achter de komma
        public void setDirectionReal(int num)
    {
        //auto nummers 
        if (num >= 0 && num < 21)
        {
            bigSwitchCaseAuto(num);

        }
        //fiets nummers

        if(num >= 21 && num < 31)
        {
            bigSwitchCaseFiets(num);
        }
        if (num >= 31 && num < 41)
        {
            bigSwitchCaseVoetganger(num);
        }
        //ov
        if(num >= 41 && num < 61)
        {
            bigSwitchCaseOv(num);
        }
        //nieuw punt binnen 150 meter + 60
        if(num >= 61 && num < 81)
        {
            bigSwitchCaseAutoInGroup(num);
        }
        if(num >= 81 && num < 91)
        {
            bigSwitchCaseFietserInGroup(num);
        }
        if(num >= 91 && num < 101)    
        {
            bigSwitchCaseVoetgangsterInGroup(num);
        }
        //linked second group within the context of the same controller 
        //+100 each time it happens
        if(num >= 101)
        {
            bigSwitchConnectedUnderSameControllerAuto(num);
        }
        //kan tot 300............ dit is genoeg
    }

    public DutchDirection bigSwitchCaseUniversalDutch(int num)
    {

        //alle mogelijke richtingen
        switch (num)
        {
            case (1):
                //
                start = directies.East;
                end = directies.North;
                return new DutchDirection(start, end);

                break;
            case 2:
                start = directies.East;
                end = directies.West;
                return new DutchDirection(start, end);
                break;
            case 3:
                start = directies.East;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 4:
                start = directies.South;
                end = directies.East;
                return new DutchDirection(start, end);
                break;
            case 5:
                start = directies.South;
                end = directies.North;
                return new DutchDirection(start, end);
                break;
            case 6:
                start = directies.South;
                end = directies.West;
                return new DutchDirection(start, end);
                break;
            case 7:
                start = directies.West;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 8:
                start = directies.West;
                end = directies.East;
                return new DutchDirection(start, end);
                break;
            case 9:
                start = directies.West;
                end = directies.North;
                return new DutchDirection(start, end);
                break;
            case 10:
                start = directies.North;
                end = directies.West;
                return new DutchDirection(start, end);
                break;
            case 11:
                start = directies.North;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 12:
                start = directies.North;
                end = directies.East;
                return new DutchDirection(start, end);

        }
        return new DutchDirection(start, end);

    }
    public DutchDirection bigSwitchCaseAutoDutch(int num)
    {

        //alle mogelijke richtingen
        switch (num)
        {
            case 1:
                //
                start = directies.East;
                end = directies.North;
                return new DutchDirection(start, end);
                
                break;
            case 2:
                start = directies.East;
                end = directies.West;
                return new DutchDirection(start, end);
                break;
            case 3:
                start = directies.East;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 4:
                start = directies.South;
                end = directies.East;
                return new DutchDirection(start, end);
                break;
            case 5:
                start = directies.South;
                end = directies.North;
                return new DutchDirection(start, end);
                break;
            case 6:
                start = directies.South;
                end = directies.West;
                return new DutchDirection(start, end);
                break;
            case 7:
                start = directies.West;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 8:
                start = directies.West;
                end = directies.East;
                return new DutchDirection(start, end);
                break;
            case 9:
                start = directies.West;
                end = directies.North;
                return new DutchDirection(start, end);
                break;
            case 10:
                start = directies.North;
                end = directies.West;
                return new DutchDirection(start, end);
                break;
            case 11:
                start = directies.North;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 12:
                start = directies.North;
                end = directies.East;
                return new DutchDirection(start, end);

        }
        return new DutchDirection(start, end);

    }
    public void bigSwitchCaseAuto(int num)
    {

        //alle mogelijke richtingen
        switch (num)
        {
            case 1:
                //
                start = directies.East;
                end = directies.North;
                break;
            case 2:
                start = directies.East;
                end = directies.West;
                break;
            case 3:
                start = directies.East;
                end = directies.South;
                break;
            case 4:
                start = directies.South;
                end = directies.East;
                break;
            case 5:
                start = directies.South;
                end = directies.North;
                break;
            case 6:
                start = directies.South;
                end = directies.West;
                break;
            case 7:
                start = directies.West;
                end = directies.South;
                break;
            case 8:
                start = directies.West;
                end = directies.East;
                break;
            case 9:
                start = directies.West;
                end = directies.North;
                break;
            case 10:
                start = directies.North;
                end = directies.West;
                break;
            case 11:
                start = directies.North;
                end = directies.South;
                break;
            case 12:
                start = directies.North;
                end = directies.East;
                break;

        }

    }

    public DutchDirection bigSwitchCaseFietsDutch(int num)
    {
        //fietsen hebben halve paden
        //vanwege onderbrekingen hebben kunnen er twee helfden zijn voor een route
        switch (num)
        {

            case 21:
                start = directies.South;
                end = directies.North;
                return new DutchDirection(start, end);
                break;
            case 22:
                start = directies.South;
                end = directies.North;
                return new DutchDirection(start, end);
                break;
            case 23:
                start = directies.West;
                end = directies.East;
                return new DutchDirection(start, end);
                break;
            case 24:
                start = directies.West;
                end = directies.East;
                return new DutchDirection(start, end);
                break;
            case 25:
                start = directies.North;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 26:
                start = directies.North;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 27:
                start = directies.East;
                end = directies.West;
                return new DutchDirection(start, end);
                break;
            case 28:
                start = directies.East;
                end = directies.West;
                return new DutchDirection(start, end);
                break;

        }
        return new DutchDirection(start, end);


    }

    //enzelfde situatie geldt bij fietsverkeer en voetgangers.
    //Wanneer een middenberm ontbreekt dan wordt bij fietsverkeer in de regel
    //het hoogste nummer gekozen, bij voetgangers meestal het laagste nummer.
    public void bigSwitchCaseFiets(int num)
    {
        //fietsen hebben halve paden
        //vanwege onderbrekingen hebben kunnen er twee helfden zijn voor een route
        switch (num)
        {

            case 21:
                start = directies.South;
                end = directies.North;
                break;
            case 22:
                start = directies.South;
                end = directies.North;
                break;
            case 23:
                start = directies.West;
                end = directies.East;
                break;
            case 24:
                start = directies.West;
                end = directies.East;
                break;
            case 25:
                start = directies.North;
                end = directies.South;
                break;
            case 26:
                start = directies.North;
                end = directies.South;
                break;
            case 27:
                start = directies.East;
                end = directies.West;
                break;
            case 28:
                start = directies.East;
                end = directies.West;
                break;

        }


    }
    //voetgang pad lamp
    public void bigSwitchCaseVoetganger(int num)
    { 
        switch (num)
        {
            case 31:
                start = directies.South;
                end = directies.North;
                break;
            case 32:
                start = directies.South;
                end = directies.North;
                break;
            case 33:
                start = directies.West;
                end = directies.East;
                break;
            case 34:
                start = directies.West;
                end = directies.East;
                break;
            case 35:
                start = directies.North;
                end = directies.South;
                break;
            case 36:
                start = directies.North;
                end = directies.South;
                break;
            case 37:
                start = directies.East;
                end = directies.West;
                break;
            case 38:
                start = directies.East;
                end = directies.West;
                break;

        }
    
    
    }
    public DutchDirection bigSwitchCaseVoetgangerDutch(int num)
    {
        switch (num)
        {
            case 31:
                start = directies.South;
                end = directies.North;
                return new DutchDirection(start, end);
                break;
            case 32:
                start = directies.South;
                end = directies.North;
                return new DutchDirection(start, end);
                break;
            case 33:
                start = directies.West;
                end = directies.East;
                return new DutchDirection(start, end);
                break;
            case 34:
                start = directies.West;
                end = directies.East;
                return new DutchDirection(start, end);
                break;
            case 35:
                start = directies.North;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 36:
                start = directies.North;
                end = directies.South;
                return new DutchDirection(start, end);
                break;
            case 37:
                start = directies.East;
                end = directies.West;
                return new DutchDirection(start, end);
                break;
            case 38:
                start = directies.East;
                end = directies.West;
                return new DutchDirection(start, end);
                

        }
        return new DutchDirection(start, end);



    }
    //de bus en soortgelijke voertuigen met een apparaatje
    public void bigSwitchCaseOv(int num)
    { 
        //alle mogelijke richtingen
        switch (num)
        {
            case 41:
                //
                start = directies.East;
                end = directies.North;
                break;
            case 42:
                start = directies.East;
                end = directies.West;
                break;
            case 43:
                start = directies.East;
                end = directies.South;
                break;
            case 44:
                start = directies.South;
                end = directies.East;
                break;
            case 45:
                start = directies.South;
                end = directies.North;
                break;
            case 46:
                start = directies.South;
                end = directies.West;
                break;
            case 47:
                start = directies.West;
                end = directies.South;
                break;
            case 48:
                start = directies.West;
                end = directies.East;
                break;
            case 49:
                start = directies.West;
                end = directies.North;
                break;
            case 50:
                start = directies.North;
                end = directies.West;
                break;
            case 51:
                start = directies.North;
                end = directies.South;
                break;
            case 52:
                start = directies.North;
                end = directies.East;
                break;

        }
    
    }
    public void bigSwitchCaseAutoInGroup(int num)
    {
        //alle mogelijke richtingen
        switch (num)
        {
            case 61:
                //
                start = directies.East;
                end = directies.North;
                break;
            case 62:
                start = directies.East;
                end = directies.West;
                break;
            case 63:
                start = directies.East;
                end = directies.South;
                break;
            case 64:
                start = directies.South;
                end = directies.East;
                break;
            case 65:
                start = directies.South;
                end = directies.North;
                break;
            case 66:
                start = directies.South;
                end = directies.West;
                break;
            case 67:
                start = directies.West;
                end = directies.South;
                break;
            case 68:
                start = directies.West;
                end = directies.East;
                break;
            case 69:
                start = directies.West;
                end = directies.North;
                break;
            case 70:
                start = directies.North;
                end = directies.West;
                break;
            case 71:
                start = directies.North;
                end = directies.South;
                break;
            case 72:
                start = directies.North;
                end = directies.East;
                break;

        }

    }
    //binnen 150 meter
    public void bigSwitchCaseFietserInGroup(int num)
    {

        switch (num)
        {

            case 81:
                start = directies.South;
                end = directies.North;
                break;
            case 82:
                start = directies.South;
                end = directies.North;
                break;
            case 83:
                start = directies.West;
                end = directies.East;
                break;
            case 84:
                start = directies.West;
                end = directies.East;
                break;
            case 85:
                start = directies.North;
                end = directies.South;
                break;
            case 86:
                start = directies.North;
                end = directies.South;
                break;
            case 87:
                start = directies.East;
                end = directies.West;
                break;
            case 88:
                start = directies.East;
                end = directies.West;
                break;

        }

    }

    //binnen 150 meter
    public void bigSwitchCaseVoetgangsterInGroup(int num)
    {
        switch (num)
        {
            case 91:
                start = directies.South;
                end = directies.North;
                break;
            case 92:
                start = directies.South;
                end = directies.North;
                break;
            case 93:
                start = directies.West;
                end = directies.East;
                break;
            case 94:
                start = directies.West;
                end = directies.East;
                break;
            case 95:
                start = directies.North;
                end = directies.South;
                break;
            case 96:
                start = directies.North;
                end = directies.South;
                break;
            case 97:
                start = directies.East;
                end = directies.West;
                break;
            case 98:
                start = directies.East;
                end = directies.West;
                break;

        }
    }

    public void bigSwitchConnectedUnderSameControllerAuto(int num)
    {
        //alle mogelijke richtingen
        switch (num)
        {
            case 101:
                //
                start = directies.East;
                end = directies.North;
                break;
            case 102:
                start = directies.East;
                end = directies.West;
                break;
            case 103:
                start = directies.East;
                end = directies.South;
                break;
            case 104:
                start = directies.South;
                end = directies.East;
                break;
            case 105:
                start = directies.South;
                end = directies.North;
                break;
            case 106:
                start = directies.South;
                end = directies.West;
                break;
            case 107:
                start = directies.West;
                end = directies.South;
                break;
            case 108:
                start = directies.West;
                end = directies.East;
                break;
            case 109:
                start = directies.West;
                end = directies.North;
                break;
            case 110:
                start = directies.North;
                end = directies.West;
                break;
            case 111:
                start = directies.North;
                end = directies.South;
                break;
            case 112:
                start = directies.North;
                end = directies.East;
                break;
            }   
        }
    }


public class DutchDirection
{
    public Vector3 start;
    public Vector3 end;
    public DutchDirection(Vector3 start, Vector3 end)
    {
        this.start = start;
        this.end = end;
    }
}

public static class DirectionMaker
{
    public static DirectieReal DirectieReal = new DirectieReal();
    public static DutchDirection GetDutchDirection(int num, int type)
    {
        return DirectieReal.getDutchDirection(num, type);
    }
}