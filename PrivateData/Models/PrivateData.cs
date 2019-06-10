using System;

namespace PrivateData.Models
{
    [Serializable]
    public class PData
    {
        public string Title { get; set; }
        public string Contents { get; set; }

        public PData(string title, string contents)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Contents = contents ?? throw new ArgumentNullException(nameof(contents));
        }
    }
}
