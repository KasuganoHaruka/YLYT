using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Entitys
{
    public class ResponseJson
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 定义消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        public ResponseJson()
        {
            this.State = StateEnum.Success.ToString();
            this.Message = "";
            this.Data = "[]";
        }

        public ResponseJson(string Message)
        {
            this.State = StateEnum.Success.ToString();
            this.Message = Message;
            this.Data = "[]";
        }

        public ResponseJson(string Message, object Data)
        {
            this.State = StateEnum.Success.ToString();
            this.Message = Message;
            this.Data = Data;
        }

        public ResponseJson(StateEnum State, string Message)
        {
            this.State = State.ToString();
            this.Message = Message;
            this.Data = "[]";
        }

        public ResponseJson(StateEnum State, string Message, object Data)
        {
            this.State = State.ToString();
            this.Message = Message;
            this.Data = Data;
        }
    }

    /// <summary>
    /// 返回客户端调用状态
    /// </summary>
    public enum StateEnum
    {
        /// <summary>
        /// 成功 
        /// </summary>
        Success,
        /// <summary>
        /// 失败
        /// </summary>
        Fail,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 登录过期或者未登录
        /// </summary>
        NoLogin,
    }
}
