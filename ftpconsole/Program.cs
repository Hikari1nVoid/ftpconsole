using System;
using System.IO;
using System.Net;

class Program
{
    static void Main()
    {
        // FTP 服务器上的中文文件
        string remoteFile = "ftp://ipaddr/测试文件.txt";

        // 本地保存文件的路径
        string localFile = "file.txt";

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteFile);
        request.Method = WebRequestMethods.Ftp.DownloadFile;

        // 设置 FTP 服务器的用户名和密码
        request.Credentials = new NetworkCredential("ideleteduser", "notreallyapassword");

        try
        {
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (FileStream writer = new FileStream(localFile, FileMode.Create))
            {
                responseStream.CopyTo(writer);
            }

            Console.WriteLine("文件下载成功");
        }
        catch (Exception e)
        {
            Console.WriteLine("文件下载失败，错误信息： " + e.Message);
        }
    }
}