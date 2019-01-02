using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PinJianHR.Common.TableModel
{
    [DisplayName("简历基本信息")]
    public class _resumeBase
    {
        [DisplayName("Id")]
        public int resumeBaseId { get; set; }

        [DisplayName("所属简历")]
        public int resumeId { get; set; }
        public int provinceId { get; set; }
        public int cityId { get; set; }

        [DisplayName("姓名")]
        public string name { get; set; }

        [DisplayName("头像")]
        public string pic { get; set; }

        [DisplayName("性别")]
        public int gender { get; set; }

        [DisplayName("性别名称")]
        public string genderName { get; set; }

        [DisplayName("手机号")]
        public string mobile { get; set; }

        [DisplayName("出生日期")]
        public DateTime birthday { get; set; }

        [DisplayName("邮箱")]
        public string mail { get; set; }

        [DisplayName("是否删除")]
        public bool isDel { get; set; }

        [DisplayName("期望最低工资")]
        public int wageStart { get; set; }


        [DisplayName("期望最高工资")]
        public int wageEnd { get; set; }


        public string provinceName { get; set; }

        public string cityName { get; set; }


        [DisplayName("工作年限")]
        public int workYears { get; set; }

        [DisplayName("添加时间")]
        public DateTime addTime { get; set; }

        [DisplayName("更新时间")]
        public DateTime updateTime { get; set; }

        public int age => birthday != DateTime.MaxValue
            ? DateTime.Now.Subtract(birthday).Days / 365
            : 0;
    }

    public class companyResumeModel
    {

        public int jobResumeId { get; set; }

        [DisplayName("所属简历")]
        public int resumeId { get; set; }

        [DisplayName("简历ID")]
        public int jobId { get; set; }

        [DisplayName("姓名")]
        public string name { get; set; }

        /// <summary>
        /// 推荐人
        /// </summary>
        public string recommend { get; set; }

        /// <summary>
        ///推荐类型
        /// </summary>
        public string shareType { get; set; }

        /// <summary>
        /// 推荐类型
        /// </summary>
        public string shareTypeName { get; set; }
        [DisplayName("职位")]
        public string jobName { get; set; }

        [DisplayName("性别名称")]
        public string genderName { get; set; }

        [DisplayName("工作年限")]
        public int workYears { get; set; }

        [DisplayName("添加时间")]
        public DateTime addTime { get; set; }

        [DisplayName("更新时间")]
        public DateTime updateTime { get; set; }

        public bool isView { get; set; }

        [DisplayName("手机号")]
        public string mobile { get;set; }

        public DateTime birthday { get; set; }

        public int age => birthday != DateTime.MaxValue
            ? DateTime.Now.Subtract(birthday).Days / 365
            : 0;
    }

    public class MyResumeDbModel
    {
        //public int resumeJobCount { get; set; }

        //public  string pic { get; set; }

        public _resumeBase baseInfo { get; set; }

        public int age => baseInfo.birthday != DateTime.MaxValue
            ? DateTime.Now.Subtract(baseInfo.birthday).Days / 365
            : 0;
    }
}
