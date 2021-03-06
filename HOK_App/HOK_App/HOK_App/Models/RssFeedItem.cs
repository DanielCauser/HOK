using System;
using System.Text.RegularExpressions;

namespace HOK_App.Models
{
    public class RssFeedItem
    {
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime PublishDateFormated => DateTime.TryParse(PublishDate, out DateTime result) ? result : DateTime.MinValue;
        public string PublishDate { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public string ImageLink { get; set; }
        public string Summary { get; set; }
        public string PodCastLink { get; set; }
        public string PodCastDuration { get; set; }

        private string backGroundImage;
        public string BackGroundImage
        {
            get
            {
                return backGroundImage;
            }
            set
            {
                try
                {
                    backGroundImage = value;
                    var resulting = backGroundImage.Split(new string[] { "www.haleokaula.org" }, StringSplitOptions.RemoveEmptyEntries);
                    backGroundImage = $"http://www.haleokaula.org/{resulting[1].Split('"')[0]}";
                }
                catch (Exception)
                {
                    backGroundImage = value;
                }
            }
        }

        public int Id { get; set; }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                //RSS feed always is "Author : Title", split it here and set correctly
                var splitIndex = title.IndexOf(":", StringComparison.OrdinalIgnoreCase);
                if (splitIndex > -1)
                {
                    Author = title.Substring(0, splitIndex).Trim();
                    title = title.Substring(splitIndex + 1, title.Length - splitIndex - 1).Trim();
                }
            }
        }

        private string caption;

        public string Caption
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(caption))
                    return caption;

                if (string.IsNullOrWhiteSpace(Description)) return string.Empty;

                //get rid of HTML tags
                caption = Regex.Replace(Description, "<[^>]*>", string.Empty);

                //get rid of multiple blank lines
                caption = Regex.Replace(caption, @"^\s*$\n", string.Empty, RegexOptions.Multiline);

                return caption;
            }
        }

        private bool showImage = true;

        public bool ShowImage
        {
            get { return showImage; }
            set { showImage = value; }
        }

        private string image = @"https://secure.gravatar.com/avatar/70148d964bb389d42547834e1062c886?s=60&r=x&d=http%3a%2f%2fd1iqk4d73cu9hh.cloudfront.net%2fcomponents%2fimg%2fuser-icon.png";

        /// <summary>
        /// When we set the image, mark show image as true
        /// </summary>
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                showImage = true;
            }
        }
    }
}