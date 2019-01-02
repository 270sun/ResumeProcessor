using System;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Web;
using Common;
using PictureServices.Core;
using PinJianHR.Common.TableModel;
using Xceed.Words.NET;

namespace ResumeProcessor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string job51 = "C:\\Users\\msun\\source\\repos\\ResumeProcessor\\ResumeProcessor\\简历模板\\51job简历-word\\";
            string tongcheng58 = "C:\\Users\\msun\\source\\repos\\ResumeProcessor\\ResumeProcessor\\简历模板\\58同城简历-mht\\";
            string zhilian = "C:\\Users\\msun\\source\\repos\\ResumeProcessor\\ResumeProcessor\\简历模板\\智联招聘简历-word\\";

            

            var files = Directory.EnumerateFiles(job51).Take(50).ToList();

            //DocX doc = DocX.Load(files[0]);


            files.ForEach(ParseInfo);

            Console.WriteLine();
            //HtmlElement
        }

        private static void ParseInfo(string path)
        {
            #region Generate MHT
//            var url = Path.ChangeExtension(path, ".mht");
//            if (!File.Exists(url))
//            {
//                File.Copy(path, url);
//            } 
            #endregion

            var text = File.ReadAllLines(path).Skip(11).ToList().TakeWhile(t=>!string.IsNullOrEmpty(t)).ToList();

            var ctext = string.Join("", text);

            var x = Base64.DecodeBase64(Encoding.GetEncoding("gb2312"), ctext);

            var listcontent = Utils.RemoveHtml(x).Replace("\r\n","\n")
                                .Split('\n').Select(t=>t.Trim()).ToList()
                                .Where(t=>!string.IsNullOrWhiteSpace(t))
                                .Where(t=>!t.StartsWith(".")).ToList();

            _resume resume = new _resume();
            _resumeBase resumeBase = new _resumeBase();

            var str17 = listcontent[17].Split(new[] {"&nbsp;"}, StringSplitOptions.RemoveEmptyEntries);
            var id = int.Parse(str17[0].Replace("ID:",""));
            var status = str17[1];
            var mobile = str17[2];
            var mail = str17[3].Contains("@") ? str17[3] : "";
            var checkmail = mail=="" ? 3 : 4;
            var genderName = str17[checkmail].Split('|')[0];
            var age = int.Parse(str17[checkmail].Split(new[] {"|", "（"}, StringSplitOptions.RemoveEmptyEntries)[1].Replace("岁",""));
            var birthtemp = str17[checkmail].Split(new[] {"（"}, StringSplitOptions.RemoveEmptyEntries)[1]
                            .Split(new []{"年","月","日"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var birth = new DateTime(birthtemp[0], birthtemp[1], birthtemp[2]);

            var wage = listcontent[30].GetString("期望薪资：", "元").Replace("期望薪资：", "").Split('-');
            var wagestart = int.Parse(wage[0]);
            var wageend = int.Parse(wage[1]);

            resume.resumeId = id;
            resumeBase.mail = mail;
            resumeBase.birthday = birth;
            resumeBase.genderName = genderName;
            resumeBase.wageStart = wagestart;
            resumeBase.wageEnd = wageend;
            resumeBase.mobile = mobile;

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

       // private static void 
    }
}
