using System.Collections.Generic;

namespace RazorPagingAdoNet.Models.ViewModels
{
    public class ListViewModel<T>
    {
        public List<T> Results { get; set; }
    }
}