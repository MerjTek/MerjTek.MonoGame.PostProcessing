//+--------+-------+--------+--------+--------+--------+--------+ 
// This file is auto-generated. Please do not update. 
//+--------+--------+--------+--------+--------+--------+--------+ 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
 
namespace MerjTek.MonoGame.PostProcessing.Effects 
{ 
    /// <summary> 
    /// A class that performs a Post Process Effect. 
    /// </summary> 
    internal class PostProcessingFrostedGlassNoiseEffect : Effect 
    { 
        #region Protected Variable (Effect Code) 
 
        static protected byte[] effectCode = 
        { 
            0x4d, 0x47, 0x46, 0x58, 0x0a, 0x01, 0xc8, 0x18, 0xac, 0xa6, 0x01, 0x00, 0x00, 0x00, 0x00, 0x90, 
            0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x40, 
            0x00, 0x02, 0x00, 0x00, 0x00, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, 0x88, 0x00, 0x02, 0x00, 0x00, 
            0x00, 0x00, 0x64, 0x0a, 0x00, 0x00, 0x44, 0x58, 0x42, 0x43, 0x52, 0xe5, 0x46, 0x4a, 0x30, 0xd6, 
            0xbc, 0x42, 0x4f, 0xc5, 0x6f, 0x9c, 0xac, 0x6f, 0x7a, 0x6b, 0x01, 0x00, 0x00, 0x00, 0x64, 0x0a, 
            0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x2c, 0x00, 0x00, 0x00, 0x84, 0x00, 0x00, 0x00, 0xb8, 0x00, 
            0x00, 0x00, 0x49, 0x53, 0x47, 0x4e, 0x50, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x08, 0x00, 
            0x00, 0x00, 0x38, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x03, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x44, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x03, 0x03, 
            0x00, 0x00, 0x53, 0x56, 0x5f, 0x50, 0x6f, 0x73, 0x69, 0x74, 0x69, 0x6f, 0x6e, 0x00, 0x54, 0x45, 
            0x58, 0x43, 0x4f, 0x4f, 0x52, 0x44, 0x00, 0xab, 0xab, 0xab, 0x4f, 0x53, 0x47, 0x4e, 0x2c, 0x00, 
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0f, 0x00, 
            0x00, 0x00, 0x53, 0x56, 0x5f, 0x54, 0x61, 0x72, 0x67, 0x65, 0x74, 0x00, 0xab, 0xab, 0x53, 0x48, 
            0x44, 0x52, 0xa4, 0x09, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x69, 0x02, 0x00, 0x00, 0x59, 0x00, 
            0x00, 0x04, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x5a, 0x00, 
            0x00, 0x03, 0x00, 0x60, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5a, 0x00, 0x00, 0x03, 0x00, 0x60, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x58, 0x18, 0x00, 0x04, 0x00, 0x70, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x55, 0x55, 0x00, 0x00, 0x58, 0x18, 0x00, 0x04, 0x00, 0x70, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0x55, 0x55, 0x00, 0x00, 0x62, 0x10, 0x00, 0x03, 0x32, 0x10, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0x65, 0x00, 0x00, 0x03, 0xf2, 0x20, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x68, 0x00, 
            0x00, 0x02, 0x10, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x08, 0x92, 0x00, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x06, 0x62, 0x00, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x56, 0x84, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x08, 0xf2, 0x00, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x46, 0x0e, 0x10, 0x80, 0x41, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x14, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x08, 0x32, 0x00, 0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0xe6, 0x0a, 0x10, 0x80, 0x41, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x45, 0x00, 
            0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0x46, 0x00, 0x10, 0x00, 0x02, 0x00, 
            0x00, 0x00, 0x46, 0x7e, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x45, 0x00, 0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x46, 0x00, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x46, 0x7e, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x32, 0x00, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0xe6, 0x0a, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0x45, 0x00, 0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x04, 0x00, 0x00, 0x00, 0x46, 0x00, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x46, 0x7e, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0xe6, 0x0a, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x46, 0x7e, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x60, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x09, 0xf2, 0x00, 
            0x10, 0x00, 0x05, 0x00, 0x00, 0x00, 0x46, 0x10, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x46, 0x7e, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x07, 0xf2, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0xe6, 0x04, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x46, 0x14, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x09, 0xf2, 0x00, 
            0x10, 0x00, 0x07, 0x00, 0x00, 0x00, 0x46, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x46, 0x7e, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x08, 0x32, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0xe6, 0x0a, 0x10, 0x80, 0x41, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xe6, 0x0a, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x45, 0x00, 
            0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x08, 0x00, 0x00, 0x00, 0x46, 0x00, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x46, 0x7e, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x45, 0x00, 0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x09, 0x00, 0x00, 0x00, 0xe6, 0x0a, 
            0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x46, 0x7e, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x32, 0x00, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0xe6, 0x0a, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0xe6, 0x0a, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x45, 0x00, 0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x7e, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x38, 0x00, 0x00, 0x08, 0x32, 0x00, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x46, 0x10, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0xa6, 0x8a, 0x20, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x46, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x46, 0x7e, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0x00, 0x60, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x38, 0x00, 0x00, 0x07, 0x82, 0x00, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0a, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x01, 0x40, 
            0x00, 0x00, 0x09, 0x00, 0x10, 0x41, 0x41, 0x00, 0x00, 0x05, 0x82, 0x00, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x3a, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x0a, 0x82, 0x00, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3a, 0x00, 0x10, 0x80, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x2a, 0x8e, 0xe3, 0x3d, 0x0a, 0x00, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x38, 0x00, 0x00, 0x07, 0x12, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x3a, 0x00, 
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x09, 0x00, 0x90, 0x42, 0x1d, 0x00, 
            0x00, 0x07, 0x82, 0x00, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x2b, 0x8e, 
            0x63, 0x3c, 0x3a, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1f, 0x00, 0x04, 0x03, 0x3a, 0x00, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x0a, 0x82, 0x00, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0x3a, 0x00, 0x10, 0x80, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x40, 
            0x00, 0x00, 0x09, 0x00, 0x90, 0x42, 0x01, 0x40, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3f, 0x36, 0x00, 
            0x00, 0x05, 0x82, 0x00, 0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x36, 0x00, 0x00, 0x05, 0x82, 0x00, 0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x01, 0x40, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x05, 0x82, 0x00, 0x10, 0x00, 0x04, 0x00, 
            0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x08, 0xf2, 0x00, 
            0x10, 0x00, 0x0a, 0x00, 0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x12, 0x00, 0x00, 0x01, 0x32, 0x00, 
            0x00, 0x0f, 0xf2, 0x00, 0x10, 0x00, 0x0b, 0x00, 0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x09, 0x00, 0x90, 0x42, 0x09, 0x00, 0x90, 0x42, 0x09, 0x00, 
            0x90, 0x42, 0x09, 0x00, 0x90, 0x42, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x80, 0xbf, 0x00, 0x00, 
            0x00, 0xc0, 0x00, 0x00, 0x40, 0xc0, 0x00, 0x00, 0x80, 0xc0, 0x1d, 0x00, 0x00, 0x0a, 0xf2, 0x00, 
            0x10, 0x00, 0x0c, 0x00, 0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x2b, 0x8e, 0xe3, 0x3c, 0xa0, 0xaa, 
            0x2a, 0x3d, 0x2b, 0x8e, 0x63, 0x3d, 0xdb, 0x38, 0x8e, 0x3d, 0xf6, 0x0f, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x0b, 0x32, 0x00, 0x10, 0x00, 0x0d, 0x00, 0x00, 0x00, 0x36, 0x0f, 
            0x10, 0x80, 0x41, 0x00, 0x00, 0x00, 0x0b, 0x00, 0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 
            0x80, 0x3f, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x32, 0x00, 
            0x00, 0x0f, 0xb2, 0x00, 0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x09, 0x00, 0x90, 0x42, 0x09, 0x00, 0x90, 0x42, 0x00, 0x00, 
            0x00, 0x00, 0x09, 0x00, 0x90, 0x42, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0xa0, 0xc0, 0x00, 0x00, 
            0xc0, 0xc0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xe0, 0xc0, 0x1d, 0x00, 0x00, 0x0a, 0xc2, 0x00, 
            0x10, 0x00, 0x0d, 0x00, 0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0xa0, 0xaa, 0xaa, 0x3d, 0x65, 0x1c, 0xc7, 0x3d, 0xf6, 0x0f, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x36, 0x20, 0x00, 0x05, 0x82, 0x00, 0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x3a, 0x00, 
            0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x0f, 0x62, 0x00, 0x10, 0x00, 0x0f, 0x00, 
            0x00, 0x00, 0x56, 0x05, 0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x80, 0xbf, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x02, 0x40, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x36, 0x00, 0x00, 0x08, 0x92, 0x00, 0x10, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x02, 0x40, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x36, 0x00, 0x00, 0x05, 0x22, 0x00, 0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x01, 0x40, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x42, 0x00, 0x10, 0x00, 0x0e, 0x00, 
            0x00, 0x00, 0x3a, 0x00, 0x10, 0x80, 0x41, 0x00, 0x00, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x01, 0x40, 
            0x00, 0x00, 0x00, 0x00, 0x80, 0x3f, 0x37, 0x00, 0x00, 0x09, 0xe2, 0x00, 0x10, 0x00, 0x0f, 0x00, 
            0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x0d, 0x00, 0x00, 0x00, 0x56, 0x0e, 0x10, 0x00, 0x0f, 0x00, 
            0x00, 0x00, 0x56, 0x0e, 0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x0f, 0x32, 0x00, 
            0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x06, 0x00, 0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x02, 0x40, 
            0x00, 0x00, 0x00, 0x00, 0x80, 0xbf, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x08, 0xc2, 0x00, 0x10, 0x00, 0x0e, 0x00, 
            0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x37, 0x00, 0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x0e, 0x00, 
            0x00, 0x00, 0xa6, 0x0a, 0x10, 0x00, 0x0d, 0x00, 0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x0e, 0x00, 
            0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x05, 0x12, 0x00, 
            0x10, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x3a, 0x00, 0x10, 0x00, 0x0b, 0x00, 0x00, 0x00, 0x36, 0x00, 
            0x00, 0x08, 0xe2, 0x00, 0x10, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x37, 0x00, 
            0x00, 0x09, 0xf2, 0x00, 0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x0c, 0x00, 
            0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x0e, 0x00, 
            0x00, 0x00, 0x01, 0x00, 0x00, 0x07, 0x32, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0xc6, 0x00, 
            0x10, 0x00, 0x0c, 0x00, 0x00, 0x00, 0x16, 0x05, 0x10, 0x00, 0x0d, 0x00, 0x00, 0x00, 0x32, 0x00, 
            0x00, 0x0f, 0xf2, 0x00, 0x10, 0x00, 0x0d, 0x00, 0x00, 0x00, 0xa6, 0x05, 0x10, 0x00, 0x0b, 0x00, 
            0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x80, 0xbf, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 
            0x80, 0xbf, 0x00, 0x00, 0x80, 0x3f, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x05, 0x42, 0x00, 
            0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x37, 0x00, 
            0x00, 0x09, 0x32, 0x00, 0x10, 0x00, 0x0f, 0x00, 0x00, 0x00, 0xa6, 0x0a, 0x10, 0x00, 0x0c, 0x00, 
            0x00, 0x00, 0x46, 0x00, 0x10, 0x00, 0x0d, 0x00, 0x00, 0x00, 0x66, 0x0a, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x36, 0x00, 0x00, 0x05, 0x42, 0x00, 0x10, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x01, 0x40, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x37, 0x00, 0x00, 0x09, 0x62, 0x00, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x56, 0x05, 0x10, 0x00, 0x0c, 0x00, 0x00, 0x00, 0xa6, 0x0b, 0x10, 0x00, 0x0d, 0x00, 
            0x00, 0x00, 0xa6, 0x08, 0x10, 0x00, 0x0f, 0x00, 0x00, 0x00, 0x37, 0x00, 0x00, 0x09, 0x82, 0x00, 
            0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0x0a, 0x00, 0x10, 0x00, 0x0c, 0x00, 0x00, 0x00, 0x0a, 0x00, 
            0x10, 0x00, 0x0b, 0x00, 0x00, 0x00, 0x1a, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x37, 0x00, 
            0x00, 0x09, 0x82, 0x00, 0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x0a, 0x00, 0x10, 0x00, 0x0c, 0x00, 
            0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2a, 0x00, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x3c, 0x00, 0x00, 0x07, 0x62, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x56, 0x04, 
            0x10, 0x00, 0x0c, 0x00, 0x00, 0x00, 0xa6, 0x09, 0x10, 0x00, 0x0c, 0x00, 0x00, 0x00, 0x37, 0x00, 
            0x00, 0x09, 0x82, 0x00, 0x10, 0x00, 0x04, 0x00, 0x00, 0x00, 0x2a, 0x00, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1a, 0x00, 0x10, 0x00, 0x0f, 0x00, 
            0x00, 0x00, 0x3c, 0x00, 0x00, 0x07, 0x82, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0a, 0x00, 
            0x10, 0x00, 0x0c, 0x00, 0x00, 0x00, 0x1a, 0x00, 0x10, 0x00, 0x06, 0x00, 0x00, 0x00, 0x37, 0x00, 
            0x00, 0x0c, 0xf2, 0x00, 0x10, 0x00, 0x0a, 0x00, 0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x02, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x36, 0x00, 
            0x00, 0x05, 0x82, 0x00, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x40, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x15, 0x00, 0x00, 0x01, 0x38, 0x00, 0x00, 0x07, 0x72, 0x00, 0x10, 0x00, 0x03, 0x00, 
            0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x06, 0x00, 0x10, 0x00, 0x06, 0x00, 
            0x00, 0x00, 0x32, 0x00, 0x00, 0x09, 0x72, 0x00, 0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0xf6, 0x0f, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0x46, 0x02, 
            0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x09, 0x72, 0x00, 0x10, 0x00, 0x02, 0x00, 
            0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x04, 0x00, 
            0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x09, 0x72, 0x00, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x46, 0x02, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x02, 0x00, 0x00, 0x00, 0x32, 0x00, 
            0x00, 0x09, 0x72, 0x00, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x04, 0x00, 
            0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x05, 0x00, 0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0x32, 0x00, 0x00, 0x09, 0x72, 0x00, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x00, 
            0x10, 0x00, 0x0a, 0x00, 0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x07, 0x00, 0x00, 0x00, 0x46, 0x02, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x09, 0x72, 0x00, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0x56, 0x05, 0x10, 0x00, 0x0a, 0x00, 0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x08, 0x00, 
            0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x32, 0x00, 0x00, 0x09, 0x72, 0x00, 
            0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0xa6, 0x0a, 0x10, 0x00, 0x0a, 0x00, 0x00, 0x00, 0x46, 0x02, 
            0x10, 0x00, 0x09, 0x00, 0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x32, 0x00, 
            0x00, 0x09, 0x72, 0x20, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0xf6, 0x0f, 0x10, 0x00, 0x0a, 0x00, 
            0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x02, 0x10, 0x00, 0x01, 0x00, 
            0x00, 0x00, 0x36, 0x00, 0x00, 0x05, 0x82, 0x20, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x40, 
            0x00, 0x00, 0x00, 0x00, 0x80, 0x3f, 0x3e, 0x00, 0x00, 0x01, 0x02, 0x00, 0x00, 0x00, 0x01, 0x01, 
            0x01, 0x00, 0xff, 0xff, 0xff, 0xff, 0x01, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x01, 0x01, 0x01, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 
            0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x05, 0x01, 
            0x00, 0x00, 0x01, 0x50, 0x02, 0x00, 0x00, 0x44, 0x58, 0x42, 0x43, 0xba, 0x1c, 0x0d, 0x7a, 0xe1, 
            0xd8, 0x6d, 0x06, 0xe9, 0x65, 0x62, 0x4a, 0x0a, 0xe1, 0xe7, 0xbc, 0x01, 0x00, 0x00, 0x00, 0x50, 
            0x02, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x2c, 0x00, 0x00, 0x00, 0x84, 0x00, 0x00, 0x00, 0xdc, 
            0x00, 0x00, 0x00, 0x49, 0x53, 0x47, 0x4e, 0x50, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x08, 
            0x00, 0x00, 0x00, 0x38, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0f, 0x0f, 0x00, 0x00, 0x44, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x03, 
            0x03, 0x00, 0x00, 0x53, 0x56, 0x5f, 0x50, 0x6f, 0x73, 0x69, 0x74, 0x69, 0x6f, 0x6e, 0x00, 0x54, 
            0x45, 0x58, 0x43, 0x4f, 0x4f, 0x52, 0x44, 0x00, 0xab, 0xab, 0xab, 0x4f, 0x53, 0x47, 0x4e, 0x50, 
            0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x38, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0f, 
            0x00, 0x00, 0x00, 0x44, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 
            0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x03, 0x0c, 0x00, 0x00, 0x53, 0x56, 0x5f, 0x50, 0x6f, 
            0x73, 0x69, 0x74, 0x69, 0x6f, 0x6e, 0x00, 0x54, 0x45, 0x58, 0x43, 0x4f, 0x4f, 0x52, 0x44, 0x00, 
            0xab, 0xab, 0xab, 0x53, 0x48, 0x44, 0x52, 0x6c, 0x01, 0x00, 0x00, 0x40, 0x00, 0x01, 0x00, 0x5b, 
            0x00, 0x00, 0x00, 0x59, 0x00, 0x00, 0x04, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 
            0x00, 0x00, 0x00, 0x5f, 0x00, 0x00, 0x03, 0xf2, 0x10, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5f, 
            0x00, 0x00, 0x03, 0x32, 0x10, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x67, 0x00, 0x00, 0x04, 0xf2, 
            0x20, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x65, 0x00, 0x00, 0x03, 0x32, 
            0x20, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x68, 0x00, 0x00, 0x02, 0x01, 0x00, 0x00, 0x00, 0x11, 
            0x00, 0x00, 0x08, 0x12, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x1e, 0x10, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x11, 
            0x00, 0x00, 0x08, 0x22, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x1e, 0x10, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x11, 
            0x00, 0x00, 0x08, 0x42, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x1e, 0x10, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x11, 
            0x00, 0x00, 0x08, 0x82, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x1e, 0x10, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x11, 
            0x00, 0x00, 0x08, 0x12, 0x20, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x11, 
            0x00, 0x00, 0x08, 0x22, 0x20, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x11, 
            0x00, 0x00, 0x08, 0x42, 0x20, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x11, 
            0x00, 0x00, 0x08, 0x82, 0x20, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x0e, 0x10, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x46, 0x8e, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x36, 
            0x00, 0x00, 0x05, 0x32, 0x20, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x46, 0x10, 0x10, 0x00, 0x01, 
            0x00, 0x00, 0x00, 0x3e, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x02, 
            0x03, 0x0a, 0x50, 0x72, 0x6f, 0x6a, 0x65, 0x63, 0x74, 0x69, 0x6f, 0x6e, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x03, 0x04, 0x56, 0x69, 
            0x65, 0x77, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x01, 0x03, 0x09, 0x54, 0x65, 0x78, 0x65, 0x6c, 0x53, 0x69, 0x7a, 0x65, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x09, 0x46, 0x72, 0x65, 0x71, 0x75, 0x65, 0x6e, 0x63, 0x79, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1f, 
            0x85, 0xeb, 0x3d, 0x03, 0x07, 0x14, 0x50, 0x72, 0x65, 0x50, 0x72, 0x6f, 0x63, 0x65, 0x73, 0x73, 
            0x54, 0x65, 0x78, 0x74, 0x75, 0x72, 0x65, 0x4d, 0x61, 0x70, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x07, 0x0f, 0x4e, 0x6f, 0x69, 0x73, 
            0x65, 0x54, 0x65, 0x78, 0x74, 0x75, 0x72, 0x65, 0x4d, 0x61, 0x70, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x44, 
            0x65, 0x66, 0x61, 0x75, 0x6c, 0x74, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 
            0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0xff, 
            0xff, 0xff, 0xff, 0x00, 0x01, 0x00, 0x0f, 0x0f, 0x0f, 0x0f, 0xff, 0xff, 0xff, 0x7f, 0x00, 0x01, 
            0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4d, 0x47, 0x46, 0x58, 
        }; 
 
        #endregion 
  
        /// <summary> 
        /// Initializes an instance of the PostProcessingFrostedGlassNoiseEffect class. 
        /// </summary> 
        public PostProcessingFrostedGlassNoiseEffect(GraphicsDevice graphicsDevice) : 
            base(graphicsDevice, effectCode, 0, effectCode.Length) 
        { 
        } 
    } 
} 
 
//+--------+-------+--------+--------+--------+--------+--------+ 
// This file is auto-generated. Please do not update. 
//+--------+--------+--------+--------+--------+--------+--------+ 
 
