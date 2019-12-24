using KST.Fitri.NameSorter.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KST.Fitri.NameSorter.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            this.directory = System.Web.HttpContext.Current.Server.MapPath("~/Content/") + csString.FolderNames.namesorter;
            this.Names = csLog.Read(Path.Combine(directory, csString.FileNames.unsortednameslist));
            this.FileNameTxt = csLog.GetFileNames(directory, "*.txt");
        }

        #region Properties
        public string directory { get; set; }
        public List<string> Names { get; set; }
        public List<string> FileNameTxt { get; set; }
        #endregion


        /// <summary>Index</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns></returns>
        public ActionResult Index()
        {
            DataViewModel model = new DataViewModel();
            model.Filenames = this.FileNameTxt;
            model.Name = this.Names;
            return View(model);
        }

        [HttpPost]
        /// <summary>Sort</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns></returns>
        public ActionResult Sort(DataViewModel model)
        {
            if (model != null && model.Name != null && model.Name.Count > 0)
            {
                model.NameSort = csSorts.AscendingAlpphabetical(model.Name);
                model.Filenames = this.FileNameTxt;
            }
            return View("Index", model);
        }

        [HttpPost]
        /// <summary>Save</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns>JsonResult</returns>
        public JsonResult Save(string namelist)
        {
            if (!string.IsNullOrEmpty(namelist))
            {
                string path = Path.Combine(directory, csString.FolderNames.namesorter);
                csLog.UpdateSortList(csString.FileNames.sortednameslist, this.directory, namelist);
            }
            return Json(new { redirectTo = Url.Action("Index", "Home"), }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        /// <summary>Upload</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns>JsonResult</returns>
        public ActionResult Upload(HttpPostedFileBase file)
        {
            DataViewModel model = new DataViewModel();
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(directory, csString.FileNames.unsortednameslist);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        /// <summary>Download</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns>FileResult</returns>
        public FileResult Download(string filename)
        {
            string path = Path.Combine(directory, csString.FileNames.unsortednameslist);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }
    }
}