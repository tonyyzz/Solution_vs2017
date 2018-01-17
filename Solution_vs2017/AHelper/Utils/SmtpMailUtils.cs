/*********************************************************
** File Name:	SmtpMailUtils.cs
** Copyright (C) 2016 TopWork. All right reserved.
** Creator:     ZHAOs
** Create date:	2017-05-09
** Description: 邮件帮助类
** Modifier:	
** Modify date:	
** Description:	
*********************************************************/

using System.Net;
using System.Net.Mail;
using System.Text;

namespace Auction.Utility.Utils
{
    public class SmtpMailUtils
    {
        /// <summary>
        /// SMTP服务器
        /// </summary>
        private string _domain { get; set; }
        /// <summary>
        /// SMTP服务器端口
        /// </summary>
        private int _port { get; set; }
        /// <summary>
        /// SMTP服务器用户密码
        /// </summary>
        private string _serverUserPassword { get; set; }
        /// <summary>
        /// SMTP服务器显示名称
        /// </summary>
        private string _serverUserName { get; set; }
        /// <summary>
        /// SMTP服务器发送邮件地址
        /// </summary>
        private string _serverMail { get; set; }

        public SmtpMailUtils(string domain, int port, string serverUserName, string serverUserPassword, string serverMail)
        {
            _domain = domain;
            _port = port;
            _serverUserName = serverUserName;
            _serverUserPassword = serverUserPassword;
            _serverMail = serverMail;
        }

        #region 公有方法
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">送达email</param>
        /// <param name="toName">送达名称</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="IsSSL">是否SSL</param>
        /// <returns></returns>
        public bool Send(string to, string toName, string subject, string body, bool isSSL = true)
        {
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(_serverUserName, _serverUserPassword);
            client.EnableSsl = isSSL;
            client.Port = _port;
            client.Host = _domain;
            try
            {
                var mail = GetMailInfo(to, toName, subject, body);
                client.Send(mail);
                mail.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 邮件信息
        /// </summary>
        /// <param name="to">收件人地址</param>
        /// <param name="toName">收件人名称</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <returns></returns>
        private MailMessage GetMailInfo(string to, string toName, string subject, string body)
        {
            var fromAddr = new MailAddress(_serverMail, _serverUserName, Encoding.UTF8);
            var toAddr = new MailAddress(to, toName, Encoding.UTF8);
            var message = new MailMessage(fromAddr, toAddr);
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = subject;
            message.SubjectEncoding = Encoding.UTF8;
            return message;
        }
        #endregion

    }
}
