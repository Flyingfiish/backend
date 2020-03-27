using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BadNews.ModelBuilders.News;

namespace BadNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsModelBuilder newsModelBuilder;

        public NewsController(INewsModelBuilder newsModelBuilder)
        {
            this.newsModelBuilder = newsModelBuilder;
        }

        public IActionResult Index()
        {
            int pageIndex = 0;
            var model = newsModelBuilder.BuildIndexModel(pageIndex, true, null);
            if (model == null)
                return NotFound();
            return View(model);
        }

        public IActionResult fullarticle(Guid id)
        {
            var model = newsModelBuilder.BuildFullArticleModel(id);
            return View(model);
        }
    }
}