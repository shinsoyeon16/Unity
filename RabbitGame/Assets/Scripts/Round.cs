using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Round
{
    private int _round;

    public int round
    {
        get { return _round; }
        set { _round = value; }
    }
    private int _limitTime;

    public int limitTime
    {
        get { return _limitTime; }
        set { _limitTime = value; }
    }
    private float _rabbitMoveSpeed;

    public float rabbitMoveSpeed
    {
        get { return _rabbitMoveSpeed; }
        set { _rabbitMoveSpeed = value; }
    }
    private float _rabbitJumpSpeed;

    public float rabbitJumpSpeed
    {
        get { return _rabbitJumpSpeed; }
        set { _rabbitJumpSpeed = value; }
    }

    public Round(int round, int limitTime, float rabbitMoveSpeed, float rabbitJumpSpeed)
    {
        _round = round;
        _limitTime = limitTime;
        _rabbitMoveSpeed = rabbitMoveSpeed;
        _rabbitJumpSpeed = rabbitJumpSpeed;
    }
}

