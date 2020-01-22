using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using SharpShell.Attributes;
using SharpShell.SharpThumbnailHandler;
using SharpShell.SharpContextMenu;
using Svg;
using System.Windows.Forms;

namespace SvgThumbnailProvider
{
   [ComVisible(true)]
   [COMServerAssociation(AssociationType.ClassOfExtension, ".svg")]
   public class SvgThumbnailHandler : SharpThumbnailHandler
   {
      public SvgThumbnailHandler()
      {
      }

      protected override Bitmap GetThumbnailImage(uint width)
      {
         //  Create a stream reader for the selected item stream
         try
         {
            var svgDoc = SvgDocument.Open<SvgDocument>(SelectedItemStream);

            return  svgDoc.Draw((int)width, (int)width);
         }
         catch (Exception exception)
         {
            //  Log the exception and return null for failure
            LogError("An exception occurred opening the text file.", exception);
            return null;
         }
      }

   }


}
