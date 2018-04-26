using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BlizzStatistics.Image.Api.Controllers
{   
    //This image Api is taken directly from the course resources.
    public class ImageController : ApiController
    {
        /// <summary>
        /// Gets the specified image.
        /// </summary>
        /// <param name="name">The name of the image.</param>
        /// <returns>Returns the image, otherwise NotFound</returns>
        /// <remarks>
        /// YOU need to add error handling!
        /// </remarks>
        [Route("api/images/{name}", Name = "GetImageByName")]
        public HttpResponseMessage Get(string name)
        {
            string imagePath = GetImagePath();
            string fileName = $"{imagePath}\\{name}";
            string extension = new FileInfo(fileName).Extension.Substring(1);

            var image = File.ReadAllBytes(fileName);
            var ms = new MemoryStream(image);
            var respons = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(ms) };
            respons.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue($"image/{extension}");
            return respons;
        }
        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <remarks>Inspired by 
        /// http://www.c-sharpcorner.com/article/uploading-image-to-server-using-web-api-2-0/
        /// Handles ONLY upload of ONE file
        /// 
        /// YOU need to add error handling!
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post()
        {
            var file = HttpContext.Current.Request.Files.Count == 1 ? HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imagePath = GetImagePath();

                file.SaveAs($"{imagePath}\\{fileName}");

                return new CreatedActionResult(Request, Url.Link("GetImageByName", new { name = fileName }) + "/");
            }
            else
                return BadRequest();
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <returns></returns>
        private string GetImagePath()
        {
            var path = HttpContext.Current.Server.MapPath("~/uploads");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}
