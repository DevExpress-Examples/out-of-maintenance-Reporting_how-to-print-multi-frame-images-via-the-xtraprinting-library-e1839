using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using System.Drawing.Printing;
using DevExpress.XtraPrintingLinks;
using System.Drawing.Imaging;
using System.IO;

namespace PrintImageFrames {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            ReportAnImage(Application.StartupPath + @"\..\..\" + "Rotating_earth_(small).gif", checkBox1.Checked);
        }

        private void button2_Click(object sender, EventArgs e) {
            ReportAnImage(Application.StartupPath + @"\..\..\" + "Prices.tiff", checkBox1.Checked);
        }

        private void ReportAnImage(string filename, bool pageBreakAfterEachImage) {
            CompositeLink compositeLink = new CompositeLink(printingSystem1);
            Image image = Image.FromFile(filename);
            FrameDimension frameDimension = new FrameDimension(image.FrameDimensionsList[0]);
            int framesCount = image.GetFrameCount(frameDimension);

            for(int i = 0; i < framesCount; i++) {
                image.SelectActiveFrame(frameDimension, i);
                compositeLink.Links.Add(new ImageLink(new Bitmap(image), pageBreakAfterEachImage));
            }

            image.Dispose();

            compositeLink.PaperKind = PaperKind.A3;
            compositeLink.Landscape = true;

            compositeLink.ShowPreviewDialog();
        }

    }

    public class ImageLink : Link {

        private Image image;

        public Image Image {
            get { return image; }
            set { image = value; }
        }

        private bool addPageBreak;

        public bool AddPageBreak {
            get { return addPageBreak; }
            set { addPageBreak = value; }
        }

        public ImageLink()
            : this(null, null, false) {

        }

        public ImageLink(Image image, bool addPageBreak)
            : this(null, image, addPageBreak) {

        }

        public ImageLink(PrintingSystem ps, Image image, bool addPageBreak)
            : base(ps) {

            this.Image = image;
            this.AddPageBreak = addPageBreak;
        }

        protected override void CreateDetail(BrickGraphics graph) {
            if(Image != null) {
                // Add an image to a specific location.
                graph.DrawImage(Image, new Rectangle(0, 0, Image.Width, Image.Height),
                    BorderSide.None, Color.Transparent);

                if (AddPageBreak)
                    // Add a page break after the image.
                    graph.PrintingSystem.InsertPageBreak(Image.Height + 1);
            }
        }

    }

}
