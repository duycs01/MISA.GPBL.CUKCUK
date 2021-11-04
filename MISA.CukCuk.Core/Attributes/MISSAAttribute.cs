using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Attributes
{
    public class MISAAttribute
    {


        /// <summary>
        /// Không nhận các property truyền lên cho database
        /// CreatedBy: mf955-duylv - 29/09/2021
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class MISANotMap : Attribute
        {
        }


        /// <summary>
        /// Các property bắt buộc phải nhập
        /// CreatedBy: mf955-duylv - 29/09/2021
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class MISARequired : Attribute
        {
            public string FieldName = string.Empty;
            public MISARequired(string fieldName)
            {
                FieldName = fieldName;

            }
        }

    }
}
