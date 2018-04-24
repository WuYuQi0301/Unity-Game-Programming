using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskData : MonoBehaviour
{
    private Vector3 size { get; set; }
    private Color color { get; set; }
    private float speed { get; set; }
    private int score { get; set; }
    private Vector3 direction { get; set; }

    public void setDirection(Vector3 _direction)
    {
        this.direction = _direction;
    }
    public void setData(Vector3 _startLocation, Vector3 _size, Color _color ,float _speed ,int _score)
    {
        this.transform.position = _startLocation;
        this.color = _color;
        this.size = _size;
        this.speed = _speed;
        this.score = _score;
    }
    //因为不知道两个diskData直接比较会发生什么，干脆写个isEqual函数；
    public bool isEqual(DiskData _diskData)
    {
        return (this.color == _diskData.color && this.size == _diskData.size
            && this.speed == _diskData.speed && this.score == _diskData.score);
    }
    public Vector3 getDirection()
    {
        return direction;
    }
    public int getScore()
    {
        return score;
    }
    public Vector3 getSize()
    {
        return size;
    }
    public Color getColor()
    {
        return color;
    }
    public float getSpeed()
    {
        return speed;
    }
    // 返回this指针：允许连等
    public DiskData setScore(int _score)
    {
        score = _score;
        return this;
    }
    public DiskData setSpeed(float _speed)
    {
        speed = _speed;
        return this;
    }
    public DiskData setColor(Color _color)
    {
        color = _color;
        return this;
    }
    public DiskData setSize(Vector3 _size)
    {
        size = _size;
        return this;
    }
}
