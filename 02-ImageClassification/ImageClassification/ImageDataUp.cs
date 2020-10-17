using System;
using System.Collections.Generic;
using System.Text;

namespace ImageClassification
{
    class ImageDataUp
    {
        public string Path { get; set; }
        public string Label { get; set; }
        public byte[] Image { get; set; }
        public uint LabelKey { get; set; }
    }
}
