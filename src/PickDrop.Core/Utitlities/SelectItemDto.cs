using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickDrop.Utitlities
{
    public class SelectItemDto
    {
        public SelectItemDto()
        {
        }

        public SelectItemDto(string label, int value)
        {
            Label = label;
            Value = value;
        }

        public string Label { get; set; }
        [Key]
        public int Value { get; set; }
    }
}
