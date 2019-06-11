using System;
using System.Collections.Generic;
using System.Drawing;

namespace PrivateData.Models
{
    [Serializable]
    public class PData
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public List<Bitmap> Images { get; set; } = new List<Bitmap>();

        public PData(string title, string contents)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Contents = contents ?? throw new ArgumentNullException(nameof(contents));
        }

        public PData(string title, string contents, List<Bitmap> images)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Contents = contents ?? throw new ArgumentNullException(nameof(contents));
            Images = images ?? throw new ArgumentNullException(nameof(images));
        }

        public void AddImage(Bitmap image)
        {
            Images.Add(image);
        }

        public void RemoveImage(Bitmap image)
        {
            Images.Remove(image);
        }
    }
}
