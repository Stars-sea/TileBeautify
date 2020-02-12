using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TileBeautifyWPF
{
    public struct TileBackground
    {
        public Color Tile150x { get; set; }
        public Color Tile70x  { get; set; }
    }

    public enum ForegroundModel { Light, Black, Off }

    public struct TileForeground
    {
        public ForegroundModel Tile150x { get; set; }
        public ForegroundModel Tile70x  { get; set; }
    }

    public class TileInfo
    {
        public string TileDisplayName    { get; set; }
        public string TileCommand        { get; set; }
        public TileBackground Background { get; set; }
        public TileForeground Foreground { get; set; }
    }
}
