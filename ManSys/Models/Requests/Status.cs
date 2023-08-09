using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ManSys.Models
{
    [Table("RequestStatuses")]
    public class Status
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsDefaultOnCreateItem { get; set; } = false;
        public GlobalStatus GlobalStatus { get; set; }
        [NotMapped]
        public string HexedColor
        {
            get
            {
                /*
                var hexed = Argb.ToString("X");
                Regex argb = new Regex(@"[0-9a-fA-F]{8}");
                Regex rgb = new Regex(@"[0-9a-fA-F]{6}");
                Match argbmatch = argb.Match(hexed);
                Match rgbmatch = rgb.Match(hexed);
                if (!argbmatch.Success)
                    return "#000000";
                if (rgbmatch.Success)
                    return hexed;   
                */
                if (Color.IsEmpty)
                    return "#000000";
                return "#" + Argb.ToString("X").ToLower().Remove(0, 2);
            }
        }
        public Int32 Argb
        {
            get
            {
                return Color.ToArgb();
            }
            set
            {
                Color = Color.FromArgb(value);
            }
        }

        [NotMapped]
        public Color Color { get; set; }
    }

    public enum GlobalStatus
    {
        Created,
        InProgress,
        Closed,
        Archived
    }
}