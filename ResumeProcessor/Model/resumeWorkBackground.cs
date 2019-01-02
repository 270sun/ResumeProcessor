using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PinJianHR.Common.TableModel
{
    [DisplayName("工作经历")]
    public class _resumeWorkBackground
    {
        [DisplayName("Id")]
        public int resumeWorkBackgroundId { get; set; }

        [DisplayName("所属简历")]
        public int resumeId { get; set; }

        [DisplayName("开始时间")]
        public DateTime beginTime { get; set; }

        [DisplayName("结束时间")]
        public DateTime endTime { get; set; }

        [DisplayName("公司名称")]
        public string companyName { get; set; }

        [DisplayName("职位")]
        public string position { get; set; }

        [DisplayName("工作类型")]
        public int jobType { get; set; }

        [DisplayName("工作类型名称")]
        public string jobTypeName { get; set; }

        [DisplayName("描述")]
        public string description { get; set; }

        [DisplayName("删除")]
        public bool isDel { get; set; }

        [DisplayName("resumeName")]
        public string resumeName { get; set; }

    }
}
