using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class LoginPanelManager : MonoBehaviour {

    [SerializeField]
    private Text userName;
    [SerializeField]
    private Text password;
    [SerializeField]
    private Button loginBtn;
    [SerializeField]
    private Button regBtn;
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private Button eyeBtn;


    private User user;




    void Start()
    {
        //绑定事件
        loginBtn.onClick.AddListener(OnLoginBtnClick);
        regBtn.onClick.AddListener(OnRegBtnClick);
        eyeBtn.onClick.AddListener(OnEyeBtnClick);
    }



    /// <summary>
    /// 登录按钮点击事件
    /// </summary>
    public void OnLoginBtnClick()
    {
        //从UI控件获取用户名和密码的string
        string m_userName = userName.text.Trim();
        string m_password = password.text.Trim();


        //对用户名和密码的string进行判断，判断这个是否为空，如果为空，进行提示
        if (m_userName == string.Empty || m_password == string.Empty)
        {
            dialogText.text = string.Format("用户名或密码为空");
            return;
        }



        //将这个用户名和密码写入一个用户名的类实例中
        user = new User(m_userName, m_password);



        //对这个User实例类进行判断，是否包含在静态类的用户集合中
        if (GameManager.Users.Contains(user))
        {
            SceneManager.LoadScene("qiyue02");
        }
        else
        {
            //如果没有这用户，进行提示
            dialogText.text = string.Format("用户名或密码不正确");
        }

    }


    /// <summary>
    /// 注册按钮事件
    /// </summary>
    public void OnRegBtnClick()
    {

        //和登录按钮相同
        string m_userName = userName.text.Trim();
        string m_password = password.text.Trim();

        if (m_userName == string.Empty || m_password == string.Empty)
        {
            dialogText.text = string.Format("用户名或密码为空");
            return;
        }
        user = new User(m_userName, m_password);



        //判断是否有该用户
        if (GameManager.Users.Contains(user))
        {
            dialogText.text = string.Format("用户名已存在");
        }
        else
        {
            GameManager.Users.Add(user);
            dialogText.text = string.Format("注册成功");
        }

    }


    /// <summary>
    /// 显示隐藏密码按钮事件
    /// </summary>
    public void OnEyeBtnClick()
    {
        //获取密码输入框组件
        InputField passwordInput = password.transform.parent.GetComponent<InputField>();
        //判断按钮的text是否为hide或者show
        if (eyeBtn.transform.GetChild(0).GetComponent<Text>().text == "hide")
        {
            //更改密码输入框组件的inputtype属性为标准类型
            passwordInput.inputType = InputField.InputType.Standard;
            //同时更改按钮内容
            eyeBtn.transform.GetChild(0).GetComponent<Text>().text = "show";
        }
        else
        {
            //与上相反！
            passwordInput.inputType = InputField.InputType.Password;
            eyeBtn.transform.GetChild(0).GetComponent<Text>().text = "hide";
        }

    }
}
