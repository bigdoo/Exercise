using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class oneSpaceAttribute : DataTypeAttribute
    {
        public oneSpaceAttribute():base (DataType.Text)
        {

        }
        public override bool IsValid(object value)
        {
            var str = (string)value;

            return str.Contains(" ");
        }

    }

}