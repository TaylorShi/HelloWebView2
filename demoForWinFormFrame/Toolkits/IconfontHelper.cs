using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoForWinFormFrame
{
    public class IconfontHelper
    {
        //提供一个字体系列集合，该集合是基于客户端应用程序提供的字体文件生成的。
        private static System.Drawing.Text.PrivateFontCollection pfcc;

        public static System.Drawing.Text.PrivateFontCollection PFCC
        {
            get { return pfcc ?? LoadFont(); }
        }
        public static System.Drawing.Text.PrivateFontCollection LoadFont()
        {
            pfcc = new System.Drawing.Text.PrivateFontCollection();
            pfcc.AddFontFile(Environment.CurrentDirectory + "/Fonts/SegoeFluentIcons.ttf");
            return pfcc;
        }
    }
}
