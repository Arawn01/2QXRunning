using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels.Lists
{
    public class ListViewModel<T>
    {
        public string Title { get; set; }
        public string TitleContent { get; set; }
        public List<T> GenericList { get; set; }

        public ListViewModel(string title, string titleContent, List<T> gList)
        {
            Title = title;
            TitleContent = titleContent;
            GenericList = gList;
        }
    }
}
