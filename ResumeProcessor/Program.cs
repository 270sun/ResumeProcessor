using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using PictureServices.Core;
using PinJianHR.Common.TableModel;

namespace ResumeProcessor
{
    class Program
    {
        private static List<_resume> resumeList = new List<_resume>();
        private static List<_resumeBase> resumeBaseList = new List<_resumeBase>();

        [STAThread]
        static void Main(string[] args)
        {
            string job51 = "C:\\Users\\msun\\source\\repos\\ResumeProcessor\\ResumeProcessor\\简历模板\\51job简历-word\\";
            string tongcheng58 = "C:\\Users\\msun\\source\\repos\\ResumeProcessor\\ResumeProcessor\\简历模板\\58同城简历-mht\\";
            string zhilian = "C:\\Users\\msun\\source\\repos\\ResumeProcessor\\ResumeProcessor\\简历模板\\智联招聘简历-word\\";



            var files_job51 = Directory.EnumerateFiles(job51).ToList();
            var files_tongcheng58 = Directory.EnumerateFiles(tongcheng58).ToList();
            var files_zhiliang = Directory.EnumerateFiles(zhilian).ToList();

            //files_job51.ForEach(ParseInfo_job51);
            //files_tongcheng58.ForEach(ParseInfo_tongcheng58);
            files_zhiliang.ForEach(ParseInfo_zhilian);

            Console.WriteLine();
        }

        private static void ParseInfo_zhilian(string path)
        {
            var text = File.ReadAllLines(path)
                .Where(t=>!t.Contains("meta"))
                .Select(t=>t.Trim('\t')).ToList();

            var result = Utils.RemoveHtml(string.Join("", text))
                        .Split(new []{"应聘职位"}, StringSplitOptions.None)[1]
                        .Replace("&nbsp;"," ");

            while (result.Contains("  "))
            {
                result = result.Replace("  ", " ");
            }
        }

        private static void ParseInfo_job51(string path)
        {
            #region Generate MHT

//            var url = Path.ChangeExtension(path, ".mht");
//            if (!File.Exists(url))
//            {
//                File.Copy(path, url);
//            } 

            #endregion

            var text = File.ReadAllLines(path).Skip(11).ToList().TakeWhile(t => !string.IsNullOrEmpty(t)).ToList();

            var ctext = string.Join("", text);

            var x = Utils.DecodeBase64(Encoding.GetEncoding("gb2312"), ctext);

            var listcontent = Utils.RemoveHtml(x).Replace("\r\n", "\n")
                .Split('\n').Select(t => t.Trim()).ToList()
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Where(t => !t.StartsWith(".")).ToList();

            _resume resume = new _resume();
            _resumeBase resumeBase = new _resumeBase();

            var str17 = listcontent[17].Split(new[] {"&nbsp;"}, StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(str17[0].Replace("ID:", ""));
            var name = listcontent[16].GetSubString("&", "流程状态").Replace("&nbsp;", "");
            var status = str17[1];
            var mobile = str17[2];
            var mail = str17[3].Contains("@") ? str17[3] : "";
            var checkMail = mail == "" ? 3 : 4;
            var genderName = str17[checkMail].Split('|')[0];
            var age = int.Parse(str17[checkMail].Split(new[] {"|", "（"}, StringSplitOptions.RemoveEmptyEntries)[1]
                .Replace("岁", ""));
            var birthTemp = str17[checkMail].Split(new[] {"（"}, StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(new[] {"年", "月", "日"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var birth = new DateTime(birthTemp[0], birthTemp[1], birthTemp[2]);

            var wage = listcontent.FirstOrDefault(t => t.Contains("期望薪资"))?.GetSubString("期望薪资：", "元").Replace("期望薪资：", "")
                .Split('-');
            int wageStart, wageEnd;
            if (wage == null)
            {
                wageStart = 0;
                wageEnd = 0;
            }
            else if (wage[0].Contains("以下"))
            {
                wageStart = 0;
                wageEnd = int.Parse(wage[0].Replace("以下", ""));
            }
            else
            {
                var coefficient = (wage.Any(t => t.Contains("万")) ? 10000 : 1);
                wageStart = coefficient * int.Parse(wage[0].Replace("万", ""));
                wageEnd = coefficient * int.Parse(wage[1].Replace("万", ""));
            }

            resume.resumeId = id;
            resume.name = name;

            resumeBase.resumeId = id;
            resumeBase.name = name;
            resumeBase.mail = mail;
            resumeBase.birthday = birth;
            resumeBase.genderName = genderName;
            resumeBase.wageStart = wageStart;
            resumeBase.wageEnd = wageEnd;
            resumeBase.mobile = mobile;

            resumeList.Add(resume);
            resumeBaseList.Add(resumeBase);

            Console.WriteLine(id);

//            WebBrowser web = new WebBrowser();
//            web.Navigate(url);
//            HtmlDocument htmldoc = web.Document;
//
//            int i = 0;
//            while (web.ReadyState < WebBrowserReadyState.Complete)
//            {
//                Console.WriteLine("Hello");
//                Thread.Sleep(1000);
//                i++;
//                if (i == 5) break;
//            }

        }

        private static void ParseInfo_tongcheng58(string path)
        {

            var text = File.ReadAllLines(path)
                        .Select(t=>t.Replace("=","%"))
                        .Select(Utils.UrlDecode)
                        .Select(t=>Encoding.GetEncoding("gb2312").GetString(Encoding.GetEncoding("gb2312").GetBytes(t)))
                        .ToList();

            WebBrowser web = new WebBrowser();
            web.Url = new Uri(path);

//            web.DocumentCompleted += (sender, args) =>
//                web.Document.Window.Error += (sender1, args1) => args1.Handled = true;
           // web.Url = new Uri(path);
            //Thread.Sleep(1000);
            HtmlElement elem;
//            if (web.Document != null)
//            {
//                var webDocumentText = web.DocumentText;
//                HtmlElementCollection elems = web.Document.GetElementsByTagName("HTML");
//
//            }
        }
    }
}