using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PinJianHR.Common.TableModel
{
    [DisplayName("简历教育经历")]
    public class _resumeEducational
    {
        [DisplayName("Id")]
        public int resumeEducationalId { get; set; }

        [DisplayName("所属简历")]
        public int resumeId { get; set; }

        [DisplayName("学历")]
        public int qualificationId { get; set; }

        [DisplayName("开始时间")]
        public DateTime beginTime { get; set; }

        [DisplayName("结束时间")]
        public DateTime endTime { get; set; }

        [DisplayName("学校名称")]
        public string schoolName { get; set; }

        [DisplayName("专业")]
        public string major { get; set; }

        [DisplayName("描述")]
        public string description { get; set; }

        [DisplayName("状态")]
        public bool isDel { get; set; }

        [DisplayName("学历")]
        public string qualificationName { get; set; }
    }


}
