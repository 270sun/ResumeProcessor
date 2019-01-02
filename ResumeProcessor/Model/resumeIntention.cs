using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PinJianHR.Common.TableModel
{
    [DisplayName("求职意向")]
    public class _resumeIntention
    {
        [DisplayName("Id")]
        public int resumeIntentionId { get; set; }
        [DisplayName("所属简历")]
        public int resumeId { get; set; }
        [DisplayName("省")]
        public int provinceId { get; set; }

        [DisplayName("期望省")]
        public string province { get; set; }

        [DisplayName("期望市区")]
        public int cityId { get; set; }

        [DisplayName("期望省")]
        public string city { get; set; }

        [DisplayName("期望职位")]
        public string position { get; set; }

        [DisplayName("期望月薪")]
        public decimal monthlySalary { get; set; }

        [DisplayName("上班日期")]
        public DateTime? jobTime { get; set; }

        [DisplayName("自我评价")]
        public string description { get; set; }

        [DisplayName("工作类型")]
        public int jobType { get; set; }

        [DisplayName("状态")]
        public int state { get; set; }

        [DisplayName("删除")]
        public bool isDel { get; set; }


        [DisplayName("工作类型名称")]
        public string jobTypeName { get; set; }

        [DisplayName("状态名称")]
        public string stateName { get; set; }


        [DisplayName("简历名称呢")]
        public string resumeName { get; set; }

    }

    public enum resumeIntentionState
    {
        [Description("在职")] workinng = 1,
        [Description("离职")] quit = 2
    }
}
