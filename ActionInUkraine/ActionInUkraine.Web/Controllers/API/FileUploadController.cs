using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Net.Http.Headers;

namespace ActionInUkraine.Web.Controllers.API
{
    public class FileUploadController : ApiController
    {
        public Task<IEnumerable<string>> Post()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                string fullPath = HttpContext.Current.Server.MapPath("~/uploads");
                MyMultipartFormDataStreamProvider streamProvider = new MyMultipartFormDataStreamProvider(fullPath);
                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);

                    var fileInfo = streamProvider.FileData.Select(i =>
                    {
                        var info = new FileInfo(i.LocalFileName);
                        return info.Name;
                    });
                    return fileInfo;

                });
                return task;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Request!"));
            }
        }
    }


    public class MyMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public MyMultipartFormDataStreamProvider(string path)
            : base(path)
        { }

        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            // restrict what images can be selected
            var extensions = new[] { "png", "gif", "jpg" };
            var filename = headers.ContentDisposition.FileName.Replace("\"", string.Empty);

            if (filename.IndexOf('.') < 0)
                return Stream.Null;

            var extension = filename.Split('.').Last();

            return extensions.Any(i => i.Equals(extension, StringComparison.InvariantCultureIgnoreCase))
                       ? base.GetStream(parent, headers)
                       : Stream.Null;

        }


        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string oldfileName = null;
            string newfileName = null;

            if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            {
                oldfileName = headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                newfileName = Guid.NewGuid().ToString() + Path.GetExtension(oldfileName); ;
            }



            //if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            //{
            //    fileName = headers.ContentDisposition.FileName;
            //}
            //else
            //{

            //}
            return newfileName;
        }
    }
}