namespace ForumSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class IndexViewModel : IMapFrom<Category>
    {
        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
