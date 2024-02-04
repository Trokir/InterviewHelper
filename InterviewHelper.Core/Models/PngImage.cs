using MongoDB.Bson;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InterviewHelper.Core.Models
{
    public class PngImage
    {
        public ObjectId Id { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
    }
}
