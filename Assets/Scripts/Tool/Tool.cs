using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 工具类，提供自定义的各种方法
/// </summary>
public static class Tool
{
    /// <summary>
    /// 获取两个数之间的一个随机整数
    /// </summary>
    /// <param name="min">最小值</param>
    /// <param name="max">最大值</param>
    /// <returns></returns>
    public static int GetRandomNumber(int min, int max) => Random.Range(min, max);
    /// <summary>
    /// 获取两个数之间的一个随机浮点数
    /// </summary>
    /// <param name="min">最小值</param>
    /// <param name="max">最大值</param>
    /// <returns></returns>
    public static float GetRandomNumber(float min, float max) => Random.Range(min, max);
    /// <summary>
    /// 从两个数字中返回随机的一个数字，整型
    /// </summary>
    /// <param name="num1">数字一</param>
    /// <param name="num2">数字二</param>
    /// <returns></returns>
    public static int GetNumberFromNumbers(int num1, int num2)
    {
        if (Random.Range(0f, 1f) > 0.5f)
        {
            return num1;
        }
        else
        {
            return num2;
        }
    }
    /// <summary>
    /// 从两个数字中返回随机的一个数字，浮点型
    /// /// </summary>
    /// <param name="num1">数字一</param>
    /// <param name="num2">数字二</param>
    /// <returns></returns>
    public static float GetNumberFromNumbers(float num1, float num2)
    {
        if (Random.Range(0f, 1f) > 0.5f)
        {
            return num1;
        }
        else
        {
            return num2;
        }
    }
    /// <summary>
    /// 从三个数中随机返回其中的一个，整型
    /// </summary>
    /// <param name="num1">数字一</param>
    /// <param name="num2">数字二</param>
    /// <param name="num3">数字三</param>
    /// <returns></returns>
    public static int GetNumberFromNumbers(int num1, int num2, int num3)
    {
        if (Random.Range(0, 3) == 0)
        {
            return num1;
        }
        else if (Random.Range(0, 3) == 1)
        {
            return num2;
        }
        else
        {
            return num3;
        }
    }
    /// <summary>
    /// 从三个数中随机返回其中的一个浮点型
    /// </summary>
    /// <param name="num1">数字一</param>
    /// <param name="num2">数字二</param>
    /// <param name="num3">数字三</param>
    /// <returns></returns>
    public static float GetNumberFromNumbers(float num1, float num2, float num3)
    {
        if (Random.Range(0, 3) == 0)
        {
            return num1;
        }
        else if (Random.Range(0, 3) == 1)
        {
            return num2;
        }
        else
        {
            return num3;
        }
    }
}
