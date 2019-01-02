using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PinJianHR.Common.TableModel
{
    [DisplayName("简历")]
    public class _resume
    {
        [DisplayName("Id")]
        public int resumeId { get; set; }

        [DisplayName("姓名")]
        public string name { get; set; }

        [DisplayName("删除")]
        public bool isDel { get; set; }
    }

    [Serializable]
    public class _memberResumeModel:_resumeBase
    {
        public int postCount { get; set; }

        public int readCount { get; set; }
    }

    public enum jobType
    {
        [Description("全职")] allTime = 1,
        [Description("兼职")] partTime = 2
    }
}
