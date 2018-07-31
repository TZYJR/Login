using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; }


    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }


    public User() { }


    /// <summary>
    /// 有参构造函数
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="passwrod"></param>
    public User(string userName, string passwrod)
    {
        this.Username = userName;
        this.Password = passwrod;
    }
}
